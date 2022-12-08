using FinalProject.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models.Weapons
{
    public class SniperRifle : Weapon
    {
        public SniperRifle()
        {
            cooldown = 2.1f;
            maxAmmo = 5;
            Ammo = maxAmmo;
            reloadTime = 3.5f;
        }

        protected override void CreateProjectiles(Player player)
        {
            ProjectileData projectileData = new()
            {
                Position = player.Position,
                Rotation = player.Rotation,
                Lifespan = 2f,
                Speed = 800

            };

            ProjectileManager.AddProjectile(projectileData);
        }
    }
}
