using UnityEngine;

namespace Tanks.Code
{
    public class Tank : MonoBehaviour, IMoveble, IStepble, IShootable
    {
        [SerializeField] private TankData _tankData;
        [SerializeField] private bool _endRound = false;

        public TankData _TankData => _tankData;

        public bool EndRound { get => _endRound; set => _endRound = value; }

        public bool EndStep()
        {
            return EndRound;
        }

        public void Move()
        {
            throw new System.NotImplementedException();
        }

        public int SetDamage()
        {
            throw new System.NotImplementedException();
        }

        private void OnEnable()
        {

        }

        public void Init(TankData tankData)
        {
            _tankData = tankData;
        }

        private void OnTriggerEnter(Collider other)
        {

        }



    }


}
