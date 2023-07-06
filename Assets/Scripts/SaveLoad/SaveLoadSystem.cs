using Infrastructure;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

public class SaveLoadSystem : MonoBehaviour
{
    private ISaveLoadService _saveLoadService;
    
    [Inject]
    private void Construct(ISaveLoadService saveLoadService)
    {
        _saveLoadService = saveLoadService;
    }

    [Button]
    public void Save()
    {
        _saveLoadService.SaveProgress();
    }

    [Button]
    public void Load()
    {
        
    }
}
