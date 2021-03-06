﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MultiplayerPrototype.Abstracts.Movements
{
    public interface IMover
    {
        void TickFixed(float direction, float moveSpeed);
    }
}