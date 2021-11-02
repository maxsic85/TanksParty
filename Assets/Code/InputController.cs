using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Code
{
    public class InputController : IExecute
    {
        IInput _input;
        InputType _inputType;
        IChooseTank chooseTank;
        InputData _inputData;
        ShootData _shootData;
        ShootInit shoot;
        List<Tank> _tanksOnSceene;
        Tank _playerTank;

        public InputController(InputType input, InputData inputData, ShootData shootData, Tank playerTank)
        {
            _input = GetInput(input);
            _inputType = input;
            _inputData = inputData;
            _shootData = shootData;
            _playerTank = playerTank;
            _tanksOnSceene = new List<Tank>();
            var taknsOnSceene = GameObject.FindObjectsOfType<Tank>();
            for (int i = 0; i < taknsOnSceene.Length; i++)
            {
                _tanksOnSceene.Add(taknsOnSceene[i]);

            }
            chooseTank = GameObject.FindObjectOfType<ChooseTank>();
            shoot = new ShootInit(_shootData, _shootData.BuilletPrefab.GetOrAddComponent<Rigidbody>());
        }

        public IInput GetInput(InputType inputType)
        {
            return inputType switch
            {
                InputType.MOUSE => new MouseClick(),
                InputType.KEYBORD => new KeybordClick(),
                _ => throw new ArgumentException("")

            };
        }
        public void Execute(float time)
        {
            if (_input.GetFire(_inputData) && !_playerTank.EndRound && chooseTank.ChoosingTank()!=null)
            {
                shoot.Shooting(_playerTank,chooseTank.ChoosingTank());
                chooseTank.ResetChoose();
            }

            if (_input.GetMenu(_inputData))
            {
                Debug.Log("Menu");
            }
        }


    }
}
