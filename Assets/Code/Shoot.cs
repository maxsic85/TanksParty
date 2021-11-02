using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Code
{
    public class ShootInit
    {
        TimeManager tm;
        bool isShootYet = false;
        ShootData _shootData;
        private Rigidbody _rigidbody;
        private Transform _startPosition;
        Tank _tank;
        public ShootInit(ShootData shootData, Rigidbody rigidbody)
        {
            this._shootData = shootData;
            _rigidbody = rigidbody;
            //TO DO добавить данные убрать маг числа
            tm = new TimeManager(1, 1000);

        }



        public void Shooting(Tank currentTank, Tank chooseTank)
        {
         _startPosition = currentTank.transform.GetChild(0).transform.GetChild(3);
            var temAmmunition = GameObject.Instantiate(_shootData.BuilletPrefab, _startPosition.position, _startPosition.rotation);
            Vector3 relative = chooseTank.transform.position - currentTank.transform.position;
            //TO DO Migic digit
            Vector3 newDir = Vector3.RotateTowards(currentTank.transform.forward, relative,
                100f * Time.deltaTime, 0f);
            newDir += new Vector3(0, 0.15f, 0);
            currentTank.transform.rotation = Quaternion.LookRotation(newDir);
            temAmmunition.GetOrAddComponent<Rigidbody>().AddForce(newDir * _shootData.SpeedBuilet);
            Debug.Log(currentTank + "Fire");
            currentTank.EndRound = true;
        }
    }
}
