using System.Windows.Forms;
using PackMan.Properties;

namespace Tanks
{

    public class RiverView : MapObjectView
    {

        public RiverView(Panel map) : base(map)
        {
            picBox.Image = Resources.River;
            map.Controls.Add(picBox);
            this.control = picBox;
        }

    }
}
