//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

import React from 'react';

import AboutSite from './about-site';
import Footer from './footer';
import Header from './header';
import TweetStatus from './tweet-status';
import TweetSumamry from './tweet-summary';

const Container: React.FC = () => {

  return (
    <div className="container">
      <Header />
      <TweetSumamry />
      <TweetStatus />
      <AboutSite />
      <Footer />
    </div>
  );

};

export default Container;
