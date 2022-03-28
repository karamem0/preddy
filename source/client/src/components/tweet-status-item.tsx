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

import useBlobUrl from '../hooks/use-blob-url';

interface TweetStatusItemProps {
  statusId: number,
  userId: number,
  userName: string,
  screenName: string,
  text: string,
  tweetedAt: Date,
  profileImageUrl: string,
  statusUrl: string,
  userUrl: string,
  mediaUrl: string
}

const TweetStatusItem: React.FC<TweetStatusItemProps> = (props: TweetStatusItemProps) => {

  const {
    userName,
    screenName,
    text,
    tweetedAt,
    statusUrl,
    userUrl
  } = props;
  const profileImageUrl = useBlobUrl(props.profileImageUrl);
  const mediaUrl = useBlobUrl(props.mediaUrl);
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

export default TweetStatusItem;
