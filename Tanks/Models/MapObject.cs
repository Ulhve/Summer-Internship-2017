using System;
using System.Drawing;

namespace Tanks
{
    public class MapObject
    {
        private const int width = 25;
        private const int height = 25;

        public string name;
        public bool toDelete = false;

        public Point position;

        public Point Position
        {
            get { return position; }
            set
            {
                position = value;
                OnPositionChanged();

            }
        }

        public int Width
        {
            get { return width; }
        }

        public int Height
        {
            get { return height; }
        }

        private Point mapSize;

        public Point MapSize
        {
            get { return mapSize; }
            set { mapSize = value; }
        }

        public MapObject()
        {
            this.position = new Point(GameForm.rand.Next(0, GameForm.MaxX - Width - 2), 
                GameForm.rand.Next(0, GameForm.MaxY - Height - 2));
        }

        public MapObject(Point position)
        {
            this.position = position;
        }

        public event EventHandler ReplaceNeeded;

        public void OnReplaceNeeded()
        {
            if (ReplaceNeeded != null)
                ReplaceNeeded(this, new EventArgs());
        }

        protected bool CheckCrossing(Point p)
        {
            if (this.Position.X + this.Width >= p.X && this.Position.X <= p.X)
            {
                if (this.Position.Y + this.Height >= p.Y && this.Position.Y <= p.Y)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CollidesWith(Rectangle rect)
        {
            if (CheckCrossing(new Point(rect.Left, rect.Top)) ||
                CheckCrossing(new Point(rect.Right, rect.Top)) ||
                CheckCrossing(new Point(rect.Right, rect.Bottom)) ||
                CheckCrossing(new Point(rect.Left, rect.Bottom)))
                return true;

            return false;
        }

        public virtual void OnCheckPosition(DynamicMapObject sender)
        {
            var positionArgs = new PositionChangedArgs(new Rectangle(sender.position.X + sender.dx,
                    sender.position.Y + sender.dy, sender.Width, sender.Height));
            if (positionArgs == null)
                return;
            
            if (CollidesWith(positionArgs.NewRectangle))
            {
                if ((!((MapObject)sender).toDelete) && (!this.toDelete))
                {
                    if ((sender is Bullet) && (this is Wall))
                        ((Bullet)sender).Die();
                    else
                        ((DynamicMapObject)sender).Deviate();
                }
            }
        }

        public event EventHandler PositionChanged;

        protected virtual void OnPositionChanged()
        {
            if (PositionChanged != null)
                PositionChanged(this, new EventArgs());
        }
    }
}
