//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

/// <reference types="react-scripts" />

declare namespace NodeJS {

  interface ProcessEnv {
    REACT_APP_CLIENT_URL: string;
    REACT_APP_SERVER_URL: string;
  }

}
