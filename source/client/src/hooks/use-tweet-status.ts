//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/master/LICENSE
//

import React from 'react';

import { fetchTweetStatus } from '../services';

interface TweetStatus {
  items: {
    statusId: number;
    userId: number;
    userName: string;
    screenName: string;
    text: string;
    tweetedAt: Date;
    profileImageUrl: string;
    statusUrl: string;
    userUrl: string;
    mediaUrl: string;
  }[]
}

const useTweetStatus = (date?: Date): {
  value?: TweetStatus;
  loading : boolean;
} => {

  const [ value, setValue ] = React.useState<TweetStatus>();
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
        const json = await fetchTweetStatus(minDate, maxDate);
        setValue((value) => ({
          ...value,
          items: json.items.map(item => ({
            statusId: item.statusId,
            userId: item.userId,
            userName: item.userName,
            screenName: item.screenName,
            text: item.text,
            tweetedAt: new Date(item.tweetedAt),
            profileImageUrl: item.profileImageUrl,
            statusUrl: item.statusUrl,
            userUrl: item.userUrl,
            mediaUrl: item.mediaUrl
          }))
        }));
      } finally {
        setLoading(false);
      }
    })();
  }, [ date ]);

  return {
    loading,
    value
  };

};

export default useTweetStatus;
