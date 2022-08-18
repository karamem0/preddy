//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

import React from 'react';

import { fetchTweetForecast } from '../services/fetch-tweet-forecast';
import { TweetForecast } from '../types/tweet-forecast';

export const useTweetForecast = (): {
  value?: TweetForecast,
  error?: Error,
  loading : boolean
} => {

  const [ value, setValue ] = React.useState<TweetForecast>();
  const [ error, setError ] = React.useState<Error>();
  const [ loading, setLoading ] = React.useState<boolean>(false);

  React.useEffect(() => {
    (async () => {
      try {
        setLoading(true);
        const date = new Date();
        const minDate = new Date(date.toDateString());
        const maxDate = new Date(date.toDateString());
        maxDate.setDate(maxDate.getDate() + 30);
        setValue(await fetchTweetForecast(minDate, maxDate));
      } catch (error) {
        setError(error as Error);
      } finally {
        setLoading(false);
      }
    })();
  }, []);

  return {
    value,
    error,
    loading
  };

};
