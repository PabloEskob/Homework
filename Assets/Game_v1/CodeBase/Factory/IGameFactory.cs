﻿using Game_v1.CodeBase.Services.ServiceLocator;
using UnityEngine;

namespace Game_v1.CodeBase.Factory
{
    public interface IGameFactory: IService
    {
        GameObject CreatePlayer(Vector3 at);
        GameObject CreateEnemy();
    }
}