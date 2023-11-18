using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdemyProject3.Abstract.Movements;
using UdemyProject3.Controllers;
namespace UdemyProject3.Movements
{
    public class RotatorY : IRotator
    {
        Transform _transform;
        PlayerController _playerController;
        float _tilt;
        public RotatorY(PlayerController playerController)
        {
            _transform = playerController.TurnTransform;
        }

        public void RotationAction(float direction, float speed)
        {

                direction *= speed * Time.deltaTime;
                _tilt = Mathf.Clamp(_tilt - direction, -30, 30);
                _transform.localRotation = Quaternion.Euler(_tilt, 0f, 0f);

        }


    }
}

