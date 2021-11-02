using System.Windows.Input;
using UnityEngine;

namespace Tanks.Code
{
    [CreateAssetMenu(fileName = "Input", menuName = "Data/Input")]
    public class InputData : ScriptableObject
    {
        [SerializeField] KeyCode fire=KeyCode.Space;
        [SerializeField] KeyCode menu=KeyCode.Q;

  
        public KeyCode Fire => fire;
        public KeyCode Menu => menu;

    }
}
