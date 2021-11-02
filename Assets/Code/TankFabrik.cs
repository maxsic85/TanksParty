
using UnityEngine;
using Unity;
namespace Tanks.Code
{
    public sealed class TankFabrik : ITankFabrik
    {
        TankType _tankType;
        TankData _tankData;

        public TankFabrik(TankType tankType, TankData tankData)
        {
            _tankType = tankType;
            _tankData = tankData;
        }

        public Transform player { get; set; }




        public GameObject CreateTank()
        {
            //TO DO сделать м-д расширения проверки на наличие данных в TankData
            var tank = GameObject.Instantiate(_tankData.TankPrefab);
         
            //TO DO сделать м-д расширения FindOrCreateGameObject
            var transformForPlace = GameObject.Find(_tankData.Position).gameObject.transform;
            tank.transform.position = transformForPlace.position;
            tank.transform.SetParent(transformForPlace);
            tank.transform.rotation = transformForPlace.rotation;
            tank.GetOrAddComponent<Tank>();
            tank.GetOrAddComponent<Tank>().Init(_tankData);
            //TO DO переместить параметры из дата в экземпляр

            return tank;
        }

        public void SetSide(TankType tankType)
        {
            // TO DO
        }
    }
}
