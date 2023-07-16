using Infrastructure;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

public class SaveLoadSystem : MonoBehaviour
{
    private LoadLevel _loadLevel;

    [Inject]
    private void Construct(LoadLevel loadLevel)
    {
        _loadLevel = loadLevel;
    }

    private void Awake()
    {
       _loadLevel.LoadAtStart();
    }

    [Button]
    public void Save()
    {
        _loadLevel.Save();
    }

    [Button]
    public void Load()
    {
        _loadLevel.InformProgressReader();
    }
}