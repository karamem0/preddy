//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

import {
  createMapper,
  createMap,
  forMember,
  mapFrom
} from '@automapper/core';
import { pojos, PojosMetadataMap } from '@automapper/pojos';

import {
  TweetStatus,
  TweetStatusDto,
  TweetStatusItem,
  TweetStatusItemDto
} from '../types/tweet-status';

const mapper = createMapper({
  strategyInitializer: pojos()
});

PojosMetadataMap.create<TweetStatus>(
  'TweetStatus',
  {
    minDate: Date,
    maxDate: Date,
    items: 'TweetStatusItem'
  });

PojosMetadataMap.create<TweetStatusItem>(
  'TweetStatusItem',
  {
    statusId: Number,
    userId: Number,
    userName: String,
    screenName: String,
    text: String,
    tweetedAt: Date,
    profileImageUrl: String,
    statusUrl: String,
    userUrl: String,
    mediaUrl: String
  });

PojosMetadataMap.create<TweetStatusDto>(
  'TweetStatusDto',
  {
    minDate: String,
    maxDate: String,
    items: 'TweetStatusItemDto'
  });

PojosMetadataMap.create<TweetStatusItemDto>(
  'TweetStatusItemDto',
  {
    statusId: Number,
    userId: Number,
    userName: String,
    screenName: String,
    text: String,
    tweetedAt: String,
    profileImageUrl: String,
    statusUrl: String,
    userUrl: String,
    mediaUrl: String
  });

createMap<TweetStatusDto, TweetStatus>(
  mapper,
  'TweetStatusDto',
  'TweetStatus',
  forMember(
    d => d.minDate,
    mapFrom(s => new Date(s.minDate))
  ),
  forMember(
    d => d.maxDate,
    mapFrom(s => new Date(s.maxDate))
  )
);

createMap<TweetStatusItemDto, TweetStatusItem>(
  mapper,
  'TweetStatusItemDto',
  'TweetStatusItem',
  forMember(
    d => d.tweetedAt,
    mapFrom(s => new Date(s.tweetedAt))
  )
);

export async function fetchTweetStatus (minDate: Date, maxDate: Date): Promise<TweetStatus> {
  const response = await fetch(
    '/api/tweetstatus' +
    `?mindate=${minDate.toISOString()}` +
    `&maxdate=${maxDate.toISOString()}`
  );
  if (response.ok) {
    const json = await response.json();
    const data = json as TweetStatusDto;
    return mapper.map<TweetStatusDto, TweetStatus>(
      data,
      'TweetStatusDto',
      'TweetStatus'
    );
  } else {
    return Promise.reject(response.status);
  }
}
