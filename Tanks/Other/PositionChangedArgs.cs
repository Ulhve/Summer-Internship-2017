using System.Drawing;

namespace Tanks
{
    public class PositionChangedArgs
    {
        private Rectangle newRectangle;

        public Rectangle NewRectangle
        {
            get { return newRectangle; }
            set { newRectangle = value; }
        }

        public PositionChangedArgs()
        {
        }

        public PositionChangedArgs( Rectangle newRectangle)
        {
            this.newRectangle = newRectangle;
        }
    }
}
