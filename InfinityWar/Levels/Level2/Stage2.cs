using InfinityWar.Characters;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityWar.Levels
{
    class Stage2:Stage
    {
        public void DrawLevel() //Level 2 wordt gecreëerd
        {
            Generate(new int[,]
          {
              {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
              {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
              {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
              {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
              {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
              {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
              {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
              {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
              {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
              {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
              {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
              {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
              {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
              {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,13,14,14,14,15,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
              {0,0,0,0,0,0,13,14,14,15,0,0,0,0,0,13,14,14,15,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
              {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
              {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
              {1,2,3,0,0,0,1,2,2,2,3,0,0,0,1,2,2,2,3,0,0,0,1,2,2,2,3,0,0,0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,3},
              {4,5,5,2,2,2,5,5,5,5,5,2,2,2,5,5,5,5,5,2,2,2,5,5,5,5,5,2,2,2,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,6},
          }, 50);
        }

        public void AddCoinsLevel(List<Coin> coins, Texture2D coinTex)
        {
            coins.Add(new Coin(coinTex, new Vector2(0, 800)));
            coins.Add(new Coin(coinTex, new Vector2(50, 800)));
            coins.Add(new Coin(coinTex, new Vector2(100, 800)));
            coins.Add(new Coin(coinTex, new Vector2(150, 800)));
            coins.Add(new Coin(coinTex, new Vector2(200, 800)));
            coins.Add(new Coin(coinTex, new Vector2(235, 800)));
            coins.Add(new Coin(coinTex, new Vector2(300, 800)));
            coins.Add(new Coin(coinTex, new Vector2(350, 800)));
            coins.Add(new Coin(coinTex, new Vector2(400, 800)));
            coins.Add(new Coin(coinTex, new Vector2(450, 800)));
            coins.Add(new Coin(coinTex, new Vector2(500, 800)));
            coins.Add(new Coin(coinTex, new Vector2(550, 800)));
            coins.Add(new Coin(coinTex, new Vector2(600, 800)));
            coins.Add(new Coin(coinTex, new Vector2(635, 800)));
            coins.Add(new Coin(coinTex, new Vector2(700, 800)));
            coins.Add(new Coin(coinTex, new Vector2(750, 800)));
            coins.Add(new Coin(coinTex, new Vector2(800, 800)));
            coins.Add(new Coin(coinTex, new Vector2(850, 800)));
            coins.Add(new Coin(coinTex, new Vector2(950, 800)));
            coins.Add(new Coin(coinTex, new Vector2(1000, 800)));
            coins.Add(new Coin(coinTex, new Vector2(1035, 800)));
            coins.Add(new Coin(coinTex, new Vector2(1100, 800)));
            coins.Add(new Coin(coinTex, new Vector2(1150, 800)));
            coins.Add(new Coin(coinTex, new Vector2(1200, 800)));
            coins.Add(new Coin(coinTex, new Vector2(1250, 800)));
            coins.Add(new Coin(coinTex, new Vector2(1300, 800)));
            coins.Add(new Coin(coinTex, new Vector2(1350, 800)));
            coins.Add(new Coin(coinTex, new Vector2(1400, 800)));
            coins.Add(new Coin(coinTex, new Vector2(1435, 800)));


            coins.Add(new Coin(coinTex, new Vector2(300, 640)));
            coins.Add(new Coin(coinTex, new Vector2(350, 640)));
            coins.Add(new Coin(coinTex, new Vector2(400, 640)));
            coins.Add(new Coin(coinTex, new Vector2(450, 640)));

            coins.Add(new Coin(coinTex, new Vector2(750, 640)));
            coins.Add(new Coin(coinTex, new Vector2(800, 640)));
            coins.Add(new Coin(coinTex, new Vector2(850, 640)));
            coins.Add(new Coin(coinTex, new Vector2(900, 640)));

            coins.Add(new Coin(coinTex, new Vector2(1150, 590)));
            coins.Add(new Coin(coinTex, new Vector2(1200, 590)));
            coins.Add(new Coin(coinTex, new Vector2(1250, 590)));
            coins.Add(new Coin(coinTex, new Vector2(1300, 590)));
            coins.Add(new Coin(coinTex, new Vector2(1350, 590)));
        }
        public void AddEnemiesLevel(List<Enemy> enemies, Texture2D enemyTex)
        {
            enemies.Add(new Enemy(enemyTex, new Vector2(300, 640), 300, 450));
            enemies.Add(new Enemy(enemyTex, new Vector2(750, 640), 750, 900));
            enemies.Add(new Enemy(enemyTex, new Vector2(1150, 590), 1150, 1350));
        }
    }
}
