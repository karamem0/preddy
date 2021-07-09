//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/master/LICENSE
//

import { defineMessages } from 'react-intl';

const messages = defineMessages({
  APP_TITLE: {
    id: 'APP_TITLE',
    defaultMessage: 'ドクターイエロー運行予測'
  },
  APP_DESCRIPTION: {
    id: 'APP_DESCRIPTION',
    defaultMessage: 'ドクターイエローに関するつぶやきから次の運行日を予測します。'
  },
  APP_GITHUB_URL: {
    id: 'APP_GITHUB_URL',
    defaultMessage: 'https://github.com/karamem0/preddy'
  },
  APP_TWITTER_URL: {
    id: 'APP_TWITTER_URL',
    defaultMessage: 'https://twitter.com/karamem0'
  },
  APP_TWITTER_USERNAME: {
    id: 'APP_TWITTER_USERNAME',
    defaultMessage: '@karamem0'
  },
  APP_LOADING: {
    id: 'APP_LOADING',
    defaultMessage: '読み込み中...'
  },
  APP_NODATA: {
    id: 'APP_NODATA',
    defaultMessage: '表示するデータがありません。'
  },
  TWEET_SUMMARY_TITLE: {
    id: 'TWEET_SUMMARY_TITLE',
    defaultMessage: 'ツイートの予測と結果'
  },
  TWEET_SUMMARY_PERIOD: {
    id: 'TWEET_SUMMARY_PERIOD',
    defaultMessage: '期間'
  },
  TWEET_SUMMARY_FORECAST: {
    id: 'TWEET_SUMMARY_FORECAST',
    defaultMessage: '予測'
  },
  TWEET_SUMMARY_ACTUAL: {
    id: 'TWEET_SUMMARY_ACTUAL',
    defaultMessage: '結果'
  },
  TWEET_SUMMARY_PREV: {
    id: 'TWEET_SUMMARY_PREV',
    defaultMessage: '前'
  },
  TWEET_SUMMARY_NEXT: {
    id: 'TWEET_SUMMARY_NEXT',
    defaultMessage: '次'
  },
  TWEET_SUMMARY_TODAY: {
    id: 'TWEET_SUMMARY_TODAY',
    defaultMessage: '今日'
  },
  TWEET_STATUS_TITLE: {
    id: 'TWEET_STATUS_TITLE',
    defaultMessage: 'ツイートの詳細'
  },
  TWEET_STATUS_DESCRIPTION_NOT_SELECTED: {
    id: 'TWEET_STATUS_DESCRIPTION_NOT_SELECTED',
    defaultMessage: 'グラフの点をクリックするとツイートの詳細を表示します。'
  },
  TWEET_STATUS_DESCRIPTION_SELECTED: {
    id: 'TWEET_STATUS_DESCRIPTION_SELECTED',
    defaultMessage: '{date} のツイートを表示します。'
  },
  ABOUT_SITE_TITLE: {
    id: 'ABOUT_SITE_TITLE',
    defaultMessage: 'このサイトについて'
  },
  ABOUT_SITE_WIKIPEDIA_URL: {
    id: 'ABOUT_SITE_WIKIPEDIA_URL',
    defaultMessage: 'https://ja.wikipedia.org/wiki/%E3%83%89%E3%82%AF%E3%82%BF%E3%83%BC%E3%82%A4%E3%82%A8%E3%83%AD%E3%83%BC'
  },
  ABOUT_SITE_WIKIPEDIA_TITLE: {
    id: 'ABOUT_SITE_WIKIPEDIA_TITLE',
    defaultMessage: 'ドクターイエロー - Wikipedia'
  },
  ABOUT_SITE_DESCRIPTION: {
    id: 'ABOUT_SITE_DESCRIPTION',
    defaultMessage: 'ドクターイエローの運行は 10 日に 1 回程度とされており、そのスケジュールは公開されていません。このサイトでは、Twitter からドクターイエローの目撃情報を集計し、これまでの運行実績から Azure Machine Learning による今後の運行予測を行います。'
  },
  ABOUT_SITE_CONTACT: {
    id: 'ABOUT_SITE_CONTACT',
    defaultMessage: 'このサイトについてのお問い合わせは {twitter} までお願いします。'
  }
});

export default messages;
