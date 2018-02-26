using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace Tanks
{
    public class Kolobok: DynamicMapObject
    {
        private bool isAlive = true;
        public bool IsAlive
        {
            get { return isAlive; }
        }
        
        // конструкторы
        public Kolobok() : base()
        {
            name = "Hero Kolobok";
        }

        public Kolobok(Point position) : base (position)
        {
            name = "Hero Kolobok";
        }
        
        public Kolobok(Point position, int speed) : base(position, speed)
        {
            name = "Hero Kolobok";
        }
        
        //Смерть Пакмена.
        public void Die()
        {
            isAlive = false;
        }

        //обработка пересечения с объектами
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
                    if (sender is Tank)
                        Die();
                }
            }
        }
        
    }
}
