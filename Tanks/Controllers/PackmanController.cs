using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Tanks
{
    public class PackmanController
    {
        public List<IView> gameViews;
        public Game gameModel;

        public PackmanController()
        {
        }

        public PackmanController(Game model)
        {
            gameModel = model;
        }

        public void UpdateViews()
        {
            foreach (var view in gameViews)
            {
                view.UpdateView();
            }
        }

        public KolobokView AddKolobokView(Panel p_Map)
        {
            KolobokView viewPackMan = new KolobokView(p_Map);
            viewPackMan.Model = gameModel.PackMan;
            viewPackMan.Model.MapSize = new Point(p_Map.Width, p_Map.Height);
            viewPackMan.Subscribe();
            return viewPackMan;
        }

        public List<TankView> AddTankViews(Panel p_Map)
        {
            List<TankView> listViewTank = new List<TankView>();
            for (int i = 0; i < gameModel.listTank.Count; i++)
            {
                TankView viewTank = new TankView(p_Map);
                viewTank.Model = gameModel.listTank[i];
                viewTank.Model.MapSize = new Point(p_Map.Width, p_Map.Height);
                viewTank.Subscribe();
                listViewTank.Add(viewTank);
            }
            return listViewTank;
        }

        public List<WallView> AddWallViews(Panel p_Map)
        {
            List<WallView> listViewWall = new List<WallView>();
            for (int i = 0; i < gameModel.listWall.Count; i++)
            {
                WallView viewWall = new WallView(p_Map);
                viewWall.Model = gameModel.listWall[i];
                viewWall.Model.MapSize = new Point(p_Map.Width, p_Map.Height);
                listViewWall.Add(viewWall);
            }
            return listViewWall;
        }

        public List<RiverView> AddRiverViews(Panel p_Map)
        {
            List<RiverView> listViewRiver = new List<RiverView>();
            for (int i = 0; i < gameModel.listRiver.Count; i++)
            {
                RiverView viewRiver = new RiverView(p_Map);
                viewRiver.Model = gameModel.listRiver[i];
                viewRiver.Model.MapSize = new Point(p_Map.Width, p_Map.Height);
                listViewRiver.Add(viewRiver);
            }
            return listViewRiver;
        }

        public List<AppleView> AddAppleViews(Panel p_Map)
        {
            List<AppleView> listViewApple = new List<AppleView>();
            for (int i = 0; i < gameModel.listApple.Count; i++)
            {
                AppleView viewApple = new AppleView(p_Map);
                viewApple.Model = gameModel.listApple[i];
                viewApple.Model.MapSize = new Point(p_Map.Width, p_Map.Height);
                viewApple.Subscribe();
                listViewApple.Add(viewApple);
            }
            return listViewApple;
        }

        public List<BulletView> AddBulletViews(Panel p_Map)
        {
            List<BulletView> listViewBullet = new List<BulletView>();
            for (int i = 0; i < gameModel.listBullet.Count; i++)
            {
                BulletView viewBullet = new BulletView(p_Map);
                viewBullet.Model = gameModel.listBullet[i];
                viewBullet.Model.MapSize = new Point(p_Map.Width, p_Map.Height);
                viewBullet.Subscribe();
                listViewBullet.Add(viewBullet);
            }
            return listViewBullet;
        }

        public BulletView AddBullet(DynamicMapObject entity, Panel p_Map)
        {
            Rectangle rect = new Rectangle();
            var bullet = new Bullet(rect.Location, (int)GameForm.paramsGame["speedBullet"]);
            bullet.IdentifyDirection(entity.DirectionNow);
            bullet.entity = entity;
            gameModel.listBullet.Add(bullet);

            BulletView viewBullet = new BulletView(p_Map);
            viewBullet.Model = bullet;
            viewBullet.Model.Position = new Point(entity.Position.X, entity.Position.Y);
            viewBullet.Model.MapSize = new Point(p_Map.Width, p_Map.Height);
            viewBullet.Subscribe();

            return viewBullet;
        }

        public void ClearDeleted(GameForm form)
        {
            ClearDeletedBullets(form);
            ClearDeletedTanks(form);
        }

        private void ClearDeletedBullets(GameForm form)
        {
            var toDeleteBullets = form.listViewBullet.Where(id => (id.Model.toDelete == true));
            foreach (var item in toDeleteBullets)
            {
                form.p_Map.Controls.Remove(((DynamicMapObjectView)item).picBox);
                item.Unsubscribe();
            }
            form.listViewBullet.RemoveAll(id => (id.Model.toDelete == true));
            form.modelGame.listBullet.RemoveAll(id => (id.toDelete == true));
        }

        private void ClearDeletedTanks(GameForm form)
        {
            var toDeleteTanks = form.listViewTank.Where(id => (id.Model.toDelete == true));
            foreach (var item in toDeleteTanks)
            {
                form.p_Map.Controls.Remove(((DynamicMapObjectView)item).picBox);
                item.Unsubscribe();
            }
            form.listViewTank.RemoveAll(id => (id.Model.toDelete == true));
            form.modelGame.listTank.RemoveAll(id => (id.toDelete == true));
        }

        public void NewGame()
        {
            gameModel = new Game();
            foreach (var view in gameViews)
            {
                ((IView)view).SetModel(gameModel);
            }
            Game.Score = 0;
        }

            public void OnKeyPress(object sender, KeyEventArgs e)
        {
            if (sender is Kolobok)
            {
                switch (e.KeyData)
                {
                    case Keys.Up:
                        {
                            ((Kolobok)sender).IdentifyDirection((int)Direction.Up);
                            break;
                        }
                    case Keys.Down:
                        {
                            ((Kolobok)sender).IdentifyDirection((int)Direction.Down);
                            break;
                        }
                    case Keys.Left:
                        {
                            ((Kolobok)sender).IdentifyDirection((int)Direction.Left);
                            break;
                        }
                    case Keys.Right:
                        {
                            ((Kolobok)sender).IdentifyDirection((int)Direction.Right);
                            break;
                        }
                    default:
                        break;
                }
            }
        }

        
    }
}
