using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Code
{
    public sealed class Enemy : MonoBehaviour
    {

        [SerializeField] private Animator _animator;
        [SerializeField] private Transform _patrolRoute;

        public List<Transform> locations;
        private int _locationIndex = 0;
        [SerializeField] private NavMeshAgent _agent;

        private void Start()
        {
            InitializePatrolRoute();
            // _agent = GetComponent<NavMeshAgent>();
            MoveToNextPatrolLocation();
        }

        private void Update()
        {
            if (_agent.remainingDistance < 0.2f && _agent.pathPending == false)
            {
                MoveToNextPatrolLocation();
            }
        }

        private void MoveToNextPatrolLocation()
        {
            if (locations.Count == 0)
            {
                return;
            }
            _agent.destination = locations[_locationIndex].position;
            _locationIndex = (_locationIndex + 1) % locations.Count;
        }

        private void InitializePatrolRoute()
        {
            foreach (Transform item in _patrolRoute)
            {
                locations.Add(item);
            }
        }

        public void ReactToHit()
        {

            StartCoroutine(Die());
            // _animator.SetBool("Death", true);
        }

        private IEnumerator Die()
        {

            transform.Rotate(-90f, 0f, 0f);
            yield return new WaitForSeconds(1f);

            gameObject.SetActive(false);
            // Destroy(gameObject);
        }
    }
}
