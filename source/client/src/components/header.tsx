//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

import React from 'react';
import { FormattedMessage, useIntl } from 'react-intl';
import {
  FacebookIcon,
  FacebookShareButton,
  TwitterIcon,
  TwitterShareButton
} from 'react-share';

import messages from '../i18n/messages';

const Header: React.FC = () => {

  const intl = useIntl();

  return (
    <header className="header">
      <h1 className="title">
        <FormattedMessage {...messages.APP_TITLE} />
      </h1>
      <div className="description">
        <FormattedMessage {...messages.APP_DESCRIPTION} />
      </div>
      <div className="share">
        <FacebookShareButton
          title={intl.formatMessage(messages.APP_TITLE)}
          url={process.env.REACT_APP_CLIENT_URL}>
          <FacebookIcon
            round
            size={24}
          />
        </FacebookShareButton>
        <TwitterShareButton
          title={intl.formatMessage(messages.APP_TITLE)}
          url={process.env.REACT_APP_CLIENT_URL}>
          <TwitterIcon
            round
            size={24}
          />
        </TwitterShareButton>
      </div>
    </header>
  );

};

export default Header;
