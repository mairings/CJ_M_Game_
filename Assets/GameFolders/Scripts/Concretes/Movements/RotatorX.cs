﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdemyProject3.Abstract.Movements;
using UdemyProject3.Controllers;

namespace UdemyProject3.Movements
{
    public class RotatorX : IRotator
    {
        PlayerController _playerController;
        public RotatorX(PlayerController playerController)
        {
            _playerController = playerController;
        }
        public void RotationAction(float direction, float speed)
        {

                _playerController.transform.Rotate(Vector3.up * direction * Time.deltaTime * speed);
            
            //_playerController.transform.Translate(Vector3.right * direction * Time.deltaTime * speed);

        }
    }
}

