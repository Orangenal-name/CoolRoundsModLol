using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace CoolRoundsModLol.MonoBehaviours
{
    class LastBulletMono
    {
        private Gun gun;
        private GunAmmo gunAmmo;
        private CharacterData data;
        private WeaponHandler weaponHandler;
        private Player player;

        private void Start()
        {
            data = data.GetComponentInParent<CharacterData>();
        }


        private void Update()
        {
            if (!player)
            {
                if (!(data is null))
                {
                    player = data.player;
                    weaponHandler = data.weaponHandler;
                    gun = weaponHandler.gun;
                    gun.ShootPojectileAction += OnShootProjectileAction;
                }
            }
        }

        private void OnShootProjectileAction(GameObject obj)
        {
            Debug.Log("TEST lol");
        }
    }
}
