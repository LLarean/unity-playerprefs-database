using LLarean.PlayerPrefsDatabase.Runtime;
using NUnit.Framework;
using UnityEngine;

namespace LLarean.PlayerPrefsDatabase.Tests.Runtime
{
    [TestFixture]
    public class DatabaseTests
    {
        [SetUp]
        public void SetUp()
        {
            PlayerPrefs.DeleteAll();
        }

        public class TestData
        {
            public int value;
        }

        [Test]
        public void Save_And_Load_WorksCorrectly()
        {
            var data = new TestData { value = 42 };
            Database.Save("test_key", data);

            var loaded = Database.Load<TestData>("test_key");
            
            Assert.AreEqual(42, loaded.value);
        }

        [Test]
        public void Load_NonExistingKey_ReturnsNewInstance()
        {
            var loaded = Database.Load<TestData>("non_existing_key");
            
            Assert.IsNotNull(loaded);
            Assert.AreEqual(0, loaded.value);
        }

        [Test]
        public void Delete_RemovesKey()
        {
            var data = new TestData { value = 10 };
            Database.Save("delete_key", data);
            Database.Delete("delete_key");

            Assert.IsFalse(PlayerPrefs.HasKey("delete_key"));
        }

        [Test]
        public void Save_NullData_DoesNotSave()
        {
            Database.Save<TestData>("null_key", null);
            
            Assert.IsFalse(PlayerPrefs.HasKey("null_key"));
        }
    }
}