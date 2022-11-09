//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

export interface TweetSummary {
  minDate: Date,
  maxDate: Date,
  items: TweetSummaryItem[]
}

export interface TweetSummaryItem {
  date: Date,
  forecast: number,
  actual: number
}

export interface TweetSummaryDto {
  minDate: string,
  maxDate: string,
  items: TweetSummaryItemDto[]
}

export interface TweetSummaryItemDto {
  date: string,
  forecast: number,
  actual: number
}
