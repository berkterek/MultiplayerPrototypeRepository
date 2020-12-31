using System.Collections;
using System.Collections.Generic;
using MultiplayerPrototype.Abstracts.Controllers;
using MultiplayerPrototype.Abstracts.Movements;
using UnityEngine;

namespace MultiplayerPrototype.Movements
{
    public class HorizontalMove : IMover
    {
        private IEntityController _entityController;
        int _minMaxBoudary = 4;

        public HorizontalMove(IEntityController entityController)
        {
            _entityController = entityController;
        }

        public void TickFixed(float horizontal, float moveSpeed)
        {
            if (horizontal == 0f) return;

            _entityController.transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * horizontal);
            
            float xBoundary = Mathf.Clamp(_entityController.transform.position.x, -_minMaxBoudary, _minMaxBoudary);
            _entityController.transform.position = new Vector3(xBoundary, _entityController.transform.position.y, 0f);
        }
    }    
}

