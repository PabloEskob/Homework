using Infrastructure;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

public class SaveLoadSystem : MonoBehaviour
{
    private ISaveLoadService _saveLoadService;
    private LoadLevel _loadLevel;
    
    [Inject]
    private void Construct(ISaveLoadService saveLoadService,LoadLevel loadLevel)
    {
        _saveLoadService = saveLoadService;
        _loadLevel = loadLevel;
    }

    [Button]
    public void Save()
    {
        _saveLoadService.SaveProgress();
    }

    [Button]
    public void Load()
    {
        _loadLevel.InformProgressReader();
    }
}
