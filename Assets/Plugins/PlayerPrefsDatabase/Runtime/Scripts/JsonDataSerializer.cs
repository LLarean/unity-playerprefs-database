using System;
using UnityEngine;

namespace LLarean.PlayerPrefsDatabase.Runtime
{
    public abstract class JsonDataSerializer
    {
        public static string Serialize<T>(T data)
        {
            try
            {
                return JsonUtility.ToJson(data);
            }
            catch (ArgumentException e)
            {
                Debug.LogError($"Serialization error: {e.Message}");
                return null;
            }
        }

        public static T Deserialize<T>(string json)
        {
            try
            {
                return JsonUtility.FromJson<T>(json);
            }
            catch (ArgumentException e)
            {
                Debug.LogError($"Deserialization error: {e.Message}");
                return default;
            }
        }
    }
}
