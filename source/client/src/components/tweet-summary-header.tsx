//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

import React from 'react';
import { useIntl } from 'react-intl';

import {
  ChevronLeftIcon,
  ChevronRightIcon,
  GotoTodayIcon
} from '@fluentui/react-icons-mdl2';
import { Button } from '@fluentui/react-northstar';

import AppContext from '../contexts/app-context';
import messages from '../i18n/messages';

interface TweetSummaryHeaderProps {
  minDate?: Date,
  maxDate?: Date,
  onToday?: () => void,
  onPrev?: () => void,
  onNext?: () => void
}

const TweetSummaryHeader: React.FC<TweetSummaryHeaderProps> = (props: TweetSummaryHeaderProps) => {

  const {
    minDate,
    maxDate,
    onToday,
    onPrev,
    onNext
  } = props;
  const [ , setDate ] = React.useContext(AppContext);
  const intl = useIntl();

  if (!minDate || !maxDate) {
    return null;
  }

  return (
    <div className="header">
      <div className="period">
        {
          (() => {
            const periodString = intl.formatMessage(messages.TWEET_SUMMARY_PERIOD);
            const minDateString = intl.formatDate(
              minDate,
              {
                year: 'numeric',
                month: 'numeric',
                day: 'numeric'
              });
            const maxDateString = intl.formatDate(
              maxDate,
              {
                year: 'numeric',
                month: 'numeric',
                day: 'numeric'
              });
            return `${periodString}: ${minDateString} - ${maxDateString}`;
          })()
        }
      </div>
      <div className="button">
        <Button
          icon={<GotoTodayIcon />}
          iconOnly
          size="small"
          title={intl.formatMessage(messages.TWEET_SUMMARY_TODAY)}
          onClick={() => {
            if (!setDate) {
              return;
            }
            if (!onToday) {
              return;
            }
            setDate(undefined);
            onToday();
          }}
        />
        <Button
          icon={<ChevronLeftIcon />}
          iconOnly
          size="small"
          title={intl.formatMessage(messages.TWEET_SUMMARY_PREV)}
          onClick={() => {
            if (!setDate) {
              return;
            }
            if (!onPrev) {
              return;
            }
            setDate(undefined);
            onPrev();
          }}
        />
        <Button
          icon={<ChevronRightIcon />}
          iconOnly
          size="small"
          title={intl.formatMessage(messages.TWEET_SUMMARY_NEXT)}
          onClick={() => {
            if (!setDate) {
              return;
            }
            if (!onNext) {
              return;
            }
            setDate(undefined);
            onNext();
          }}
        />
      </div>
    </div>
  );

};

export default TweetSummaryHeader;
