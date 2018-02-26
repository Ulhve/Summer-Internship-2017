using System.Windows.Forms;
using PackMan.Properties;

namespace Tanks
{
    public class TankView : DynamicMapObjectView
    {
        public TankView(Panel map):base(map)
        {
            picBox.Image = Resources.TankU;
            this.control = picBox;
        }

        protected  override void ChangePicture()
        {
            switch (Model.DirectionNow)
            {
                case (int)Direction.Up:
                    {
                        picBox.Image = Resources.TankU;
                        break;
                    }
                case ((int)Direction.Down):
                    {
                        picBox.Image = Resources.TankD;
                        break;
                    }
                case (int)Direction.Right:
                    {
                        picBox.Image = Resources.TankR;
                        break;
                    }
                case (int)Direction.Left:
                    {
                        picBox.Image = Resources.TankL;
                        break;
                    }
                default:
                    break;
            }
        }

    }
}
