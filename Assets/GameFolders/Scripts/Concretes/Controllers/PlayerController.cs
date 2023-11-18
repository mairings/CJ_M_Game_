using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdemyProject3.Abstract.Inputs;
using UdemyProject3.Abstract.Movements;
using UdemyProject3.Movements;
using UdemyProject3.Animations;


namespace UdemyProject3.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Movement Informations")]
        [SerializeField] float _moveSpeed = 10f;
        [SerializeField]float _turnSpeed = 10f;
        [SerializeField] Transform _turnTransform;
        [SerializeField] WeaponController _currentWeapon;

        IInputReader _input;
        IMover _mover;
        IRotator _xRotation;
        IRotator _yRotation;

        CharacterAnimation _animation;

        Vector3 _direction;

        public Transform TurnTransform => _turnTransform;

        private void Awake()
        {
            _input = GetComponent<IInputReader>();
            _mover = new MoveWithCharacterController(this);
            _animation = new CharacterAnimation(this);
            _xRotation = new RotatorX(this);
            _yRotation = new RotatorY(this);
        }
        private void Update()
        {
            _direction = _input.Direction;
            _xRotation.RotationAction(_input.Rotation.x, _turnSpeed);
            _yRotation.RotationAction(_input.Rotation.y, _turnSpeed);

            if (_input.IsAttackButtonPress)
            {
                _currentWeapon.Attack();
            }
        }
        private void FixedUpdate()
        {
            _mover.MoveAction(_direction, _moveSpeed);
 
            
        }
        private void LateUpdate()
        {
            _animation.MoveAnimation(_direction.magnitude);
        }
    }
}

