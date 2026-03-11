using UnityEngine;

namespace Code
{
    public class Brick : MonoBehaviour
    {

        public int Hp { get; set; }

        public void Damage()
        {
            Hp--;
            if (Hp <= 0)
            {
                Break();
            }
        }

        private void Break()
        {
            Main.CountBrick--;
            Destroy(gameObject);
        }
    }
}
