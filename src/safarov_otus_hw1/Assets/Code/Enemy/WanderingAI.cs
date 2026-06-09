using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Code.Enemy
{
    public class WanderingAI : MonoBehaviour
    {
        public Transform patrolRoute;
        private List<Transform> locations;
        private int locationIndex = 0;
        private NavMeshAgent _agent;

        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            InitializePatrolEoute();
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
    }

}
