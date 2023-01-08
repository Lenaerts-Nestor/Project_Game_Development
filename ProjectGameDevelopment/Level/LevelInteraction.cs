using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjectGameDevelopment.Characters;
using ProjectGameDevelopment.Characters.Playable;
using ProjectGameDevelopment.Objects;
using System.Collections.Generic;
using System.Linq;

namespace ProjectGameDevelopment.Level
{
    public class LevelInteraction
    {

        ///deze classe houd zich bezig om condities/interactie van de gewenste level te controleren

        //controleerd of de Player de EndZone heeft geraakt
        public void GetPlayerToNextZone(Player Player, Rectangle EndZone, Game1 Game, int DesiredLVL)
        {
            if (EndZone.Intersects(Player.Hitbox))
            {
                switch (DesiredLVL)
                {
                    case 0:
                        Game.StateOfPlayer = Menu.currentPlayerState.Win;
                        Game.StateOfGame = Menu.currentGameState.GameOver;
                        break;
                    case 1:
                        Game.StateOfGame = Menu.currentGameState.level1;
                        break;
                    case 2:
                        Game.StateOfGame = Menu.currentGameState.level2;
                        break;
                    case 3:
                        Game.StateOfGame = Menu.currentGameState.level3;
                        break;
                    case 4:
                        Game.StateOfGame = Menu.currentGameState.level4;
                        break;
                    default:
                        break;
                }
            }

        }
        public void GetEndzone(Player Player, Rectangle EndZone, Game1 Game)
        {
            if (EndZone.Intersects(Player.Hitbox)) { Game.StateOfGame = Menu.currentGameState.GameOver; }

        }
        public Vector2 GetEnemyPosition(List<Enemy> EnemyList, Vector2 enemyInitPost)
        {
            if (EnemyList.Count > 0) { return EnemyList.Last().Position; }
            else { return new Vector2(); }


        }
        public void GetPlayerLifeCondition(Player Player, List<Enemy> EnemyList, GameTime gameTime)
        {
            foreach (var Enemy in EnemyList)
            {
                Enemy.Update(gameTime);

                if (Player.TouchedEnemy(EnemyList))
                {
                    Player.TimeXAttacking++;
                    if (Player.TimeXAttacking > Player.Time_x_hurt)
                    {
                        Player.HealthPoints--;
                        if (Player.HealthPoints == 0) Player.IsAlive = false;

                        Player.TimeXAttacking = 0;
                    }
                }
            }
        }
        public void GetPlayerCollides(Player Player, List<Rectangle> _collisionTiles, Vector2 PlayerInitPosition)
        {
            foreach (var rectangle in _collisionTiles)
            {
                if (!Player.IsJumping) Player.IsFalling = true;

                if (rectangle.Intersects(Player.Hitbox))
                {
                    Player.Position.X = PlayerInitPosition.X;
                    Player.Position.Y = PlayerInitPosition.Y;
                    Player.IsFalling = false;
                    break;
                }

            }

        }
        public void GetBulletCollides(Player player, List<Bullet> Bullets, List<Enemy> EnemyList, List<Rectangle> CollisionTiles, GameTime GameTime)
        {
            foreach (var bullet in Bullets.ToArray())
            {
                bullet.Update(GameTime);

                foreach (var rect in CollisionTiles)
                {
                    if (rect.Intersects(bullet.Hitbox))
                    {
                        Bullets.Remove(bullet);
                        break;
                    }
                }
                foreach (var enemy in EnemyList.ToArray())
                {
                    if (bullet.Hitbox.Intersects(enemy.Hitbox))
                    {
                        EnemyList.Remove(enemy);
                        Bullets.Remove(bullet);
                        player.Points++;
                        break;
                    }
                }

            }
        }
        public void GetEnemyCollides(List<Rectangle> _collisionTiles, List<Enemy> _enemyList, Vector2 EnemyInitPos)
        {
            foreach (var rect in _collisionTiles)
            {
                foreach (var enemy in _enemyList)
                {

                    if (rect.Intersects(enemy.Hitbox))
                    {
                        enemy.IsFalling = true;
                        if (enemy.IsInteligent)
                        {
                            if (enemy.IsAlive)
                            {
                                enemy.Position.X = EnemyInitPos.X;
                                enemy.Position.Y = EnemyInitPos.Y;
                                enemy.IsFalling = false;
                            }
                        }
                        break;
                    }
                }
            }

        }

        public void GetBullets(List<Bullet> _bullets, Player Player, int _time_x_bullet, Texture2D _bulletTexture, LevelMaker lvl)
        {
            if (Player.IsShooting && _bullets.ToArray().Length < 20)
            {
                //na de gewenste tijd word de bullets herladen
                if (_time_x_bullet > 5)
                {
                    //dit is om te weten naar welke kant de bullet zal gaan, dus als we naar recht kijken gaat het naar recht
                    if (Player.SpriteMoveDirection == SpriteEffects.None)
                    {
                        // new Vector2(_player.Position.X -7, _player.Position.Y -13)
                        _bullets.Add(new Bullet(_bulletTexture, new Vector2((int)Player.Position.X + 13, (int)Player.Position.Y + 16), 4));
                        lvl._bullets.Add(new Bullet(_bulletTexture, new Vector2((int)Player.Position.X + 13, (int)Player.Position.Y + 16), 4));
                    }
                    else if (Player.SpriteMoveDirection == SpriteEffects.FlipHorizontally)
                    {
                        _bullets.Add(new Bullet(_bulletTexture, new Vector2((int)Player.Position.X + 13, (int)Player.Position.Y + 16), -4));
                    }
                    lvl._time_x_bullet = 0;
                }
                else
                {
                    lvl._time_x_bullet++;
                }

            }



        }

        public void GetItemBuff(List<BuffItem> _buffItemList, Player Player, int buff)
        {
            foreach (var item in _buffItemList.ToArray())
            {
                if (Player.Hitbox.Intersects(item.Hitbox))
                {
                    Player.Speed += buff;
                    Player._touchedBuff = true;
                    _buffItemList.Remove(item);
                }

            }
        }

        public void GetPlayerGameState(Player player, Game1 Game)
        {
            if (!player.IsAlive)
            {
                Game.StateOfGame = Menu.currentGameState.GameOver;
                Game.StateOfPlayer = Menu.currentPlayerState.Lost;
            }

            if (player.Points == 3)
            {
                Game.StateOfGame = Menu.currentGameState.GameOver;
                Game.StateOfPlayer = Menu.currentPlayerState.Win;
            }
        }

    }
}
