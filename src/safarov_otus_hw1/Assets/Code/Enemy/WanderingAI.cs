using System;
using System.Collections.Generic;
using Mono.Cecil;
using UnityEngine;
using UnityEngine.AI;

namespace Code.Enemy
{
    public class WanderingAI : MonoBehaviour
    {
        public Transform patrolRoute;
        [SerializeField] private float _radius = 5f;
        [SerializeField] private float _distance = 5f;
        private List<Transform> locations;
        private int locationIndex = 0;
        private NavMeshAgent _agent;
        private int _cargo;
        private readonly string _layerName = "Cargo";
        private bool _findTarger = false;


        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            InitializePatrolRoute();
            MoveToNextPatrolLocation();
            _cargo = LayerMask.GetMask(_layerName);
        }

        private void Update()
        {
            if (_findTarger == false)
            {
                if (_agent.remainingDistance < 0.2f && _agent.pathPending == false)
                {
                    MoveToNextPatrolLocation();
                }
            }
            TargetCargo();

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

        private void InitializePatrolRoute()
        {
            locations = new();
            foreach (Transform location in patrolRoute)
            {
                locations.Add(location);
            }
        }
        private void TargetCargo()
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, _radius, out hit, _distance, _cargo))
            {
                if (hit.distance <= 1f)
                {
                    _agent.isStopped = true;
                    return;
                }
                // else
                // {
                //     _agent.isStopped = !_agent.isStopped;
                // }
                _findTarger = true;
                Vector3 target = hit.transform.position;
                _agent.SetDestination(target);
            }
            else
            {
                _findTarger = false;
                _agent.isStopped = false;
            }
            // Оптимизация для движущейся цели: При преследовании постоянно вызывать 
            // SetDestination в Update может быть затратно для процессора. Лучше вызывать 
            // этот метод через корутину или обновлять его только тогда, когда цель 
            // сдвинулась на определенное расстояние.

        }

    }

}
