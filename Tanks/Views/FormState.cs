using System;
using System.Windows.Forms;

namespace Tanks
{
    public partial class FormStates : Form, IView
    {
        public Game modelGame;
        PackmanController packmanController;

        public FormStates()
        {
            InitializeComponent();
        }

        private void FormState_Load(object sender, EventArgs e)
        {
            UpdateView();
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
            int count = 1 + modelGame.listTank.Count +
                    modelGame.listApple.Count +
                    modelGame.listBullet.Count +
                    modelGame.listWall.Count +
                    modelGame.listRiver.Count;

            int countAdd = count - dataGrid_States.Rows.Count;

            for (var i = 0; i < dataGrid_States.Rows.Count; i++)
            {
                dataGrid_States.Rows[i].SetValues(null, null, null);
            }

            if (dataGrid_States.Rows.Count < count)
            {
                for (var i = 0; i < countAdd; i++)
                {
                    dataGrid_States.Rows.Add(null, null, null);
                }
            }

            int j = 0;
            dataGrid_States.Rows[j].SetValues(modelGame.PackMan.name,
                    modelGame.PackMan.Position.X,
                    modelGame.PackMan.Position.Y);
            foreach (var item in modelGame.listTank)
            {
                j++;
                dataGrid_States.Rows[j].SetValues(item.name,
                    item.Position.X,
                    item.Position.Y);
            }
            foreach (var item in modelGame.listApple)
            {
                j++;
                dataGrid_States.Rows[j].SetValues(item.name,
                    item.Position.X,
                    item.Position.Y);
            }
            foreach (var item in modelGame.listBullet)
            {
                j++;
                dataGrid_States.Rows[j].SetValues(item.name,
                    item.Position.X,
                    item.Position.Y);
            }
            foreach (var item in modelGame.listRiver)
            {
                j++;
                dataGrid_States.Rows[j].SetValues(item.name,
                    item.Position.X,
                    item.Position.Y);
            }
            foreach (var item in modelGame.listWall)
            {
                j++;
                dataGrid_States.Rows[j].SetValues(item.name,
                    item.Position.X,
                    item.Position.Y);
            }
        }

    }
}
