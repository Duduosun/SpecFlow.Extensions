﻿using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

namespace SpecFlow.Extensions.Framework.ExtensionMethods
{
    [TestFixture]
    public class StringExtensionTests
    {
        [SetUp]
        public void ResetStringExtensionHashes()
        {
            StringExtension.TesterHash = string.Empty;
            StringExtension.FeatureHash = string.Empty;
            StringExtension.ScenarioHash = string.Empty;
        }


        [Test]
        public void StringExtensionCreatesHash()
        {
            Assert.AreEqual(2, StringExtension.GenerateRandomHash(2).Length);
            Assert.AreEqual(4, StringExtension.GenerateRandomHash(4).Length);
            Assert.AreEqual(6, StringExtension.GenerateRandomHash(6).Length);
        }

        [Test]
        public void StringExtensionAppendsHash()
        {
            string temp = "temp";

            Assert.IsTrue(temp.Randomize().Contains(DateTime.Now.ToString("-yyyyMMddHHmmss")));
        }

        [Test]
        public void StringExtensionAppendsShortHash()
        {
            string temp1 = "temp";
            string temp2 = temp1.RandomizeNoTimestamp();

            Assert.IsFalse(temp1.RandomizeNoTimestamp().Contains(DateTime.Now.ToString("-yyyyMMddHHmmss")));
            Assert.AreEqual(9, temp1.RandomizeNoTimestamp().Length, temp1);
            Assert.AreEqual(9, temp2.RandomizeNoTimestamp().Length, temp2);
            Assert.IsTrue(temp1 != temp2);
        }

        [Test]
        public void StringExtensionUpdatesHash()
        {
            List<string> hashes = new List<string>();

            for (int i = 0; i < 500; i++)
            {
                string temp = "temp";
                string temp1 = temp.Randomize();
                string temp2 = temp1.Randomize();

                hashes.Add(temp1);
                hashes.Add(temp2);

                Assert.AreEqual(temp1.Substring(0, 23), temp2.Substring(0, 23));
                Assert.AreNotEqual(temp1.Substring(23, 4), temp2.Substring(23, 4), string.Format("temp1:{0} temp2:{1}", temp1, temp2));
            }

            Assert.AreEqual(hashes.Count, hashes.Distinct().Count());
        }

        [Test]
        public void StringExtensionSetsHash()
        {
            string tester = "ELH";
            string test1 = "SESH";
            string test2 = "HSES";
            string temp = "temp";

            StringExtension.FeatureHash = test1;
            StringExtension.ScenarioHash = test2;

            Assert.IsTrue(temp.Randomize().StartsWith(string.Format("temp-{0}-{1}-", test1, test2)));

            StringExtension.TesterHash = tester;

            Assert.IsTrue(temp.Randomize().StartsWith(string.Format("temp-{0}-{1}-{2}-", tester, test1, test2)));

            StringExtension.FeatureHash = string.Empty;
            StringExtension.ScenarioHash = string.Empty;

            Assert.IsTrue(temp.Randomize().StartsWith(string.Format("temp-{0}-", tester)));
            

                        
        }
    }
}
