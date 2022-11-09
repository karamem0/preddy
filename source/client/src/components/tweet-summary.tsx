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

import { TweetSummaryContent } from './tweet-summary-content';

export const TweetSumamry: React.FC = () => {

  return (
    <section className="tweet-summary">
      <h2 className="title">
        <FormattedMessage {...messages.TWEET_SUMMARY_TITLE} />
      </h2>
      <TweetSummaryContent />
    </section>
  );

};
