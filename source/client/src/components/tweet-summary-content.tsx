//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

import React from 'react';
import { FormattedMessage, useIntl } from 'react-intl';

import { Loader } from '@fluentui/react-northstar';

import useTweetSummary from '../hooks/use-tweet-summary';
import messages from '../i18n/messages';

import TweetSummaryChart from './tweet-summary-chart';
import TweetSumamryHeader from './tweet-summary-header';

const TweetSumamryContent: React.FC = () => {

  const intl = useIntl();
  const {
    date,
    value,
    loading,
    callbacks
  } = useTweetSummary();

  if (loading) {
    return (
      <div className="content">
        <div className="loading">
          <Loader label={intl.formatMessage(messages.APP_LOADING)} />
        </div>
      </div>
    );
  }

  if (!value || !value.items.length) {
    return (
      <div className="content">
        <div className="description">
          <FormattedMessage {...messages.APP_NODATA} />
        </div>
      </div>
    );
  }

  return (
    <div className="content">
      <TweetSumamryHeader
        maxDate={value.maxDate}
        minDate={value.minDate}
        onNext={() => callbacks.nextCallback(date)}
        onPrev={() => callbacks.prevCallback(date)}
        onToday={() => callbacks.todayCallback()} />
      <TweetSummaryChart
        items={
            value.items.map(item => ({
              date: item.date,
              forecast: item.forecast,
              actual: item.actual
            }))
          } />
    </div>
  );

};

export default TweetSumamryContent;
