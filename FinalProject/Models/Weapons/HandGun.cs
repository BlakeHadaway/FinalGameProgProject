using FinalProject.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models.Weapons
{
    public class HandGun : Weapon
    {
        public HandGun()
        {
            cooldown = 0.7f;
            maxAmmo = 12;
            Ammo = maxAmmo;
            reloadTime = 1.2f;
        }

        protected override void CreateProjectiles(Player player)
        {
            ProjectileData projectileData = new()
            {
                Position = player.Position,
                Rotation = player.Rotation,
                Lifespan = 2f,
                Speed = 500
            };

            ProjectileManager.AddProjectile(projectileData);
        }
    }
}
