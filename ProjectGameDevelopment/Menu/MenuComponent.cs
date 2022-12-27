using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGameDevelopment.Menu
{
    public abstract class MenuComponent
    {
      public abstract  void Draw(SpriteBatch spriteBatch, GameTime gameTime);
      public abstract  void Update(GameTime gameTime);
    }
}
