using System;
using System.Collections.Generic;
using System.Text;

namespace Tanks
{
    public interface IView
    {
        void SetController(PackmanController controller);
        void SetModel(Game model);
        void UpdateView();
    }
}
