//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/master/LICENSE
//

import React from 'react';

const AppContext = React.createContext<[
  date?: Date,
  setDate?: React.Dispatch<React.SetStateAction<Date | undefined>>,
]>([]);

export default AppContext;
