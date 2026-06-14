using System.Collections;
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
        [SerializeField] private string _enemyLayer = "Enemy";
        private CargoBahavior _cargo;
        private List<Transform> locations;
        private int locationIndex = 0;
        private NavMeshAgent _agent;
        private int _enemyMask;
        private bool _isMoving;


        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _cargo = GetComponent<CargoBahavior>();
            InitializePatrolEoute();
            MoveToNextPatrolLocation();
            _enemyMask = LayerMask.GetMask(_enemyLayer);
            _isMoving = true;
        }

        private void Update()
        {
            if (_agent.remainingDistance < 0.2f && _agent.pathPending == false)
            {
                MoveToNextPatrolLocation();
            }
            TargetEnemy();
        }

        private void MoveToNextPatrolLocation()
        {
            if (locations.Count == 0)
            {
                return;
            }
            _agent.SetDestination(locations[locationIndex].position);
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
            StopCargo();
            DetectDamage();
        }

        private void DetectDamage()
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, _radiusDamage, _enemyMask);
            StartCoroutine(GetDamage(hits.Length));

        }

        private IEnumerator GetDamage(int ememies)
        {
            yield return new WaitForSeconds(2f);
            _cargo.TakeDamage(ememies);

        }

        private void StopCargo()
        {
            _agent.isStopped = !_isMoving;
        }

        public void Stop()
        {
            _agent.isStopped = true;
        }
    }

}
