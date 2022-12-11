using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Managers;
using FinalProject.Models.Weapons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.MediaFoundation;
using static System.Net.Mime.MediaTypeNames;

namespace FinalProject.Models
{
    /// <summary>
    /// This is the player class, has all the players propeties
    /// inherits from ImageSprite for base properties
    /// </summary>
    public class Player : ImageSprite
    {
        // create a general weapon instance
        public Weapon Weapon { get; set; }

        // created readonly weapon instances of each of the weapon types
        private readonly Weapon _pistol = new HandGun();
        private readonly Weapon _smg = new MachineGun();
        private readonly Weapon _sniper = new SniperRifle();
        private readonly Weapon _lmg = new LightMachineGun();

        // using these 3 bools to check if the player has unlocked them
        // via points
        public static bool SMGUnlocked { get; set; } = false;
        public static bool SniperUnlocked { get; set; } = false;
        public static bool LMGUnlocked { get; set; } = false;

        // This if for the invicibilty frames the player gets when hit
        private float _invincibilityCooldownLeft;

        // number of lives for the user
        public int NumberOfLives { get; set; }
        
        // a bool and float for if the player is invincible and how long he/she will be
        public bool Invincibility { get; set; }
        public float _invincibilityTime;

        // bool to set if the player is dead
        public bool _dead;

        /// <summary>
        /// General Constructor, setting important values
        /// </summary>
        /// <param name="tex">Texture from ImageSprite</param>
        /// <param name="pos">Position from ImageSpriteClass</param>
        public Player(Texture2D tex, Vector2 pos) : base(tex, pos)
        {
            // have no cooldown on the invicibily, cause player isn't invicible
            _invincibilityCooldownLeft = 0f;
            NumberOfLives = 5;
            Invincibility = false;

            // time of invicibility
            _invincibilityTime = 3.5f;
            // setting the current weapon to be the starting pistol
            Weapon = _pistol;
        }

        /// <summary>
        /// This is the swap weapon fuction, it will use the scroll wheel index to switch weapons
        /// </summary>
        private void SwapWeapon()
        {
            // checking scrollIndex
            if (Shared.scrollIndex == 0)
            {
                // set the weapon to the pistol
                Weapon = _pistol;

                // setting this to make sure errors come from the snipers unique bullet
                // penetration and reload
                Shared.isSniperEquipped = false;
            }
            // checking scrollIndex
            else if (Shared.scrollIndex == 1)
            {
                // bool for if the weapon is unlocked
                if (SMGUnlocked)
                {
                    // if the smg is unlocked, set the current weapon to be the smg
                    Weapon = _smg;

                    // setting this to make sure errors come from the snipers unique bullet
                    // penetration and reload
                    Shared.isSniperEquipped = false;
                }
                else
                {
                    // setting scroll index back to starting position
                    Shared.scrollIndex = 0;

                    // reseting current weapon back to the pistol
                    Weapon = _pistol;
                }
            }
            else if (Shared.scrollIndex == 2)
            {
                // bool for if the weapon is unlocked
                if (SniperUnlocked)
                {
                    // if the sniper is unlocked, set the current weapon to be the sniper
                    Weapon = _sniper;
                    
                    // now setting this bool to be true, to get the bullet pen and unique reload sounds
                    Shared.isSniperEquipped = true;
                }
                else
                {
                    // setting scroll index back to starting position
                    Shared.scrollIndex = 0;

                    // setting this to make sure errors come from the snipers unique bullet
                    // penetration and reload
                    Shared.isSniperEquipped = false;

                    // reseting current weapon back to the pistol
                    Weapon = _pistol;
                }
            }
            else if (Shared.scrollIndex == 3)
            {
                // bool for if the weapon is unlocked
                if (LMGUnlocked)
                {
                    // if the Lmg is unlocked, set the current weapon to be the Lmg
                    Weapon = _lmg;

                    // setting this to make sure errors come from the snipers unique bullet
                    // penetration and reload
                    Shared.isSniperEquipped = false;
                }
                else
                {
                    // setting scroll index back to starting position
                    Shared.scrollIndex = 0;

                    // reseting current weapon back to the pistol
                    Weapon = _pistol;
                }
            }
        }

        /// <summary>
        /// This is the invicibilty frames fuction and will handle when the player can
        /// and cant be hit by zombies
        /// </summary>
        public void IFrames()
        {
            if (Invincibility)
                return;

            _invincibilityCooldownLeft = _invincibilityTime;
            Invincibility = true;
        }


        /// <summary>
        /// Update function to be called in the GameManager class
        /// </summary>
        public void Update()
        {
            // if there is still time left for the invicibilty
            if (_invincibilityCooldownLeft > 0)
            {
                // subracting ingame time until the if above doesn't execute
                _invincibilityCooldownLeft -= Shared.TotalSeconds;
            }
            else
            {
                // changing the inviciblity back to false, so the player can be hit again
                Invincibility = false;
            }

            // if the vector direction of the player is not the top left of the screen 
            if (InputManager.Direction != Vector2.Zero)
            {
                // this variable is getting the direction the player is moving in
                // we are creating this Vector2 var so that the player cannot go out of bounds
                // because this direction variable will be set to 0 if the vector is too small to be normalized
                var direction = Vector2.Normalize(InputManager.Direction);

                // restricting game movement to the game window, so then the character doesn't just walk off the screen
                // this is done by the built in fuction MathHelper.Clamp
                Position = new Vector2(
                    MathHelper.Clamp(Position.X + (direction.X * Speed * Shared.TotalSeconds), 0, Shared.Boundaries.X),
                    MathHelper.Clamp(Position.Y + (direction.Y * Speed * Shared.TotalSeconds), 0, Shared.Boundaries.Y)
                );
            }

            // Vector that is aimed at the players mouse
            var toMouse = InputManager.MousePosition - Position;

            // using the Atan2 fuction to use an angle to set the players rotation to be
            // in the direction of the mouse cursor
            Rotation = (float)Math.Atan2(toMouse.Y, toMouse.X);

            // calling the update fuction in Weapons class
            Weapon.Update();


            // Checking if the user is left clicking
            if (InputManager.MouseLeftDown)
            {
                Weapon.Fire(this);
            }

            // checking to see if the user is right clicking
            if (InputManager.MouseRightClicked)
            {
                Weapon.Reload();
            }

            // checking to see if the user is scrolling up
            if (InputManager.ScrollWheelUp)
            {
                // if scroll index is at its starting position
                if (Shared.scrollIndex == 0)
                {
                    // check to see what weapon it should change to
                    if (LMGUnlocked)
                    {
                        Shared.scrollIndex = 3;
                    }
                    else if (SniperUnlocked)
                    {
                        Shared.scrollIndex = 2;
                    }
                    else if (SMGUnlocked)
                    {
                        Shared.scrollIndex = 1;
                    }

                    //calling swap weapons method
                    SwapWeapon();
                }
                else
                {
                    // decreasing index of scrollindex
                    Shared.scrollIndex--;
                    
                    //calling swap weapons method
                    SwapWeapon();
                }

            }

            // checking to see if the user is scrolling down
            if (InputManager.ScrollWheelDown)
            {
                // if the scrollindex is at its max (because there is only 4 weapons)
                // includes 0
                if (Shared.scrollIndex == 3)
                {
                    // setting index back to the start
                    Shared.scrollIndex = 0;

                    // calling swap weapon method
                    SwapWeapon();
                }
                else if (Shared.scrollIndex == 2)
                {
                    if (LMGUnlocked)
                    {
                        // increasing index of scrollindex
                        Shared.scrollIndex++;

                        // calling swap weapon method
                        SwapWeapon();
                    }
                    else
                    {
                        // setting index back to the start
                        Shared.scrollIndex = 0;

                        // calling swap weapon method
                        SwapWeapon();
                    }
                }
                else if (Shared.scrollIndex == 1)
                {
                    if (SniperUnlocked)
                    {
                        // increasing index of scrollindex
                        Shared.scrollIndex++;

                        // calling swap weapon method
                        SwapWeapon();
                    }
                    else
                    {
                        // setting index back to the start
                        Shared.scrollIndex = 0;

                        // calling swap weapon method
                        SwapWeapon();
                    }
                }
                else
                {
                    if (SMGUnlocked)
                    {
                        // increasing index of scrollindex
                        Shared.scrollIndex++;

                        // calling swap weapon method
                        SwapWeapon();
                    }
                }
            }
        }

        /// <summary>
        /// This is a fuction to get the bounds of the player, to then be later
        /// used to handle collision with zombies
        /// </summary>
        /// <returns>This will return the rectangle of the player</returns>
        public Rectangle getBounds()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height);
        }
    }
}
