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
    public class Player : ImageSprite
    {
        public Weapon Weapon { get; set; }
        private readonly Weapon _pistol = new HandGun();
        private readonly Weapon _smg = new MachineGun();
        private readonly Weapon _sniper = new SniperRifle();
        private readonly Weapon _lmg = new LightMachineGun();

        public static bool SMGUnlocked { get; set; } = false;
        public static bool SniperUnlocked { get; set; } = false;
        public static bool LMGUnlocked { get; set; } = false;

        private float _invincibilityCooldownLeft;
        public int NumberOfLives { get; set; }
        public bool Invincibility { get; set; }
        public float _invincibilityTime;
        public bool _dead;

        public Player(Texture2D tex, Vector2 pos) : base(tex, pos)
        {
            _invincibilityCooldownLeft = 0f;
            NumberOfLives = 5;
            Invincibility = false;
            _invincibilityTime = 3.5f;
            Weapon = _pistol;
        }

        private void SwapWeapon()
        {
            if (Shared.scrollIndex == 0)
            {
                Shared.isSniperEquipped = false;
                Weapon = _pistol;
            }
            else if (Shared.scrollIndex == 1)
            {
                if (SMGUnlocked)
                {
                    Weapon = _smg;
                    Shared.isSniperEquipped = false;
                }
                else
                {
                    Shared.scrollIndex = 0;
                    Weapon = _pistol;
                }
            }
            else if (Shared.scrollIndex == 2)
            {
                if (SniperUnlocked)
                {
                    Weapon = _sniper;
                    Shared.isSniperEquipped = true;
                }
                else
                {
                    Shared.scrollIndex = 0;
                    Shared.isSniperEquipped = false;
                    Weapon = _pistol;
                }
            }
            else if (Shared.scrollIndex == 3)
            {
                if (LMGUnlocked)
                {
                    Weapon = _lmg;
                    Shared.isSniperEquipped = false;
                }
                else
                {
                    Shared.scrollIndex = 0;
                    Weapon = _pistol;
                }
            }
        }

        public void IFrames()
        {
            if (Invincibility)
                return;

            _invincibilityCooldownLeft = _invincibilityTime;
            Invincibility = true;
        }

        public void Update()
        {
            if (_invincibilityCooldownLeft > 0)
            {
                _invincibilityCooldownLeft -= Shared.TotalSeconds;
            }
            else
            {
                Invincibility = false;
            }

            if (InputManager.Direction != Vector2.Zero)
            {
                var direction = Vector2.Normalize(InputManager.Direction);

                // restricting game movement to the game window, so then the character doesn't just walk off the screen
                Position = new Vector2(
                    MathHelper.Clamp(Position.X + (direction.X * Speed * Shared.TotalSeconds), 0, Shared.Boundaries.X),
                    MathHelper.Clamp(Position.Y + (direction.Y * Speed * Shared.TotalSeconds), 0, Shared.Boundaries.Y)
                );
            }

            var toMouse = InputManager.MousePosition - Position;
            Rotation = (float)Math.Atan2(toMouse.Y, toMouse.X);

            Weapon.Update();

            if (InputManager.MouseLeftDown)
            {
                Weapon.Fire(this);
            }

            if (InputManager.MouseRightClicked)
            {
                Weapon.Reload();
            }
            
            if (InputManager.ScrollWheelUp)
            {
                if (Shared.scrollIndex == 0)
                {
                    Shared.scrollIndex = 3;
                    SwapWeapon();
                }
                else
                {
                    Shared.scrollIndex--;
                    SwapWeapon();
                }

            }

            if (InputManager.ScrollWheelDown)
            {
                if (Shared.scrollIndex == 3)
                {
                    Shared.scrollIndex = 0;
                    SwapWeapon();
                }
                else
                {
                    Shared.scrollIndex++;
                    SwapWeapon();
                }
            }
        }

        public Rectangle getBounds()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height);
        }
    }
}
