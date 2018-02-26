using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Tanks
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            GameForm.paramsGame = new Dictionary<string, object>()
            {
                { "countTank", 5},
                { "countApples", 5},
                { "speed", 5},
                { "speedBullet", 15}
            };

            GameForm gameView = new GameForm();
            FormStates statsView = new FormStates()
            {
                modelGame = gameView.modelGame,
            };

            List<IView> views = new List<IView>()
            {
                gameView,
                statsView
            };

            gameView.packmanController.gameViews = views;

            statsView.SetController(gameView.packmanController);

            statsView.Show();
            gameView.ShowDialog();
        }
    }
}