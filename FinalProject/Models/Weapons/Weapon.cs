using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public abstract class Weapon
    {
        public SoundEffect GunShot { get; set; }
        public SoundEffect ReloadSound { get; set; }
        public SoundEffect ReloadSound2 { get; set; }

        protected float cooldown;
        protected float cooldownLeft;
        public int maxAmmo;
        public int Ammo { get; protected set; }
        protected float reloadTime;
        public bool Reloading { get; protected set; }

        protected Weapon()
        {
            cooldownLeft = 0f;
            Reloading = false;
        }

        public virtual void Reload()
        {
            if (Reloading || (Ammo == maxAmmo))
                return;

            cooldownLeft = reloadTime;
            Reloading = true;
            Ammo = maxAmmo;
            ReloadSound.Play();
            if (Shared.isSniperEquipped)
            {
                ReloadSound2.Play();
            }
        }

        protected abstract void CreateProjectiles(Player player);

        public virtual void Fire(Player player)
        {
            if (cooldownLeft > 0 || Reloading)
                return;

            Ammo--;
            if (Ammo > 0)
            {
                cooldownLeft = cooldown;
            }
            else
            {
                Reload();
            }

            GunShot.Play(volume: 0.2f, pitch: 0.0f, pan: 0.0f);



            CreateProjectiles(player);
        }

        public virtual void Update()
        {
            if (cooldownLeft > 0)
            {
                cooldownLeft -= Shared.TotalSeconds;
            }
            else if (Reloading)
            {
                Reloading = false;
            }
        }
    }
}

