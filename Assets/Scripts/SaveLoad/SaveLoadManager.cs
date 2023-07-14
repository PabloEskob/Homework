using System.Collections.Generic;
using Data;
using VContainer;

namespace SaveLoad
{
    public class SaveLoadManager
    {
        private readonly IObjectResolver _objectResolver;
        private ISaveLoadProgress[] _saveLoadProgresses;

        public SaveLoadManager(IObjectResolver objectResolver)
        {
            _objectResolver = objectResolver;
        }

        public void Save(WorldProgress progressServiceWorldProgress)
        {
            foreach (var listener in _objectResolver.Resolve<IEnumerable<ISaveLoadProgress>>())
            {
                listener.UpdateProgress(progressServiceWorldProgress);
            }
        }

        public void Load(WorldProgress progressServiceWorldProgress)
        {
            foreach (var listener in _objectResolver.Resolve<IEnumerable<ISaveLoadProgress>>())
            {
                listener.LoadProgress(progressServiceWorldProgress);
            }
        }
    }
}