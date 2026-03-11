using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _soundTouch;


        private Transform _ballTarget;
        private Vector2 _direction;
        private bool _isStartGame;

        public float Speed { get; set; }
        public int Life { get; set; }

        private void Update()
        {
            if (_isStartGame)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    float range = Random.Range(-1.0f, 1.0f);
                    transform.parent = null;
                    SetVelocity(new Vector2(range, 1).normalized);
                    _isStartGame = false;
                }
            }

        }

        private void SetVelocity(Vector2 direction)
        {
            _direction = direction;
            _rigidbody.linearVelocity = _direction * Speed;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.TryGetComponent(out Brick brick))
            {

                if (brick.Damage())
                {
                    _audioSource.clip = _soundTouch;
                    _audioSource.Play();
                }

            }

            if (collision.transform.TryGetComponent(out DeadZone deadZone))
            {
                if (Life <= 0f)
                {
                    SceneManager.LoadScene(2);
                }
                Life--;
                CreateBall();
            }
            if (collision.transform.TryGetComponent(out TopZone _))
            {
                float range = Random.Range(-1.0f, 1.0f);
                SetVelocity(new Vector2(range, -1).normalized);
            }
            if (collision.gameObject.CompareTag("TouchZone"))
            {
                if (_isStartGame)
                {
                    return;
                }
                _audioSource.clip = _soundTouch;
                _audioSource.Play();
            }
        }

        public void CreateBall()
        {
            _ballTarget = FindAnyObjectByType<BallTarget>().transform;

            transform.SetParent(_ballTarget);
            transform.position = _ballTarget.position;
            _isStartGame = true;
            _rigidbody.linearVelocity = Vector3.zero;
        }
    }
}
