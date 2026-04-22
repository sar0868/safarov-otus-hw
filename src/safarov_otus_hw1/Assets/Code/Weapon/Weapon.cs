using UnityEngine;

namespace Code
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(AudioSource))]
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected int _level = 1;
        [SerializeField] protected Transform _barrel;
        [SerializeField] protected WeaponUpgradeData _weaponUpgradeData;
        [SerializeField] protected AudioSource _audioSource;
        [SerializeField] protected AudioClip _audioShot;

        private int _cntBullets;
        private Collider _collider;
        private Transform _player;
        private float _shotDelay;
        private Transform _weaponRoot;

        public bool CanShot { get; private set; }
        public float LastShootTime { get; protected set; }
        protected float Force { get; private set; }
        public int CountBullets { get => _cntBullets; set => _cntBullets = value; }


        protected void Awake()
        {
            _collider = GetComponent<Collider>();
            _collider.isTrigger = true;
            _player = Camera.main.transform;
            _weaponRoot = FindAnyObjectByType<TargetMarkerWeaponRoot>().transform;
        }

        protected virtual void Start()
        {
            _level = DropdownHundler.level;
            _weaponUpgradeData.TryGetDataLevel(_level, out WeaponData data);

            _shotDelay = data.ShotDelay;
            Force = data.Force;
        }

        private void Update()
        {
            CanShot = _shotDelay <= LastShootTime;

            if (CanShot)
            {
                return;
            }
            LastShootTime += Time.deltaTime;
        }

        public abstract void Fire();
        public abstract void Recharge();

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }

        protected void OnTriggerEnter(Collider other)
        {
            transform.SetParent(_weaponRoot);
            _player.TryGetComponent(out WeaponController weaponController);
            weaponController.AddWeapon(this);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
        }
    }
}
