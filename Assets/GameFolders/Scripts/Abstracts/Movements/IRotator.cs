﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UdemyProject3.Abstract.Movements
{

    public interface IRotator
    {
        void RotationAction(float direction, float speed);
    }
}