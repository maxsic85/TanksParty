using UnityEngine;

namespace Tanks.Code
{
   public interface ITankFabrik
    {
        GameObject CreateTank();
        void SetSide(TankType tankType);
    }
}
