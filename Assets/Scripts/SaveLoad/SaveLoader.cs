using Newtonsoft.Json;
using Repository;

namespace SaveLoad
{
    public abstract class SaveLoader<TData, TService> : ISaveLoadProgress
    {
        private readonly TService _service;
        private string DataKey => typeof(TData).Name;

        protected SaveLoader(TService service)
        {
            _service = service;
        }

        public void UpdateProgress(IGameRepository gameRepository)
        {
            var data = ConvertToData(_service);
            var serializedData = JsonConvert.SerializeObject(data);
            gameRepository.SetData(DataKey, serializedData);
        }

        public void LoadProgress(IGameRepository gameRepository)
        {
            if (gameRepository.TryGetData(DataKey, out string serialized))
            {
                TData data = JsonConvert.DeserializeObject<TData>(serialized);
                SetupData(_service, data);
            }
            else
            {
                SetupByDefault(_service);
            }
        }

        public TData GetProgress(IGameRepository gameRepository)
        {
            if (gameRepository.TryGetData(DataKey, out string serialized))
            {
                TData data = JsonConvert.DeserializeObject<TData>(serialized);
                return data;
            }

            return default;
        }

        protected virtual void SetupByDefault(TService service)
        {
        }

        protected abstract TData ConvertToData(TService service);

        protected abstract void SetupData(TService service, TData data);
    }
}