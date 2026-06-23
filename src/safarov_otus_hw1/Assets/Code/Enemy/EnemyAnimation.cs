using UnityEngine;

namespace Code
{
    public class EnemyAnimation : MonoBehaviour
    {
        private Animator _animator;
        private string _death = "Death";
        private string _walk = "Walk";
        private string _attack = "Attack";
        private string _victory = "Victory";

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void AnimationWalk()
        {
            _animator.SetTrigger(_walk);
        }

        public void AnimationDeath()
        {
            _animator.SetTrigger(_death);
        }

        public void AnimationAttack(bool isAttack)
        {
            _animator.SetBool(_attack, isAttack);
        }

        public void AnimationVictory()
        {
            _animator.SetTrigger(_victory);
        }

    }
}

