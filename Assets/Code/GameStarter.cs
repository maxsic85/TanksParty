using UnityEngine;
using System.Collections.Generic;


namespace Tanks.Code
{
   public sealed class GameStarter:MonoBehaviour
    {
        [SerializeField] private TankData _tankData;
        [SerializeField] private List<TankData> _tanks;
        [SerializeField] private InputType _inputType;
        [SerializeField] private InputData _inputData;
        [SerializeField] private ShootData _shootData;


        Controllers _controllers;

        private void Start()
        {
            _controllers = new Controllers();
            new GameInitialisation(_tanks, _controllers, _tankData.TankType,_inputData,_inputType,_shootData);
          
        }

        private void Update()
        {
            _controllers.Execute(Time.deltaTime);
        }

    }
}
