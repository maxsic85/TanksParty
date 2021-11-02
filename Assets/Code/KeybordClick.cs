
using UnityEngine;

namespace Tanks.Code
{
    public class KeybordClick : IInput
    {
        public bool GetFire(InputData inputData)
        {
            return Input.GetKeyDown(inputData.Fire);
        }
        public bool GetMenu(InputData inputData)
        {
            return Input.GetKeyDown(inputData.Menu);
        }

    }

    public class MouseClick : IInput
    {
        public bool GetFire(InputData inputData)
        {
            return Input.GetMouseButtonDown(0);
        }

        public bool GetMenu(InputData inputData)
        {
            return Input.GetMouseButtonDown(1);
        }

    }
}