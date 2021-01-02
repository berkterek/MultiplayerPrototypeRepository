using System.Collections;
using System.Collections.Generic;
using MultiplayerPrototype.Enums;
using UnityEngine;

namespace MultiplayerPrototype.Abstracts.Controllers
{
    public interface IEnemyController : IEntityController
    {
        EnemyEnum EnemyEnum { get; }
    }    
}

