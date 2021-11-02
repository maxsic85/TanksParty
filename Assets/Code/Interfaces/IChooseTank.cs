using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks.Code
{
    public interface IChooseTank
    {
        Tank ChoosingTank();
        void ResetChoose();
    }
}
