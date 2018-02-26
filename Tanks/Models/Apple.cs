using System.Drawing;

namespace Tanks
{
    public class Apple:MapObject
    {
        public Apple(Point position) : base(position)
        {
            name = "Om-Nom-nom Apple";
        }

        public Apple()
        {
            name = "Om-Nom-nom Apple";
        }

        private void Replace()
        {
            OnReplaceNeeded();
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
                    if (sender is Kolobok)
                    {
                        Replace();
                        Game.Score += 1;
                    }
                }
            }
        }

    }
}
