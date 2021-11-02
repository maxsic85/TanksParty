using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Code
{
    [CreateAssetMenu(fileName = "Tank", menuName = "Data/Tank")]
    public class TankData : ScriptableObject
    {
        public GameObject TankPrefab;
        [SerializeField] private string _name;
        [SerializeField, Range(0, 100)] private int _hp;
        [SerializeField, Range(0, 100)] private int _baseDamage;
        [SerializeField, Range(0, 1000)] private int _speed = 50;
        [SerializeField] TankType _tankType;

       public  string _position;
        public string Name => _name;
        public int HP => _hp;

        public int BaseDamage => _baseDamage;
        public int Speed => _speed;


        public string Position => _position;
        public TankType TankType => _tankType;
    }
}
