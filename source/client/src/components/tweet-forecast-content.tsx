//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

import React from 'react';
import { FormattedMessage, useIntl } from 'react-intl';

import { Loader, Pill } from '@fluentui/react-northstar';

import { VscTwitter } from 'react-icons/vsc';

import { useTweetForecast } from '../hooks/use-tweet-forecast';
import messages from '../i18n/messages';

export const TweetForecastContent: React.FC = () => {

  const intl = useIntl();
  const { value, loading } = useTweetForecast();
  const [ description, setDescription ] = React.useState<string>();

  React.useEffect(() => {
    setDescription(value
      ? intl.formatMessage(
        messages.TWEET_FORECAST_DESCRIPTION,
        {
          dates: value.items
            .map(item => intl.formatDate(
              item.date,
              {
                month: 'numeric',
                day: 'numeric'
              }))
            .join(', ')
        })
      : undefined);
  }, [ intl, value ]);

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
      <div className="description">
        {description}
      </div>
      <a
        href={
          'https://twitter.com/share' +
          `?url=${window.origin}` +
          `&text=${description}` +
          `&hashtags=${intl.formatMessage(messages.APP_TITLE)}`
        }
        rel="noreferrer"
        target="_blank">
        <Pill
          className="pill"
          content={
            <span className="pill-content">
              <span className="pill-icon">
                <VscTwitter />
              </span>
              <span className="pill-title">
                <FormattedMessage {...messages.TWEET_FORECAST_BUTTON} />
              </span>
            </span>
         } />
      </a>
    </div>
  );

};
