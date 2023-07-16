using System.Collections.Generic;
using Repository;
using VContainer;

namespace SaveLoad
{
    public class SaveLoadManager
    {
        private readonly IObjectResolver _objectResolver;
        private ISaveLoadProgress[] _saveLoadProgresses;
        private readonly GameRepository _gameRepository;

        public SaveLoadManager(IObjectResolver objectResolver,GameRepository gameRepository)
        {
            _objectResolver = objectResolver;
            _gameRepository = gameRepository;
        }

        public void Save()
        {
            foreach (var listener in _objectResolver.Resolve<IEnumerable<ISaveLoadProgress>>())
            {
                listener.UpdateProgress(_gameRepository);
            }
            _gameRepository.SaveState();
        }

        public void Load()
        {
            foreach (var listener in _objectResolver.Resolve<IEnumerable<ISaveLoadProgress>>())
            {
                listener.LoadProgress(_gameRepository);
            }
        }
    }
}