using UnityEngine;

namespace Code
{
    public interface IInputService
    {

        public Vector2 Move();

        public float Look();

        public void Jump();
        public void Attack();
    }
}