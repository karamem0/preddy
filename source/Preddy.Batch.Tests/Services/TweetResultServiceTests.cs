﻿using Karemem0.Preddy.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karemem0.Preddy.Services.Tests {

    /// <summary>
    /// <see cref="Karemem0.Preddy.Services.TweetResultService"/> クラスをテストします。
    /// </summary>
    [TestClass()]
    public class TweetResultServiceTests {

        /// <summary>
        /// テスト クラスを初期化します。
        /// </summary>
        /// <param name="testContext"></param>
        [ClassInitialize()]
        public static void ClassInitialize(TestContext testContext) {
            AppDomain.CurrentDomain.SetData("DataDirectory", testContext.TestDeploymentDir);
            using (var dbContext = new DefaultConnectionContext()) {
                dbContext.Database.Delete();
                dbContext.Database.Create();
                dbContext.TweetLogs.AddOrUpdate(new[] {
                    new TweetLog() { Id = Guid.NewGuid(), StatusId = "1", TweetedAt = new DateTime(2015, 1, 1, 03, 0, 0), },
                    new TweetLog() { Id = Guid.NewGuid(), StatusId = "2", TweetedAt = new DateTime(2015, 1, 1, 10, 0, 0), },
                    new TweetLog() { Id = Guid.NewGuid(), StatusId = "3", TweetedAt = new DateTime(2015, 1, 2, 19, 0, 0), },
                });
                dbContext.TweetResults.AddOrUpdate(new[] {
                    new TweetResult() { Id = Guid.NewGuid(), Date = new DateTime(2015, 1, 1), },
                    new TweetResult() { Id = Guid.NewGuid(), Date = new DateTime(2015, 1, 2), },
                    new TweetResult() { Id = Guid.NewGuid(), Date = new DateTime(2015, 1, 3), },
                });
                dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// テスト クラスで使用されたリソースを解放します。
        /// </summary>
        [ClassCleanup()]
        public static void ClassCleanup() {
            using (var dbContext = new DefaultConnectionContext()) {
                dbContext.Database.Delete();
            }
        }

        /// <summary>
        /// <see cref="Karemem0.Preddy.Services.TweetResultService.Summarize"/> メソッドをテストします。
        /// </summary>
        [TestMethod()]
        public void SummarizeTest1() {
            var target = new TweetResultService();
            var actual = target.Summarize();
            foreach (var item in actual) {
                Debug.WriteLine(item);
            }
        }

        /// <summary>
        /// <see cref="Karemem0.Preddy.Services.TweetResultService.AddOrUpdate"/> メソッドをテストします。
        /// </summary>
        [TestMethod()]
        public void AddOrUpdateTest1() {
            var target = new TweetResultService();
            var actual = target.AddOrUpdate(new TweetResult() { Id = Guid.NewGuid(), Date = new DateTime(2015, 1, 4), });
            Assert.AreEqual(actual, true);
            using (var dbContext = new DefaultConnectionContext()) {
                foreach (var item in dbContext.TweetResults) {
                    Debug.WriteLine(item);
                }
            }
        }

        /// <summary>
        /// <see cref="Karemem0.Preddy.Services.TweetResultService.AddOrUpdate"/> メソッドをテストします。
        /// </summary>
        [TestMethod()]
        public void AddOrUpdateTest2() {
            var target = new TweetResultService();
            var actual = target.AddOrUpdate(new TweetResult() { Id = Guid.NewGuid(), Date = new DateTime(2015, 1, 3) });
            Assert.AreEqual(actual, true);
            using (var dbContext = new DefaultConnectionContext()) {
                foreach (var item in dbContext.TweetResults) {
                    Debug.WriteLine(item);
                }
            }
        }

    }

}