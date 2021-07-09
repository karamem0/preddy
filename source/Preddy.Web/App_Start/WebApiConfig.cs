﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;

namespace Karemem0.Preddy {

    /// <summary>
    /// アプリケーションの Web API の設定を構成します。
    /// </summary>
    public static class WebApiConfig {

        /// <summary>
        /// アプリケーションの Web API の設定を登録します。
        /// </summary>
        /// <param name="config">
        /// HTTP サーバーの構成を格納する <see cref="System.Web.Http.HttpConfiguration"/>。
        /// </param>
        public static void Register(HttpConfiguration config) {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                "GetTweetSummary",
                "api/summary",
                new { Controller = "TweetSummary", Action = "GetTweetSummary" }
            );
            config.Routes.MapHttpRoute(
                "GetTweetLog",
                "api/log",
                new { Controller = "TweetLog", Action = "GetTweetLog" }
            );
            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{Controller}/{Id}",
                new { Id = RouteParameter.Optional }
            );
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }

    }

}
