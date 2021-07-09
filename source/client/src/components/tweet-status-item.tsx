//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/master/LICENSE
//

import React from 'react';

import { Avatar } from '@fluentui/react-northstar';
import linkifyHtml from 'linkifyjs/html';

import useBlobUrl from '../hooks/use-blob-url';
import { useIntl } from 'react-intl';

interface TweetStatusItemProps {
  statusId: number;
  userId: number;
  userName: string;
  screenName: string;
  text: string;
  tweetedAt: Date;
  profileImageUrl: string;
  statusUrl: string;
  userUrl: string;
  mediaUrl: string;
}

const TweetStatusItem: React.FC<TweetStatusItemProps> = (props: TweetStatusItemProps) => {

  const {
    userName,
    screenName,
    text,
    tweetedAt
  } = props;
  const profileImageUrl = useBlobUrl(props.profileImageUrl);
  const intl = useIntl();

  return (
    <div className="item">
      <div className="image">
        <Avatar
          image={profileImageUrl}
          size="large" />
      </div>
      <div className="header">
        <span className="username">{userName}</span>
        <span className="screenname">{screenName}</span>
        <span className="tweetedat">
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
        </span>
      </div>
      <div className="text">
        <span dangerouslySetInnerHTML={{ __html: linkifyHtml(text, { target: '_blank' }) }}></span>
      </div>
    </div>
  );

};

export default TweetStatusItem;
