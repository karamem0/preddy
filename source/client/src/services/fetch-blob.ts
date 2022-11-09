//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

export async function fetchBlob (url: string): Promise<Blob | null> {
  const response = await fetch(url);
  if (response.ok) {
    return await response.blob();
  } else {
    return Promise.resolve(null);
  }
}
