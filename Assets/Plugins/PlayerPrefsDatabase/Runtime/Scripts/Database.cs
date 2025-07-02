using UnityEngine;

namespace LLarean.PlayerPrefsDatabase.Runtime
{
    public abstract class Database
    { 
        public static void Save<T>(string key, T data)
        {
            if (data == null)
            {
                PlayerPrefs.DeleteKey(key);
                return;
            }
            
            var json = JsonUtility.ToJson(data);
            PlayerPrefs.SetString(key, json);
        }

        public static T Load<T>(string key) where T : new()
        {
            if (!PlayerPrefs.HasKey(key)) return new T();
            
            string json = PlayerPrefs.GetString(key);
            return JsonDataSerializer.Deserialize<T>(json);
        }

        public static void Delete(string key)
        {
            PlayerPrefs.DeleteKey(key);
        }
    }
}