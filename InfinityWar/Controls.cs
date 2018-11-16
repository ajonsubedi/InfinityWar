using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityWar
{
    public class Controls
    {
        public bool Left { get; set; }
        public bool Right { get; set; }
        public bool Jump { get; set; }

        public void Update()
        {
            KeyboardState stateKey = Keyboard.GetState();
            //Naar links
            if (stateKey.IsKeyDown(Keys.Left))
            {
                Left = true;
            }
            if (stateKey.IsKeyUp(Keys.Left))
            {
                Left = false;
            }

            //Naar rechts
            if (stateKey.IsKeyDown(Keys.Right))
            {
                Right = true;
            }
            if (stateKey.IsKeyUp(Keys.Right))
            {
                Right = false;
            }

            //Springen
            if (stateKey.IsKeyDown(Keys.Up))
            {
                Jump = true;
            }
            if (stateKey.IsKeyUp(Keys.Up))
            {
                Jump = false;
            }
        }
    }
}
