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

import TweetStatusContent from './tweet-status-content';

const TweetStatus: React.FC = () => {

  return (
    <section className="tweet-status">
      <h2 className="title">
        <FormattedMessage {...messages.TWEET_STATUS_TITLE} />
      </h2>
      <TweetStatusContent />
    </section>
  );

};

export default TweetStatus;
