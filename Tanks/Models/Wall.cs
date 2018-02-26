using System.Drawing;

namespace Tanks
{
    public class Wall:MapObject
    {
        public Wall()
        {
            name = "Just Wall";
        }

        public Wall(Point position) : base(position)
        {
            name = "Just Wall";
        }
    }
}
