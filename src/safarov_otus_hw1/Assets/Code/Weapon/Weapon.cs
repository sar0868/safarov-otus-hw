using UnityEngine;

namespace Code
{
    [RequireComponent(typeof(Collider))]
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected int _level = 1;
        [SerializeField] protected Transform _barrel;
        [SerializeField] protected WeaponUpgradeData _weaponUpgradeData;
        private Collider _collider;

        private float _shotDelay;

        public bool CanShot { get; private set ; }
        public float LastShootTime { get; protected set; }
        protected float Force { get; private set; }

        protected void Awake()
        {
            _collider = GetComponent<Collider>();
            _collider.isTrigger = true;
        }

        protected virtual void Start()
        {
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
            Transform player = GameObject.FindGameObjectWithTag("MainCamera").transform;
            Transform weaponRoot = player.transform.Find("WeaponsRoot");
            transform.SetParent(weaponRoot);
            var weaponController = player.GetComponent<WeaponController>();
            weaponController.AddWeapon(this);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
        }
    }
}
