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
  TweetForecast,
  TweetForecastDto,
  TweetForecastItem,
  TweetForecastItemDto
} from '../types/tweet-forecast';

const mapper = createMapper({
  strategyInitializer: pojos()
});

PojosMetadataMap.create<TweetForecast>(
  'TweetForecast',
  {
    minDate: Date,
    maxDate: Date,
    items: 'TweetForecastItem'
  });

PojosMetadataMap.create<TweetForecastItem>(
  'TweetForecastItem',
  {
    date: Date,
    count: Number
  });

PojosMetadataMap.create<TweetForecastDto>(
  'TweetForecastDto',
  {
    minDate: String,
    maxDate: String,
    items: 'TweetForecastItemDto'
  });

PojosMetadataMap.create<TweetForecastItemDto>(
  'TweetForecastItemDto',
  {
    date: String,
    count: Number
  });

createMap<TweetForecastDto, TweetForecast>(
  mapper,
  'TweetForecastDto',
  'TweetForecast',
  forMember(
    d => d.minDate,
    mapFrom(s => new Date(s.minDate))
  ),
  forMember(
    d => d.maxDate,
    mapFrom(s => new Date(s.maxDate))
  )
);

createMap<TweetForecastItemDto, TweetForecastItem>(
  mapper,
  'TweetForecastItemDto',
  'TweetForecastItem',
  forMember(
    d => d.date,
    mapFrom(s => new Date(s.date))
  )
);

export async function fetchTweetForecast (minDate: Date, maxDate: Date): Promise<TweetForecast> {
  const response = await fetch(
    '/api/tweetforecast' +
    `?mindate=${minDate.toISOString()}` +
    `&maxdate=${maxDate.toISOString()}`
  );
  if (response.ok) {
    const json = await response.json();
    const data = json as TweetForecastDto;
    return mapper.map<TweetForecastDto, TweetForecast>(
      data,
      'TweetForecastDto',
      'TweetForecast'
    );
  } else {
    return Promise.reject(response.status);
  }
}
