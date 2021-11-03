﻿using NUnit.Framework;
using System.Collections.Generic;
using Tenray.Topaz.Utility;

namespace Tenray.Topaz.Test
{
    public class DictionaryTests
    {
        [Test]
        public void TestDictionary1()
        {
            var engine = new TopazEngine();
            dynamic model = new CaseSensitiveDynamicObject();
            engine.SetValue("model", model);
            var dic = new Dictionary<string, int>
            {
                { "a", 1 },
                { "b", 2 },
                { "c", 3 }
            };
            engine.SetValue("dic", dic);
            engine.ExecuteScript(@"
model.a1 = dic.a
model.a2 = dic['a']
dic.a = 3
model.a3 = dic.a
dic['a'] = 4
model.a4 = dic.a
model.a5 = dic.ContainsKey('b')
dic.Remove('b')
model.a6 = dic.ContainsKey('b')
");
            Assert.AreEqual(model.a1, 1);
            Assert.AreEqual(model.a2, 1);
            Assert.AreEqual(model.a3, 3);
            Assert.AreEqual(model.a4, 4);
            Assert.IsTrue(model.a5);
            Assert.IsFalse(model.a6);
        }
    }
}