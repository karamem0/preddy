//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

import React from 'react';

const AppContext = React.createContext<[
  date?: Date,
  setDate?: React.Dispatch<React.SetStateAction<Date | undefined>>,
]>([]);

export default AppContext;
