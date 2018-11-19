using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace InfinityWar.Level
{
    class Tile : Sprite
    {
        public bool IsVisible { get; set; }
        public Tile(Texture2D texture, Vector2 positie,Rectangle viewRectangle, bool isVisible) : base(texture, positie, viewRectangle)
        {
            IsVisible = isVisible;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (IsVisible)
            {
                base.Draw(spriteBatch);
            }

        }
    }

    class CollisionTiles : Tile
    {
        public CollisionTiles(Texture2D texture, Vector2 positie, Rectangle viewRectangle, bool isVisible) : base(texture, positie, viewRectangle, isVisible)
        {
            ViewRectangle = viewRectangle;
        }
    }
}
