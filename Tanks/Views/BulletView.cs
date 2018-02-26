using System.Windows.Forms;
using PackMan.Properties;

namespace Tanks
{

    public class BulletView : DynamicMapObjectView
    {
        public BulletView(Panel map) : base(map)
        {
            picBox.Image = Resources.Bullet;
            map.Controls.Add(picBox);
            this.control = picBox;
        }

    }
}