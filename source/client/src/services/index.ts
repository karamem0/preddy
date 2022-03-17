//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

interface TweetSummary {
  minDate: string,
  maxDate: string,
  items: {
    date: string,
    forecast: number,
    actual: number
  }[]
}

interface TweetStatus {
  items: {
    statusId: number,
    userId: number,
    userName: string,
    screenName: string,
    text: string,
    tweetedAt: string,
    profileImageUrl: string,
    statusUrl: string,
    userUrl: string,
    mediaUrl: string
  }[]
}

const fetchTweetSummary = async (minDate: Date, maxDate: Date): Promise<TweetSummary> => {
  const response = await fetch(
    `${process.env.REACT_APP_SERVER_URL}/tweetsummary` +
    `?mindate=${minDate.toISOString()}` +
    `&maxdate=${maxDate.toISOString()}`
  );
  if (response.ok) {
    const json = await response.json();
    const value = json as TweetSummary;
    return value;
  } else {
    return Promise.reject(response.status);
  }
};

const fetchTweetStatus = async (minDate: Date, maxDate: Date): Promise<TweetStatus> => {
  const response = await fetch(
    `${process.env.REACT_APP_SERVER_URL}/tweetstatus` +
    `?mindate=${minDate.toISOString()}` +
    `&maxdate=${maxDate.toISOString()}`
  );
  if (response.ok) {
    const json = await response.json();
    const value = json as TweetStatus;
    return value;
  } else {
    return Promise.reject(response.status);
  }
};

const fetchBlob = async (url: string): Promise<Blob | null> => {
  const response = await fetch(url);
  if (response.ok) {
    const blob = await response.blob();
    return blob;
  } else {
    return Promise.resolve(null);
  }
};

export {
  fetchTweetSummary,
  fetchTweetStatus,
  fetchBlob
};
