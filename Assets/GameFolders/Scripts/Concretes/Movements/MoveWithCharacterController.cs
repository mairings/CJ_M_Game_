using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdemyProject3.Abstract.Movements;
using UdemyProject3.Controllers;

namespace UdemyProject3.Movements
{
    public class MoveWithCharacterController : IMover
    {
        CharacterController _characterController;

        public MoveWithCharacterController(PlayerController playerController)
        {
            _characterController = playerController.GetComponent<CharacterController>();
          
        }

        public void MoveAction(Vector3 direction, float moveSpeed)
        {
            if (direction == Vector3.zero) return;

            Vector3 worldPosition = _characterController.transform.TransformDirection(direction);
            Vector3 movement = worldPosition * moveSpeed * Time.deltaTime;
            _characterController.Move(movement);
        }
    }
}

