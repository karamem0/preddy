//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

import React from 'react';
import { IntlProvider } from 'react-intl';

import { Provider, teamsV2Theme } from '@fluentui/react-northstar';

import { withAITracking } from '@microsoft/applicationinsights-react-js';

import { reactPlugin } from '../app-insights';
import AppContext from '../contexts/app-context';
import translations from '../i18n/translations';

import Container from './container';

const App: React.FC = () => {

  const [ date, setDate ] = React.useState<Date>();
  const [ locale ] = React.useState<string>('ja');

  return (
    <AppContext.Provider value={[ date, setDate ]}>
      <IntlProvider
        locale={locale}
        messages={translations[locale]}>
        <Provider theme={teamsV2Theme}>
          <Container />
        </Provider>
      </IntlProvider>
    </AppContext.Provider>
  );

};

export default withAITracking(reactPlugin, App);
