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

import AppContext from '../contexts/app-context';
import useTweetStatus from '../hooks/use-tweet-status';
import messages from '../i18n/messages';

import TweetStatusItem from './tweet-status-item';

const TweetStatusContent: React.FC = () => {

  const intl = useIntl();
  const [ date ] = React.useContext(AppContext);
  const { value, loading } = useTweetStatus(date);

  if (!date) {
    return (
      <div className="content">
        <div className="description">
          <FormattedMessage {...messages.TWEET_STATUS_DESCRIPTION_NOT_SELECTED} />
        </div>
      </div>
    );
  }

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
        <FormattedMessage
          {...messages.TWEET_STATUS_DESCRIPTION_SELECTED}
          values={{
            date: intl.formatDate(
              date,
              {
                year: 'numeric',
                month: 'numeric',
                day: 'numeric'
              })
          }} />
      </div>
      <div className="list">
        {
          value.items.map(item => (
            <TweetStatusItem
              key={item.statusId}
              {...item} />
          ))
        }
      </div>
    </div>
  );

};

export default TweetStatusContent;
