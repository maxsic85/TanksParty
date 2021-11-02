using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace Tanks.Code
{
    public class GameInitialisation
    {
      public List<Tank> TanksList;
      public Tank PlayerTank
        {
            get
            {
                var player = TanksList.FirstOrDefault(u => u._TankData.TankType == TankType.PLAYER);
                if (player == null)
                {
                    //TO DO что то сделать мнтод расширения на назначение игрока из масмива
                }
                return player;
            }
        }
        public GameInitialisation(List<TankData> tanks, Controllers controllers, TankType tankType,InputData inputData, InputType inputType,ShootData shootData)
        {
            ITankFabrik tankFabrik;
            TanksList = new List<Tank>();
            for (int i = 0; i < tanks.Count; i++)
            {
                tankFabrik = new TankFabrik(tankType, tanks[i]);
                var tankInitialisation = new TankInitialisation(tankFabrik,out Tank tank);
                controllers.Add(tankInitialisation);
                TanksList.Add(tank);
            }

            var inputController = new InputController(inputType,inputData,shootData,PlayerTank);
            var roundController = new AiController(TanksList, PlayerTank,shootData);
            
            
            controllers.Add(inputController);
            controllers.Add(roundController);

        }
    }
}
