using System.Windows.Forms;
using PackMan.Properties;

namespace Tanks
{

    public class KolobokView:DynamicMapObjectView
    {
        public KolobokView(Panel map):base(map)
        {
            picBox.Image = Resources.PackManD;
            this.control = picBox;
        }

        protected override void ChangePicture()
        {
            switch (Model.DirectionNow)
            {
                case (int)Direction.Up:
                    {
                        picBox.Image = Resources.PackManU;
                        break;
                    }
                case ((int)Direction.Down):
                    {
                        picBox.Image = Resources.PackManD;
                        break;
                    }
                case (int)Direction.Right:
                    {
                        picBox.Image = Resources.PackManR;
                        break;
                    }
                case (int)Direction.Left:
                    {
                        picBox.Image = Resources.PackManL;
                        break;
                    }
                default:
                    break;
            }
        }

    }
}
