//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

import React from 'react';
import { useIntl } from 'react-intl';

import {
  CartesianGrid,
  Line,
  LineChart,
  ResponsiveContainer,
  Tooltip,
  XAxis
} from 'recharts';

import { AppContext } from '../contexts/app-context';
import messages from '../i18n/messages';
import { TweetSummaryItem } from '../types/tweet-summary';

interface TweetSummaryEventArgs {
  payload: TweetSummaryItem
}

interface TweetSummaryChartProps {
  items: TweetSummaryItem[]
}

export const TweetSummaryChart: React.FC<TweetSummaryChartProps> = (props) => {

  const { items } = props;
  const [ , setDate ] = React.useContext(AppContext);
  const intl = useIntl();

  return (
    <div className="chart">
      <div className="chart-inner">
        <ResponsiveContainer>
          <LineChart data={items}>
            <CartesianGrid strokeDasharray="2" />
            <Line
              activeDot={{
                r: 6,
                onClick: (_, value: unknown) => {
                  if (!setDate) {
                    return;
                  }
                  const args = value as TweetSummaryEventArgs;
                  const date = args.payload.date;
                  setDate(date);
                }
              }}
              dataKey="forecast"
              dot={{
                r: 4
              }}
              name={intl.formatMessage(messages.TWEET_SUMMARY_FORECAST)}
              stroke="#0078d4"
              type="monotone" />
            <Line
              activeDot={{
                r: 6,
                onClick: (_, value: unknown) => {
                  if (!setDate) {
                    return;
                  }
                  const args = value as TweetSummaryEventArgs;
                  const date = args.payload.date;
                  setDate(date);
                }
              }}
              dataKey="actual"
              dot={{
                r: 4
              }}
              name={intl.formatMessage(messages.TWEET_SUMMARY_ACTUAL)}
              stroke="#d13438"
              type="monotone" />
            <Tooltip
              labelFormatter={
              (value: Date) =>
                intl.formatDate(
                  value,
                  {
                    year: 'numeric',
                    month: 'numeric',
                    day: 'numeric'
                  })} />
            <XAxis
              dataKey="date"
              tickFormatter={
                (value: Date) =>
                  intl.formatDate(
                    value,
                    {
                      month: 'numeric',
                      day: 'numeric'
                    })} />
          </LineChart>
        </ResponsiveContainer>
      </div>
    </div>
  );

};
