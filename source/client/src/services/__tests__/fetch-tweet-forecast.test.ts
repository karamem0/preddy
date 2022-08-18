//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

import { fetchTweetForecast } from '../fetch-tweet-forecast';

describe('fetchTweetForecast', () => {

  it('return value if succeeded', () => {
    global.fetch = jest.fn().mockReturnValue(
      Promise.resolve({
        ok: true,
        json: jest.fn().mockReturnValue(Promise.resolve({}))
      } as unknown as Response));
    const params = {
      minDate: new Date('2021-01-01'),
      maxDate: new Date('2021-01-02')
    };
    const actual = fetchTweetForecast(params.minDate, params.maxDate);
    expect(actual).resolves.not.toBeUndefined();
  });

  it('throw error if failed', () => {
    global.fetch = jest.fn().mockReturnValue(
      Promise.resolve({
        ok: false,
        status: 500
      } as unknown as Response));
    const params = {
      minDate: new Date('2021-01-01'),
      maxDate: new Date('2021-01-02')
    };
    const actual = fetchTweetForecast(params.minDate, params.maxDate);
    expect(actual).rejects.toBe(500);
  });

});
