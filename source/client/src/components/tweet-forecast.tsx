//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

import React from 'react';
import { FormattedMessage } from 'react-intl';

import messages from '../i18n/messages';

import { TweetForecastContent } from './tweet-forecast-content';

export const TweetForecast: React.FC = () => {

  return (
    <section className="tweet-forecast">
      <h2 className="title">
        <FormattedMessage {...messages.TWEET_FORECAST_TITLE} />
      </h2>
      <TweetForecastContent />
    </section>
  );

};
