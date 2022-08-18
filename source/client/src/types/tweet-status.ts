//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

export interface TweetStatus {
  minDate: Date,
  maxDate: Date,
  items: TweetStatusItem[]
}

export interface TweetStatusItem {
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

export interface TweetStatusDto {
  minDate: string,
  maxDate: string,
  items: TweetStatusItemDto[]
}

export interface TweetStatusItemDto {
  statusId: number,
  userId: number,
  userName: string,
  screenName: string,
  text: string,
  tweetedAt: string,
  profileImageUrl: string,
  statusUrl: string,
  userUrl: string,
  mediaUrl: string
}
