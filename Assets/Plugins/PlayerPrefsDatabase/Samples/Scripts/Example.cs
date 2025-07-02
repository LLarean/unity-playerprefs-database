using System;
using LLarean.PlayerPrefsDatabase.Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace LLarean.PlayerPrefsDatabase.Samples
{
    public class Example : MonoBehaviour
    {
        private const string Key = "UserData";
        
        [SerializeField] private Text _message;
        [SerializeField] private InputField _inputField;
        [Space]
        [SerializeField] private Button _save;
        [SerializeField] private Button _load;

        private void Start()
        {
            _save.onClick.AddListener(SaveData);
            _load.onClick.AddListener(LoadData);

            LoadData();
        }

        private void OnDestroy()
        {
            _save.onClick.RemoveAllListeners();
            _load.onClick.RemoveAllListeners();
        }

        private void SaveData()
        {
            var profile = new UserData
            {
                Message = _inputField.text
            };
            
            Database.Save(Key, profile);
        }

        private void LoadData()
        {
            var profile = Database.Load<UserData>(Key);
            
            _message.text = profile.Message;
        }
    }
    
    [Serializable]
    public class UserData
    {
        public string Message;
    }
}