//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

import React from 'react';

import { AboutSite } from './about-site';
import { Footer } from './footer';
import { Header } from './header';
import { TweetForecast } from './tweet-forecast';
import { TweetStatus } from './tweet-status';
import { TweetSumamry } from './tweet-summary';

export const Container: React.FC = () => {

  return (
    <div className="container">
      <Header />
      <TweetForecast />
      <TweetSumamry />
      <TweetStatus />
      <AboutSite />
      <Footer />
    </div>
  );

};
