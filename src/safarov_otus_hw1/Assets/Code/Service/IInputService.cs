using UnityEngine;

namespace Code
{
    public interface IInputService
    {

        public Vector2 Move();

        public Vector2 Look();

        public bool Jump();
    }
}