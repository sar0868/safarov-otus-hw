using UnityEngine;

namespace Code
{
    public sealed class Attack : MonoBehaviour
    {
        [SerializeField] private NewInputService _inputService;
        // [SerializeField] private OldInputService _inputService;
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _inputService.attackEvent.AddListener(Slash);
        }

        public void Slash()
        {
            _animator.SetTrigger("Slash");
        }
    }
}

