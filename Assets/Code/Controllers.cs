using System.Collections.Generic;
using UnityEngine;
namespace Tanks.Code
{
    public sealed class Controllers:IInitialisation,IExecute
    {
        public List<IInitialisation> _initialisationsList;
        public List<IExecute> _executeList;

        public Controllers()
        {
            _initialisationsList = new List<IInitialisation>();
            _executeList = new List<IExecute>();
        }

        public Controllers Add(IController controller)
        {
            if (controller is IInitialisation initialisation)
            {
                _initialisationsList.Add(initialisation);
            }
            if (controller is IExecute execute)
            {
                _executeList.Add(execute);
            }
            return this;
        }

        public void Execute(float time)
        {
            for (var  index = 0; index < _executeList.Count; ++index)
            {
                _executeList[index].Execute(Time.deltaTime);

            }
        }

        public void Initialisation()
        {
            for (var index = 0; index < _initialisationsList.Count; ++index)
            {
                _initialisationsList[index].Initialisation();
            }
        }
    }
}
