using System.Drawing;

namespace Tanks
{
    public class River : MapObject
    {
        public River()
        {
            name = "Blue River";
        }

        public River(Point position) : base(position)
        {
            name = "Blue River";
        }
    }
}
