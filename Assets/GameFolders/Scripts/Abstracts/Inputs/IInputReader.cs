using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject3.Abstract.Inputs
{
        public interface IInputReader
        {
            Vector3 Direction { get; }
            Vector2 Rotation { get; }
            bool IsAttackButtonPress { get;}

    }

}
