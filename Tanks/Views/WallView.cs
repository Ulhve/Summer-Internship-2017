using System.Windows.Forms;
using PackMan.Properties;

namespace Tanks
{

    public class WallView: MapObjectView
    {

        public WallView(Panel map):base(map)
        {
            picBox.Image = Resources.Wall;
            this.control = picBox;
        }

    }
}
