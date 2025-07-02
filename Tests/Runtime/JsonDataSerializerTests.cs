using System;
using LLarean.PlayerPrefsDatabase.Runtime;
using NUnit.Framework;

namespace LLarean.PlayerPrefsDatabase.Tests.Runtime
{
    public class JsonDataSerializerTests
    {
        [Serializable]
        private class TestData
        {
            public int intValue;
            public string stringValue;
        }
        
        [Serializable]
        private class NestedData
        {
            public TestData innerData;
        }

        [Test]
        public void Serialize_NestedObject_ReturnsJsonWithInnerData()
        {
            var nested = new NestedData { innerData = new TestData { intValue = 1, stringValue = "a" } };
            string json = JsonDataSerializer.Serialize(nested);
            
            Assert.IsTrue(json.Contains("innerData"));
            Assert.IsTrue(json.Contains("intValue"));
        }

        [Test]
        public void Serialize_ValidObject_ReturnsJsonString()
        {
            var data = new TestData { intValue = 42, stringValue = "test" };
            string json = JsonDataSerializer.Serialize(data);
         
            Assert.IsNotNull(json);
            Assert.IsTrue(json.Contains("intValue"));
            Assert.IsTrue(json.Contains("stringValue"));
        }

        [Test]
        public void Deserialize_ValidJson_ReturnsObject()
        {
            string json = "{\"intValue\":42,\"stringValue\":\"test\"}";
            var data = JsonDataSerializer.Deserialize<TestData>(json);
            
            Assert.IsNotNull(data);
            Assert.AreEqual(42, data.intValue);
            Assert.AreEqual("test", data.stringValue);
        }

        [Test]
        public void Serialize_NullObject_ReturnsJsonNull()
        {
            TestData data = null;
            string json = JsonDataSerializer.Serialize(data);
            
            Assert.IsNotNull(json); // JsonUtility.ToJson(null) returns "{}"
        }
        
        [Test]
        public void Deserialize_EmptyString_ReturnsNull()
        {
            var data = JsonDataSerializer.Deserialize<TestData>(string.Empty);
            Assert.IsNull(data);
        }
    }
}