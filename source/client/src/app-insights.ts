//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

import { ReactPlugin } from '@microsoft/applicationinsights-react-js';
import { ApplicationInsights } from '@microsoft/applicationinsights-web';

import { createBrowserHistory } from 'history';

const browserHistory = createBrowserHistory();

export const reactPlugin = new ReactPlugin();

export const appInsights = new ApplicationInsights({
  config: {
    instrumentationKey: process.env.REACT_APP_APP_INSIGHTS_INSTRUMENTATION_KEY,
    extensions: [ reactPlugin ],
    extensionConfig: {
      [reactPlugin.identifier]: { history: browserHistory }
    }
  }
});

appInsights.loadAppInsights();
