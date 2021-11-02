
using UnityEngine;
namespace Tanks.Code
{
    class TestMihail : MonoBehaviour
    {
        private float _pause = 1.0f;
    
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)&& !IsInvoking("Shoot"))
            {
                Invoke("Shoot", _pause);
            }
           
        }

        private void Shoot()
        {
            Debug.Log("Shoot");
        }
    }
}