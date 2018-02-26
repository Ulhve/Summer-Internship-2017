using System.Drawing;

namespace Tanks
{
    public class Tank:DynamicMapObject
    {        
        public Tank()
        {
            name = "Monster Tank";
        }
        
        public Tank(Point position) : base(position)
        {
            name = "Monster Tank";
        }
        
        public Tank(Point position, int speed) : base(position, speed)
        {
            name = "Monster Tank";
        }

        public void Die()
        {
            this.toDelete = true;
        }
    }
}
