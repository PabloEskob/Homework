using Homework.Homework_v2.Scripts.Bullets;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Homework.Homework_v2.Scripts.Components
{
    public sealed class FireComponent
    {
        private readonly WeaponComponent _weaponComponent;
        private readonly BulletSystem _bulletSystem;
        private readonly BulletConfig _bulletConfig;

        public FireComponent(WeaponComponent weaponComponent, BulletSystem bulletSystem, BulletConfig bulletConfig)
        {
            _weaponComponent = weaponComponent;
            _bulletSystem = bulletSystem;
            _bulletConfig = bulletConfig;
        }

        public void OnFlyBullet(InputAction.CallbackContext callbackContext)
        {
            _bulletSystem.FlyBulletByArgs(new BulletSystem.Args
            {
                isPlayer = true,
                physicsLayer = (int)_bulletConfig.physicsLayer,
                color = _bulletConfig.color,
                damage = _bulletConfig.damage,
                position = _weaponComponent.Position,
                velocity = _weaponComponent.Rotation * Vector3.up * this._bulletConfig.speed
            });
        }
    }
}