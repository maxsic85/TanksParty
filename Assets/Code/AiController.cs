using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tanks.Code
{
    public class AiController : IExecute, IAi
    {
        TimeManager tm;
        List<Tank> _tanks;
        Tank _playerTank;
        Dictionary<bool, Tank> _round;

        ShootData _shootData;
        ShootInit shoot;
        private bool isShootYet;

        public AiController(List<Tank> tanks, Tank playerTank, ShootData shootData)
        {
            this._tanks = tanks;
            this._playerTank = playerTank;
            this._shootData = shootData;
            shoot = new ShootInit(_shootData, _shootData.BuilletPrefab.GetOrAddComponent<Rigidbody>());
            tm = new TimeManager(2, 500);
            tm.StartTimerWithOutDispose(this);
        }

        public void AIShoot()
        {
            foreach (var item in _tanks)
            {
                if (!tm.IsElapsed && !isShootYet)
                {
                    isShootYet = true;
                }
                else if (tm.IsElapsed && !item.EndRound)
                {
                    isShootYet = false;
                    shoot.Shooting(item,_playerTank);
                    item.EndRound = true;
                    tm.IsElapsed = false;
                }
            }
        }

        public bool EndRound()
        {
            var checkTanks = false;
            foreach (var item in _tanks)
            {
                checkTanks = (item.EndRound == true) ? true : false;
            }
            return checkTanks;
        }

        public void Execute(float time)
        {

            if (_playerTank.EndRound)
            {
                AIShoot();
            }

            if (EndRound())
            {
                Debug.Log("new round");
                foreach (var item in _tanks)
                {
                    item.EndRound = false;
                }
            }
        }
    }
}