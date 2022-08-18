//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

import React from 'react';
import { useIntl } from 'react-intl';

import { Avatar, Image } from '@fluentui/react-northstar';

import linkifyHtml from 'linkifyjs/html';

import { useObjectUrl } from '../hooks/use-object-url';
import { TweetStatusItem } from '../types/tweet-status';

interface TweetStatusCardProps {
  item: TweetStatusItem
}

export const TweetStatusCard: React.FC<TweetStatusCardProps> = (props) => {

  const {
    userName,
    screenName,
    text,
    tweetedAt,
    statusUrl,
    userUrl
  } = props.item;
  const profileImageUrl = useObjectUrl(props.item.profileImageUrl);
  const mediaUrl = useObjectUrl(props.item.mediaUrl);
  const intl = useIntl();

  return (
    <div className="item">
      <div className="profile-image">
        <Avatar
          image={profileImageUrl}
          size="large" />
      </div>
      <div className="header">
        <a
          className="user-name"
          href={userUrl}>
          {userName}
        </a>
        <span className="screen-name">{screenName}</span>
        <a
          className="tweeted-at"
          href={statusUrl}>
          {
            intl.formatDate(new Date(tweetedAt.toLocaleString()), {
              year: 'numeric',
              month: 'numeric',
              day: 'numeric',
              hour: 'numeric',
              minute: 'numeric',
              second: 'numeric'
            })
          }
        </a>
      </div>
      <div className="text">
        <span dangerouslySetInnerHTML={{ __html: linkifyHtml(text, { target: '_blank' }) }}></span>
      </div>
      <div className="media">
        <Image
          fluid
          src={mediaUrl} />
      </div>
    </div>
  );

};
