//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

import React from 'react';

import { fetchTweetStatus } from '../services/fetch-tweet-status';
import { TweetStatus } from '../types/tweet-status';

export const useTweetStatus = (date?: Date): {
  value?: TweetStatus,
  error?: Error,
  loading : boolean
} => {

  const [ value, setValue ] = React.useState<TweetStatus>();
  const [ error, setError ] = React.useState<Error>();
  const [ loading, setLoading ] = React.useState<boolean>(false);

  React.useEffect(() => {
    if (!date) {
      return;
    }
    (async () => {
      try {
        setLoading(true);
        const minDate = new Date(date.toDateString());
        const maxDate = new Date(date.toDateString());
        maxDate.setDate(maxDate.getDate() + 1);
        setValue(await fetchTweetStatus(minDate, maxDate));
      } catch (error) {
        setError(error as Error);
      } finally {
        setLoading(false);
      }
    })();
  }, [ date ]);

  return {
    value,
    error,
    loading
  };

};
