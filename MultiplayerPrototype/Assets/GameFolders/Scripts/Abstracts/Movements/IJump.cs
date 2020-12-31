using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MultiplayerPrototype.Abstracts.Movements
{
    public interface IJump
    {
        bool TickFixed(float jumpForce, bool canJump);
    }    
}

