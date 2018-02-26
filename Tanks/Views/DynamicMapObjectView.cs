using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tanks
{
    public class DynamicMapObjectView:View<DynamicMapObject>
    {
        protected Control control = null;
        public PictureBox picBox = new PictureBox();

        public DynamicMapObjectView(Panel map)
        {
            map.Controls.Add(picBox);
            picBox.Height = Model.Height;
            picBox.Width = Model.Width;
        }

        public void Subscribe()
        {
            this.Model.PositionChanged += new EventHandler(OnPositionChanged);
            OnPositionChanged(this, new EventArgs());

        }

        public void Unsubscribe()
        {
            this.Model.PositionChanged -= OnPositionChanged;
        }

        private void OnPositionChanged(object sender, EventArgs e)
        {
            Show();
        }

        private void Show()
        {
            SetImage(Model.Position);
        }
        delegate void SetImageCallback(Point p);

        private void SetImage(Point p)
        {
            if (this.picBox.InvokeRequired)
            {
                SetImageCallback d = new SetImageCallback(SetImage);
                picBox.Invoke(d, new object[] { Model.Position });
            }
            else
            {
                ChangePicture();
                this.picBox.Location = p;
            }
        }

        protected virtual void ChangePicture() { }

        protected override void Update()
        {
            Show();
        }
    }
}
