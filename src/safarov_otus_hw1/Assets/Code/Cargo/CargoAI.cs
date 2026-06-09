using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Code.Cargo
{
    public class CargoAI : MonoBehaviour
    {
        public Transform patrolRoute;
        [SerializeField] private float _radiusStop = 5f;
        [SerializeField] private float _radiusDamage = 1f;
        public int hp = 100;
        private List<Transform> locations;
        private int locationIndex = 0;
        private NavMeshAgent _agent;
        private int _enemyMask;
        private bool _isMoving;


        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            InitializePatrolEoute();
            MoveToNextPatrolLocation();
            _enemyMask = LayerMask.GetMask("Player");
            _isMoving = true;
        }

        private void Update()
        {
            if (_agent.remainingDistance < 0.2f && _agent.pathPending == false)
            {
                MoveToNextPatrolLocation();
            }
            TargetEnemy();
            DetectDamage();
            StopCargo();
        }

        private void MoveToNextPatrolLocation()
        {
            if (locations.Count == 0)
            {
                return;
            }
            _agent.destination = locations[locationIndex].position;
            locationIndex = (locationIndex + 1) % locations.Count;
        }

        private void InitializePatrolEoute()
        {
            locations = new();
            foreach (Transform location in patrolRoute)
            {
                locations.Add(location);
            }
        }

        private void TargetEnemy()
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, _radiusStop, _enemyMask);
            _isMoving = hits.Length == 0;
        }

        private void DetectDamage()
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, _radiusDamage, _enemyMask);

            GetDamage(hits.Length);

        }

        private void GetDamage(int ememies)
        {
            hp -= ememies;
        }

        private void StopCargo()
        {
            _agent.isStopped = !_isMoving;
        }
    }

}
