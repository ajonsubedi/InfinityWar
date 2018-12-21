using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityWar.Interfaces
{
    interface IBackground
    {
        void Update(Rectangle screenRecatangle);
        void Draw(SpriteBatch spriteBatch);
    }
}
