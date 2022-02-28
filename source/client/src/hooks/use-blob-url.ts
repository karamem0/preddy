//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

import React from 'react';

import { fetchBlob } from '../services';

const useBlobUrl = (sourceUrl?: string): string | undefined => {

  const [ blobUrl, setBlobUrl ] = React.useState<string>();

  React.useEffect(() => {
    if (!sourceUrl) {
      return;
    }
    (async () => {
      const blob = await fetchBlob(sourceUrl);
      if (!blob) {
        return;
      }
      const value = URL.createObjectURL(blob);
      setBlobUrl((current) => {
        if (current) {
          URL.revokeObjectURL(current);
        }
        return value;
      });
    })();
  }, [ sourceUrl ]);

  return blobUrl;

};

export default useBlobUrl;
