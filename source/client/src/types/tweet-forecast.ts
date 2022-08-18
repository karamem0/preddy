//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

export interface TweetForecast {
  minDate: Date,
  maxDate: Date,
  items: TweetForecastItem[]
}

export interface TweetForecastItem {
  date: Date,
  count: number
}

export interface TweetForecastDto {
  minDate: string,
  maxDate: string,
  items: TweetForecastItemDto[]
}

export interface TweetForecastItemDto {
  date: string,
  count: number
}
