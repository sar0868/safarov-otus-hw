using UnityEngine;

namespace Code
{
    public class Brick : MonoBehaviour
    {
        public int Hp { get; set; }

        public bool Damage()
        {
            Hp--;
            if (Hp <= 0)
            {
                Break();
            }
            return Hp > 0;
        }

        private void Break()
        {
            Main.CountBrick--;
            Destroy(gameObject);
        }
    }
}
