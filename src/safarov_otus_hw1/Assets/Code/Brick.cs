using UnityEngine;

namespace Code
{
    public class Brick : MonoBehaviour
    {
        private LevelGenerator _levelGenerator;

        public int Hp { get; set; }

        public void Init(LevelGenerator levelGenerator)
        {
            _levelGenerator = levelGenerator;
        }

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
            _levelGenerator.DecrementBrick();
            Destroy(gameObject);
        }
    }
}
