//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/master/LICENSE
//

import React from 'react';

import { useIntl } from 'react-intl';
import messages from '../i18n/messages';

import { VscGithub } from 'react-icons/vsc';

const Footer: React.FC = () => {

  const intl = useIntl();

  return (
    <footer className="footer">
      <a href={intl.formatMessage(messages.APP_GITHUB_URL)}>
        <VscGithub className="github" />
      </a>
    </footer>
  );

};

export default Footer;
