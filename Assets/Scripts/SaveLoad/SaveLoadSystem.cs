using System;
using Infrastructure;
using SaveLoad;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

public class SaveLoadSystem : MonoBehaviour
{
    [SerializeField]
    private SavePaths _savePaths;
    private ISaveLoadService _saveLoadService;
    private LoadLevel _loadLevel;

    [Inject]
    private void Construct(ISaveLoadService saveLoadService,LoadLevel loadLevel)
    {
        _saveLoadService = saveLoadService;
        _loadLevel = loadLevel;
    }

    private void Awake()
    {
        _loadLevel.CreateLoadedUnit();
    }
    
    [Button]
    public void Save()
    {
        _saveLoadService.SaveProgress(_savePaths);
    }
    
    [Button]
    public void Load()
    {
        _loadLevel.InformProgressReader();
    }
}
