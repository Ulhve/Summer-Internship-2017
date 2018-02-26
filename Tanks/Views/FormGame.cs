using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Tanks
{
    public partial class GameForm : Form, IView
    {
        public static Random rand = new Random();
        public static Dictionary<string, object> paramsGame;

        public static int MaxX;
        public static int MaxY;

        public static int countWall = 0;
        public static int countRiver = 0;
        public static string[] map = {
                    "1111111111111111111", "1001000002000000001", "1001000002000000001",
                    "1001001002001001001", "1000001002000001001", "1000001002000001001",
                    "1001111002001111001", "1001000002000001001", "1001000002000001001",
                    "1001001000001001001", "1001001000001001001", "1001001111111001001",
                    "1001001000001001001", "1001001000000001001", "1000000002000000001",
                    "1000000002001000001", "1002222222001111001", "1000000000000000001",
                    "1000000000000000001", "1111111111111111111"};

        public Game modelGame;
        public PackmanController packmanController;

        public List<TankView> listViewTank;
        public List<WallView> listViewWall;
        public List<AppleView> listViewApple;
        public List<BulletView> listViewBullet;
        public List<RiverView> listViewRiver;

        KolobokView viewPackMan;

        private event KeyEventHandler keyPress;

        public GameForm()
        {
            InitializeComponent();
            MaxX = p_Map.Width;
            MaxY = p_Map.Height;
            for (int i = 0; i < map.Length; i++)
                for (int j = 0; j < map[0].Length; j++)
                {
                    countWall += map[i][j] == '1' ? 1 : 0;
                    countRiver += map[i][j] == '2' ? 1 : 0;
                }
            modelGame = new Game();
            packmanController = new PackmanController(modelGame);
            AddElementsViews();
            SubscribeKeyPress();
        }

        protected void AddElementsViews()
        {
            listViewTank = packmanController.AddTankViews(p_Map);
            listViewWall = packmanController.AddWallViews(p_Map);
            listViewRiver = packmanController.AddRiverViews(p_Map);
            listViewApple = packmanController.AddAppleViews(p_Map);
            listViewBullet = packmanController.AddBulletViews(p_Map);

            viewPackMan = packmanController.AddKolobokView(p_Map);
        }

        public virtual void OnKeyPress(Keys key)
        {
            if (keyPress != null)
                keyPress(viewPackMan.Model, new KeyEventArgs(key));
        }

        public void SubscribeKeyPress()
        {
            this.keyPress += new KeyEventHandler(packmanController.OnKeyPress);
            packmanController.OnKeyPress(viewPackMan, new KeyEventArgs(Keys.Right));
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            OnKeyPress(e.KeyCode);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Space)
            {
                AddBullet(modelGame.PackMan);
            }
            return true;
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        public void SetController(PackmanController controller)
        {
            packmanController = controller;
        }

        public void SetModel(Game model)
        {
            modelGame = model;
        }

        public void UpdateView()
        {
            modelGame.CheckCollides();

            if (!modelGame.PackMan.IsAlive)
            {
                p_Map.Controls.Clear();
                p_Map.Controls.Add(label_GameOver);
                label_GameOver.Visible = true;
                timer_Game.Stop();
                return;
            }

            foreach (Bullet itemBullet in modelGame.listBullet)
            {
                if (!itemBullet.toDelete)
                    itemBullet.Move();
            }

            foreach (Tank itemTank in modelGame.listTank)
            {
                if (!itemTank.toDelete)
                {
                    if (GameForm.rand.Next(100) % 51 != 0)
                        itemTank.Move();
                    else
                        itemTank.Turn();

                    if (GameForm.rand.Next(50) % 31 == 0)
                       AddBullet(itemTank);
                }
            }

            packmanController.ClearDeleted(this);

            modelGame.PackMan.Move();

            label_ScoreValue.Text = Game.Score.ToString();
        }

        private void AddBullet(DynamicMapObject entity)
        {
            var viewBullet = packmanController.AddBullet(entity, p_Map);
            listViewBullet.Add(viewBullet);
        }

        private void Timer_Game_Tick(object sender, EventArgs e)
        {
            packmanController.UpdateViews();
        }

        private void Button_NewGame_Click(object sender, EventArgs e)
        {
            label_GameOver.Visible = false;
            p_Map.Controls.Clear();

            packmanController.NewGame();

            AddElementsViews();
            SubscribeKeyPress();

            label_ScoreValue.Text = Game.Score.ToString();
            timer_Game.Start();
        }
    }
}