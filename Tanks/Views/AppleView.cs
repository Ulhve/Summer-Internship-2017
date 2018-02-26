using System.Windows.Forms;
using PackMan.Properties;

namespace Tanks
{
    public class AppleView : MapObjectView
    { 

        public AppleView(Panel map):base(map)
        {
            picBox.Image = Resources.Apple;
            map.Controls.Add(picBox);
            this.control = picBox;
        }
  
    }
}
