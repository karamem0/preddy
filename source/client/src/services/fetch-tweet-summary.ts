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
  TweetSummary,
  TweetSummaryDto,
  TweetSummaryItem,
  TweetSummaryItemDto
} from '../types/tweet-summary';

const mapper = createMapper({
  strategyInitializer: pojos()
});

PojosMetadataMap.create<TweetSummary>(
  'TweetSummary',
  {
    minDate: Date,
    maxDate: Date,
    items: 'TweetSummaryItem'
  });

PojosMetadataMap.create<TweetSummaryItem>(
  'TweetSummaryItem',
  {
    date: Date,
    forecast: Number,
    actual: Number
  });

PojosMetadataMap.create<TweetSummaryDto>(
  'TweetSummaryDto',
  {
    minDate: String,
    maxDate: String,
    items: 'TweetSummaryItemDto'
  });

PojosMetadataMap.create<TweetSummaryItemDto>(
  'TweetSummaryItemDto',
  {
    date: String,
    forecast: Number,
    actual: Number
  });

createMap<TweetSummaryDto, TweetSummary>(
  mapper,
  'TweetSummaryDto',
  'TweetSummary',
  forMember(
    d => d.minDate,
    mapFrom(s => new Date(s.minDate))
  ),
  forMember(
    d => d.maxDate,
    mapFrom(s => new Date(s.maxDate))
  )
);

createMap<TweetSummaryItemDto, TweetSummaryItem>(
  mapper,
  'TweetSummaryItemDto',
  'TweetSummaryItem',
  forMember(
    d => d.date,
    mapFrom(s => new Date(s.date))
  )
);

export async function fetchTweetSummary (minDate: Date, maxDate: Date): Promise<TweetSummary> {
  const response = await fetch(
    '/api/tweetsummary' +
    `?mindate=${minDate.toISOString()}` +
    `&maxdate=${maxDate.toISOString()}`
  );
  if (response.ok) {
    const json = await response.json();
    const data = json as TweetSummaryDto;
    return mapper.map<TweetSummaryDto, TweetSummary>(
      data,
      'TweetSummaryDto',
      'TweetSummary'
    );
  } else {
    return Promise.reject(response.status);
  }
}
