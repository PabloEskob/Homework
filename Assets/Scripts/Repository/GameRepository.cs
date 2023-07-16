using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace Repository
{
    public class GameRepository : IGameRepository
    {
        private Dictionary<string, string> _gameState;

        public string GetData(string key)
        {
            return _gameState[key];
        }

        public bool TryGetData(string key, out string value)
        {
            return _gameState.TryGetValue(key, out value);
        }

        public void SetData(string key, string value)
        {
            _gameState[key] = value;
        }

        public void LoadState()
        {
            string path = Path.Combine(Application.streamingAssetsPath, "InitialData.json");

            if (File.Exists(path))
            {
                string jsonContent = File.ReadAllText(path);
                _gameState = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonContent);
            }
            else
            {
                _gameState = new Dictionary<string, string>();
            }
        }

        public void SaveState()
        {
            string path = Path.Combine(Application.streamingAssetsPath, "InitialData.json");
            string serializedState = JsonConvert.SerializeObject(_gameState);
            File.WriteAllText(path, serializedState);
        }
    }
}