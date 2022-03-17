//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

import React from 'react';
import { useIntl } from 'react-intl';

import { Text } from '@fluentui/react-northstar';

import { VscGithub } from 'react-icons/vsc';

import messages from '../i18n/messages';

const Footer: React.FC = () => {

  const intl = useIntl();

  return (
    <footer className="footer">
      <div className="github">
        <a href={intl.formatMessage(messages.APP_GITHUB_URL)}>
          <VscGithub />
        </a>
      </div>
      <div className="contract">
        <a href={intl.formatMessage(messages.TERMS_OF_USE_URL)}>
          <Text content={intl.formatMessage(messages.TERMS_OF_USE_TITLE)} />
        </a>
        <Text content="|" />
        <a href={intl.formatMessage(messages.PRIVACY_URL)}>
          <Text content={intl.formatMessage(messages.PRIVACY_TITLE)} />
        </a>
      </div>
    </footer>
  );

};

export default Footer;
