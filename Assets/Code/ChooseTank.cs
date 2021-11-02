using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Code
{
    public class ChooseTank : MonoBehaviour, IChooseTank
    {
        [SerializeField] Tank choosingTank;

        public Tank _ChoosingTank => choosingTank;


        public Tank ChoosingTank()
        {
            RaycastHit hit;
            Ray ray = FindObjectOfType<Camera>().ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity) && choosingTank == null)
            {
                //TO DO вывести в данные 
                hit.transform.TryGetComponent<Tank>(out choosingTank);
                if (choosingTank != null)
                    choosingTank.transform.GetChild(0).transform.GetChild(3).transform.GetComponent<MeshRenderer>().material.color = Color.red;


            }


            return choosingTank;
        }

        public void ResetChoose()
        {

            choosingTank.transform.GetChild(0).transform.GetChild(3).transform.GetComponent<MeshRenderer>().material.color = Color.green;
            choosingTank = null;

        }

        private void FixedUpdate()
        {
            if (Input.GetMouseButtonDown(0))
            {
                ChoosingTank();

            }
        }
    }
}
