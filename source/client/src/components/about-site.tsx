//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

import React from 'react';

import { FormattedMessage, useIntl } from 'react-intl';
import messages from '../i18n/messages';

const AboutSite: React.FC = () => {

  const intl = useIntl();

  return (
    <section className="about-site">
      <h2 className="title">
        <FormattedMessage {...messages.ABOUT_SITE_TITLE} />
      </h2>
      <div className="content">
        <p>
          <a href={intl.formatMessage(messages.ABOUT_SITE_WIKIPEDIA_URL)}>
            <FormattedMessage {...messages.ABOUT_SITE_WIKIPEDIA_TITLE} />
          </a>
        </p>
        <p>
          <FormattedMessage {...messages.ABOUT_SITE_DESCRIPTION} />
        </p>
        <p>
          <FormattedMessage
            {...messages.ABOUT_SITE_CONTACT}
            values={{
              twitter: (
                <a href={intl.formatMessage(messages.APP_TWITTER_URL)}>
                  <FormattedMessage {...messages.APP_TWITTER_USERNAME} />
                </a>)
            }} />
        </p>
      </div>
    </section>
  );

};

export default AboutSite;
