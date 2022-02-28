//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

import React from 'react';

import { fetchTweetSummary } from '../services';

interface TweetSummary {
  minDate: Date;
  maxDate: Date;
  items: {
    date: Date;
    forecast: number;
    actual: number;
  }[]
}

const useTweetSummary = (): {
  date: Date;
  value?: TweetSummary;
  loading : boolean;
  callbacks: {
    todayCallback: () => void;
    prevCallback: (date: Date) => void;
    nextCallback: (date: Date) => void;
  }
} => {

  const [ date, setDate ] = React.useState<Date>(new Date());
  const [ value, setValue ] = React.useState<TweetSummary>();
  const [ loading, setLoading ] = React.useState<boolean>(false);

  const todayCallback = React.useCallback(() => {
    setDate(new Date());
  }, []);

  const prevCallback = React.useCallback((current: Date) => {
    const prev = new Date(current.toDateString());
    prev.setDate(prev.getDate() - 30);
    setDate(prev);
  }, []);

  const nextCallback = React.useCallback((current: Date) => {
    const next = new Date(current.toDateString());
    next.setDate(next.getDate() + 30);
    setDate(next);
  }, []);

  React.useEffect(() => {
    if (!date) {
      return;
    }
    (async () => {
      try {
        setLoading(true);
        const minDate = new Date(date.toDateString());
        minDate.setDate(minDate.getDate() - 30);
        const maxDate = new Date(date.toDateString());
        maxDate.setDate(maxDate.getDate() + 30);
        const json = await fetchTweetSummary(minDate, maxDate);
        setValue((value) => ({
          ...value,
          minDate: new Date(json.minDate),
          maxDate: new Date(json.maxDate),
          items: json.items.map(item => ({
            date: new Date(item.date),
            forecast: item.forecast,
            actual: item.actual
          }))
        }));
      } finally {
        setLoading(false);
      }
    })();
  }, [ date ]);

  return {
    date,
    value,
    loading,
    callbacks: {
      todayCallback,
      prevCallback,
      nextCallback
    }
  };

};

export default useTweetSummary;
