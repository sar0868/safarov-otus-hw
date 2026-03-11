using UnityEngine;

namespace Code
{
    public class Brick : MonoBehaviour
    {
        [SerializeField] private AudioClip _audioBreak;
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
            AudioSource.PlayClipAtPoint(_audioBreak, transform.position);
            Destroy(gameObject);
        }
    }
}
