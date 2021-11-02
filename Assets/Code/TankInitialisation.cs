using UnityEngine;

namespace Tanks.Code
{
    public sealed class TankInitialisation : IInitialisation
    {
        public TankInitialisation(ITankFabrik tankFabrik, out Tank tank)
        {

            var create = tankFabrik.CreateTank();
            tank = create.GetComponent<Tank>();
        }

        public void Initialisation()
        {

        }
    }
}
