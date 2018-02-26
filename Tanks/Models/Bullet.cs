using System.Drawing;

namespace Tanks
{
    public class Bullet : DynamicMapObject
    {
        //стрелявшая сущность
        public MapObject entity;

        //конструкторы
        public Bullet() : base()
        {
            name = "Evil Bullet";
        }
        public Bullet(Point position) : base(position)
        {
            name = "Evil Bullet";
        }
        public Bullet(Point position, int speed) : base(position, speed)
        {
            name = "Evil Bullet";
        }

        //исчезновение пули
        public void Die()
        {
            this.toDelete = true;
        }

        public override void OnCheckPosition(DynamicMapObject sender)
        {
            var positionArgs = new PositionChangedArgs(new Rectangle(sender.position.X + sender.dx,
                    sender.position.Y + sender.dy, sender.Width, sender.Height));
            if (positionArgs == null)
                return;
            if (CollidesWith(positionArgs.NewRectangle))
            {
                if ((!((MapObject)sender).toDelete) && (!this.toDelete))
                {
                    if ((sender is Kolobok) && (this.entity is Tank))
                    {
                        this.Die();
                        ((Kolobok)sender).Die();
                    }
                    else if ((sender is Tank) && (this.entity is Kolobok))
                    {
                        this.Die();
                        ((Tank)sender).Die();
                    }
                }
            }
        }
    }
}
