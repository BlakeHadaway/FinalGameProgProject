/*
 * Weapon.cs
 * Outbreak game
 * Revision History
 *      
 * 
 * 
 * 
 * 
 */
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    /// <summary>
    /// public abstract weapon class is made so that if we are going 
    /// to make weapons we can inherit from this class and change 
    /// the reload times, amount of ammo, and all the sounds of the gun
    /// within the new class inheriting from weapon. that is why most things
    /// inside this class are virtual so the child classes can use them too 
    /// </summary>
    public abstract class Weapon
    {
        // Sound effect for the gun shooting
        public SoundEffect GunShot { get; set; }

        // Sound effect for realoding 
        public SoundEffect ReloadSound { get; set; }

        // Sound for a 2nd reload sound for specific guns 
        public SoundEffect ReloadSound2 { get; set; }

        // float for firing time 
        protected float cooldown;

        // float for time left is firing time 
        protected float cooldownLeft;

        // int to set the max ammo a gun has in a mag
        public int maxAmmo;

        // int for the ammo left in the mag
        public int Ammo { get; protected set; }

        // float that we set using our cooldownleft to be the time left 
        // in a reload 
        protected float reloadTime;

        // bool for if the user is reloading 
        public bool Reloading { get; protected set; }

        // initialzing the weapon to not be reloading and to have no reload time 
        // ongoing 
        protected Weapon()
        {
            cooldownLeft = 0f;
            Reloading = false;
        }

        /// <summary>
        /// method called when we are going to reload, if the bool reloading is true or the current ammo 
        /// equals the max amount in the mag then return or, cooldownLeft is being set to reloadtime so it will keep counting 
        /// down and then reloading bool being set to true and playing the gun reload sound and if the sniper is equiped bool is 
        /// true then add the extra reloading sound 
        /// </summary>
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

        /// <summary>
        /// protected abstract void for creating projectiles taking player so that later
        /// it can be called to actually create the projectile 
        /// </summary>
        /// <param name="player"></param>
        protected abstract void CreateProjectiles(Player player);

        /// <summary>
        /// fire method, if the cooldown left is greater than zero or reloading then return so it cannot fire
        /// or if not take ammo away when a shot is fired and then if current ammo is greater than zero cooldownleft equals
        /// cooldown basically making a cooldown between shots so guns can fire slow or fast depending on what the weapons 
        /// given cooldown is, else reload. Play gunshot sound and change its volume to be lower then finally create the projectile
        /// using the player so the bullet comes from them.
        /// </summary>
        /// <param name="player"></param>
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

        /// <summary>
        /// update, makes it so if cooldownleft is still not zero then make it tick down
        /// else if reloading change reloading to false. 
        /// </summary>
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

