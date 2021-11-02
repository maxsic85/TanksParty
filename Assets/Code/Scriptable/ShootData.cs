
using UnityEngine;

namespace Tanks.Code
{
    [CreateAssetMenu(fileName = "Shoot", menuName = "Data/Shoot")]
    public sealed class ShootData:ScriptableObject
    {
        public GameObject BuilletPrefab;
        [SerializeField, Range(0, 100)] private int _baseDamage;
        [SerializeField, Range(0, 100)] private float _speed=100f;
        [SerializeField] private string _name;

        public string Name => _name;
        public int Damage => _baseDamage;

        public float SpeedBuilet => _speed;

    }
}
