using InfinityWar.Level;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using InfinityWar.Characters;

namespace InfinityWar.Levels
{
    class Stage1:Stage
    {
        

        public void DrawLevel() //Level 1 wordt gecreëerd
        {
            Generate(new int[,]
           {
              {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
              {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
              {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
              {0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
              {0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
              {0,0,7,2,3,0,0,0,0,0,0,0,0,0,0,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
              {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
              {0,0,13,14,15,0,0,0,0,0,0,0,0,0,0,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
              {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
              {0,0,0,0,0,0,0,13,14,15,0,0,0,0,0,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
              {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
              {0,0,0,0,0,0,0,0,0,0,0,0,0,13,0,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
              {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,3},
              {0,0,0,0,0,0,0,13,14,15,0,0,0,0,0,9,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,9},
              {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,13,14,14,14,14,14,14,14,14,9,0,0,0,0,13,0,0,0,0,13,0,0,0,0,13,0,0,0,0,13,0,0,0},
              {0,0,13,14,15,0,0,0,0,0,0,0,0,1,2,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
              {0,0,0,0,0,0,0,0,0,0,0,0,0,4,5,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
              {1,2,2,2,2,2,2,2,2,2,2,2,2,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,6},
              {4,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,6},
           }, 50);
        }

        public void AddCoinsLevel(List<Coin> coins, Texture2D coinTex)
        {
            coins.Add(new Coin(coinTex, new Vector2(150, 0)));
            coins.Add(new Coin(coinTex, new Vector2(200, 0)));

            coins.Add(new Coin(coinTex, new Vector2(100, 300)));
            coins.Add(new Coin(coinTex, new Vector2(150, 300)));
            coins.Add(new Coin(coinTex, new Vector2(200, 300)));

            coins.Add(new Coin(coinTex, new Vector2(350, 390)));
            coins.Add(new Coin(coinTex, new Vector2(400, 390)));
            coins.Add(new Coin(coinTex, new Vector2(450, 390)));

            coins.Add(new Coin(coinTex, new Vector2(650, 495)));

            coins.Add(new Coin(coinTex, new Vector2(350, 590)));
            coins.Add(new Coin(coinTex, new Vector2(400, 590)));
            coins.Add(new Coin(coinTex, new Vector2(450, 590)));

            coins.Add(new Coin(coinTex, new Vector2(100, 690)));
            coins.Add(new Coin(coinTex, new Vector2(150, 690)));
            coins.Add(new Coin(coinTex, new Vector2(200, 690)));

            coins.Add(new Coin(coinTex, new Vector2(0, 800)));
            coins.Add(new Coin(coinTex, new Vector2(50, 800)));
            coins.Add(new Coin(coinTex, new Vector2(100, 800)));
            coins.Add(new Coin(coinTex, new Vector2(150, 800)));
            coins.Add(new Coin(coinTex, new Vector2(200, 800)));
            coins.Add(new Coin(coinTex, new Vector2(250, 800)));
            coins.Add(new Coin(coinTex, new Vector2(300, 800)));
            coins.Add(new Coin(coinTex, new Vector2(350, 800)));
            coins.Add(new Coin(coinTex, new Vector2(400, 800)));
            coins.Add(new Coin(coinTex, new Vector2(450, 800)));
            coins.Add(new Coin(coinTex, new Vector2(500, 800)));
            coins.Add(new Coin(coinTex, new Vector2(550, 800)));
            coins.Add(new Coin(coinTex, new Vector2(600, 800)));

            coins.Add(new Coin(coinTex, new Vector2(700, 690)));
            coins.Add(new Coin(coinTex, new Vector2(750, 690)));

            coins.Add(new Coin(coinTex, new Vector2(950, 640)));
            coins.Add(new Coin(coinTex, new Vector2(1000, 640)));
            coins.Add(new Coin(coinTex, new Vector2(1050, 640)));
            coins.Add(new Coin(coinTex, new Vector2(1100, 640)));
            coins.Add(new Coin(coinTex, new Vector2(1150, 640)));
            coins.Add(new Coin(coinTex, new Vector2(1200, 640)));
            coins.Add(new Coin(coinTex, new Vector2(1250, 640)));
            coins.Add(new Coin(coinTex, new Vector2(1300, 640)));
            coins.Add(new Coin(coinTex, new Vector2(1350, 640)));
            coins.Add(new Coin(coinTex, new Vector2(1400, 590)));
            coins.Add(new Coin(coinTex, new Vector2(1650, 640)));
            coins.Add(new Coin(coinTex, new Vector2(1900, 640)));
            coins.Add(new Coin(coinTex, new Vector2(2150, 640)));
            coins.Add(new Coin(coinTex, new Vector2(2400, 640)));
        }

        public void AddEnemiesLevel(List<Enemy> enemies, Texture2D enemyTex)
        {
            enemies.Add(new Enemy(enemyTex, new Vector2(100, 640), 100, 200));
            enemies.Add(new Enemy(enemyTex, new Vector2(350, 585), 350, 450));
            enemies.Add(new Enemy(enemyTex, new Vector2(350, 385), 350, 450));
            enemies.Add(new Enemy(enemyTex, new Vector2(100, 295), 100, 200));
            enemies.Add(new Enemy(enemyTex, new Vector2(150, 0), 150, 200));
            enemies.Add(new Enemy(enemyTex, new Vector2(200, 790), 200, 550));
            enemies.Add(new Enemy(enemyTex, new Vector2(900, 400), 950, 1300));

        }

        public void AddSpikes(List<Spike> spikes, Texture2D spikeTex)
        {
            spikes.Add(new Spike(spikeTex, new Vector2(800, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(850, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(900, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(950, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(1000, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(1050, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(1100, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(1150, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(1200, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(1250, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(1300, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(1350, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(1400, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(1450, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(1500, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(1550, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(1600, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(1650, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(1700, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(1750, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(1800, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(1850, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(1900, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(1950, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(2000, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(2050, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(2100, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(2150, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(2200, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(2250, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(2300, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(2350, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(2400, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(2450, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(2500, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(2550, 800)));
        }
    }
}
