using System;
using System.Collections.Generic;
using System.Drawing;

namespace Tanks
{
    public class Game
    {
        private static int score = 0;

        public List<Tank> listTank = new List<Tank>();
        public List<Wall> listWall = new List<Wall>();
        public List<Apple> listApple = new List<Apple>();
        public List<Bullet> listBullet = new List<Bullet>();
        public List<River> listRiver = new List<River>();

        Kolobok packMan;

        public Kolobok PackMan
        {
            get { return packMan; }
        }

        public static int Score
        {
            get { return Game.score; }
            set { Game.score = value; }
        }

        public Game()
        {
            for (int i = 0; i < GameForm.countWall; i++)
            {
                Rectangle rect = new Rectangle();
                listWall.Add(new Wall(rect.Location));
            }

            PlaceWalls();

            for (int i = 0; i < GameForm.countRiver; i++)
            {
                Rectangle rect = new Rectangle();
                listRiver.Add(new River(rect.Location));
            }

            PlaceRiver();

            for (int i = 0; i < (int)GameForm.paramsGame["countTank"]; i++)
            {
                Rectangle rect = new Rectangle();
                do
                {
                    rect = new Rectangle(GameForm.rand.Next(0, GameForm.MaxX), 
                        GameForm.rand.Next(0, GameForm.MaxY), (new Tank()).Width, (new Tank()).Height);
                } while (Collides(rect));

                listTank.Add(new Tank(rect.Location, (int)GameForm.paramsGame["speed"]));
            }

            for (int i = 0; i < (int)GameForm.paramsGame["countApples"]; i++)
            {
                Rectangle rect = new Rectangle();
                do
                {
                    rect = new Rectangle(GameForm.rand.Next(0, GameForm.MaxX), 
                        GameForm.rand.Next(0, GameForm.MaxY), 
                        (new Apple()).Width, (new Apple()).Height);
                } while (Collides(rect));

                listApple.Add(new Apple(rect.Location));
            }

            Rectangle rect2 = new Rectangle();

            do
            {
                rect2 = new Rectangle(GameForm.rand.Next(0, GameForm.MaxX), 
                    GameForm.rand.Next(0, GameForm.MaxY), (new Kolobok()).Width, 
                    (new Kolobok()).Height);
            } while (Collides(rect2));

            packMan = new Kolobok(rect2.Location, (int)GameForm.paramsGame["speed"]);

            SubscribePos();
        }

        private void PlaceWalls()
        {
            int cur = 0;
            var map = GameForm.map;
            for (int i = 0; i < map.Length; i++)
                for (int j = 0; j < map[0].Length; j++)
                    if (map[i][j] == '1')
                    {
                        listWall[cur].Position = new Point(
                            i * listWall[cur].Width, j * listWall[cur].Height);
                        cur++;
                    }
        }

        private void PlaceRiver()
        {
            int cur = 0;
            var map = GameForm.map;
            for (int i = 0; i < map.Length; i++)
                for (int j = 0; j < map[0].Length; j++)
                    if (map[i][j] == '2')
                    {
                        listRiver[cur].Position = new Point(
                            i * listRiver[cur].Width, j * listRiver[cur].Height);
                        cur++;
                    }
        }

        private bool Collides(Rectangle rect)
        {
            if (rect.Left < 0 || rect.Right >= GameForm.MaxX || rect.Top < 0 || 
                rect.Bottom >= GameForm.MaxY)
                return true;
            for (int i = 0; i < listTank.Count; i++)
            {
                if (listTank[i].CollidesWith(rect)) return true;
            }
            for (int i = 0; i < listWall.Count; i++)
            {
                if (listWall[i].CollidesWith(rect)) return true;
            }
            for (int i = 0; i < listRiver.Count; i++)
            {
                if (listRiver[i].CollidesWith(rect)) return true;
            }
            for (int i = 0; i < listApple.Count; i++)
            {
                if (listApple[i].CollidesWith(rect)) return true;
            }
            if (packMan != null && packMan.CollidesWith(rect)) return true;

            return false;
        }

        public void CheckCollides()
        {
            for (int i = 0; i < listTank.Count; i++)
            {
                for (int j = 0; j < listTank.Count; j++)
                {
                    if (i != j)
                    {
                        listTank[j].OnCheckPosition(listTank[i]);
                    }
                }
            }

            for (int i = 0; i < listTank.Count; i++)
            {
                for (int j = 0; j < listWall.Count; j++)
                {
                    listWall[j].OnCheckPosition(listTank[i]);
                }
            }

            for (int i = 0; i < listTank.Count; i++)
            {
                for (int j = 0; j < listRiver.Count; j++)
                {
                    listRiver[j].OnCheckPosition(listTank[i]);
                }
            }

            for (int j = 0; j < listWall.Count; j++)
            {
                listWall[j].OnCheckPosition(packMan);
            }

            for (int j = 0; j < listRiver.Count; j++)
            {
                listRiver[j].OnCheckPosition(packMan);
            }

            for (int j = 0; j < listTank.Count; j++)
            {
                listTank[j].OnCheckPosition(packMan);
            }

            for (int j = 0; j < listTank.Count; j++)
            {
                packMan.OnCheckPosition(listTank[j]);
            }

            for (int j = 0; j < listApple.Count; j++)
            {
                listApple[j].OnCheckPosition(packMan);
            }

            for (int i = 0; i < listBullet.Count; i++)
            {
                for (int j = 0; j < listTank.Count; j++)
                {
                    listBullet[i].OnCheckPosition(listTank[j]);
                }
            }

            for (int i = 0; i < listBullet.Count; i++)
            {
                listBullet[i].OnCheckPosition(packMan);
            }

            for (int i = 0; i < listBullet.Count; i++)
            {
                for (int j = 0; j < listWall.Count; j++)
                {
                    listWall[j].OnCheckPosition(listBullet[i]);
                }
            }

        }

        public void SubscribePos()
        {
            for (int j = 0; j < listApple.Count; j++)
            {
                listApple[j].ReplaceNeeded += new EventHandler(apple_ReplaceNeeded);
            }
        }

        void apple_ReplaceNeeded(object sender, EventArgs e)
        {
            Rectangle rect2 = new Rectangle();
            do
            {
                rect2 = new Rectangle(GameForm.rand.Next(0, GameForm.MaxX - (sender as MapObject).Width - 2), 
                    GameForm.rand.Next(GameForm.MaxY - (sender as MapObject).Height - 2), 
                    (new Apple()).Width, (new Apple()).Height);
            } while (Collides(rect2));

            (sender as Apple).Position = rect2.Location;
        }

    }
}
