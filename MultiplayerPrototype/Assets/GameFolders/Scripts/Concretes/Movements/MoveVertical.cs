using MultiplayerPrototype.Abstracts.Controllers;
using MultiplayerPrototype.Abstracts.Movements;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace MultiplayerPrototype.Movements
{
    public class MoveVertical : IMover
    {
        private IEntityController _entityController;

        public MoveVertical(IEntityController entityController)
        {
            _entityController = entityController;
        }
        
        public void TickFixed(float direction, float moveSpeed)
        {
            _entityController.transform.Translate(_entityController.transform.forward * Time.deltaTime * direction * moveSpeed);
        }
    }
}