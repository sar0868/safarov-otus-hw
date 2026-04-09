using UnityEngine;

namespace Code
{
    public sealed class RPG : Weapon
    {

        [SerializeField] private Rocket _rocketPrefab;

        private Rocket _instantiateRocket;
        private GameObject _rocket;

        protected override void Start()
        {
            base.Start();
            _rocket = transform.Find("Rocket").gameObject;
            Recharge();
        }
        public override void Fire()
        {
            if (_instantiateRocket)
            {
                _rocket.SetActive(false);
                _instantiateRocket.Run(_barrel.forward * Force, _barrel.position);
                _instantiateRocket = null;
                LastShootTime = 0.0f;
                _audioSource.PlayOneShot(_audioShot);
                CountBullets--;
            }

        }

        public override void Recharge()
        {
            if (_instantiateRocket)
            {
                return;
            }
            _instantiateRocket = Instantiate(_rocketPrefab, _barrel);
            _instantiateRocket.Sleep();
            _rocket.SetActive(true);
            CountBullets++;
        }
    }

}


