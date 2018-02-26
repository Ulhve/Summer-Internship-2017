using System.Drawing;

namespace Tanks
{
    public class DynamicMapObject : MapObject
    {
        public int dy;
        public int dx;
        bool flag = false;
        protected int delta;
        private int directionNow;

        public int DirectionNow
        {
            get { return directionNow; }
            set { directionNow = value; }
        }

        public DynamicMapObject() : base()
        {
        }

        public DynamicMapObject(Point position) : base (position)
        {
            delta = 2;
            dy = 0;
            dx = delta;
            Turn();
        }

        public DynamicMapObject(Point position, int speed) : base(position)
        {
            delta = speed;
            dy = 0;
            dx = delta;
            Turn();
        }

        virtual public void Move()
        {
            if (position.X + dx >= 0 && position.X + this.Width + dx < MapSize.X)
                position.X += dx;
            else
                Deviate();

            if (position.Y + dy >= 0 && position.Y + this.Height + dy < MapSize.Y)
                position.Y += dy;
            else
                Deviate();

            flag = true;

            OnPositionChanged();
        }

        public void Stop()
        {
            dx = 0;
            dy = 0;
        }

        public void Deviate()
        {
            if (flag == true)
            {
                dx = -dx;
                dy = -dy;
                switch (directionNow)
                {
                    case (int)Direction.Left:
                        {
                            directionNow = (int)Direction.Right;
                            break;
                        }
                    case (int)Direction.Right:
                        {
                            directionNow = (int)Direction.Left;
                            break;
                        }
                    case (int)Direction.Up:
                        {
                            directionNow = (int)Direction.Down;
                            break;
                        }
                    case (int)Direction.Down:
                        {
                            directionNow = (int)Direction.Up;
                            break;
                        }
                }
                flag = false;
            }
        }

        public void Turn()
        {
            IdentifyDirection(GameForm.rand.Next(0, 4));
        }

        public void IdentifyDirection(int direction)
        {
            switch (direction)
            {
                case (int)Direction.Down:
                    {
                        dy = delta;
                        dx = 0;
                        directionNow = (int)Direction.Down;
                        break;
                    }
                case (int)Direction.Left:
                    {
                        dy = 0;
                        dx = -delta;
                        directionNow = (int)Direction.Left;
                        break;
                    }
                case (int)Direction.Right:
                    {
                        dy = 0;
                        dx = delta;
                        directionNow = (int)Direction.Right;
                        break;
                    }
                case (int)Direction.Up:
                    {
                        dy = -delta;
                        dx = 0;
                        directionNow = (int)Direction.Up;
                        break;
                    }
                default:
                    break;
            }
        }

        public override  void OnCheckPosition(DynamicMapObject sender)
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
                    {
                        this.Deviate();
                        ((DynamicMapObject)sender).Deviate();
                    }
                    if ((sender is Kolobok) && (this is Tank))
                    {
                        (sender as Kolobok).Die();
                    }
                }
            }
        }

    }
}
