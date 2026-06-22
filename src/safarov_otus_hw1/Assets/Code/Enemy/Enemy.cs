using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Code
{
    public sealed class Enemy : MonoBehaviour
    {

        [SerializeField] private Transform _patrolRoute;
        [SerializeField] private Conditions _conditions;

        public List<Transform> locations;

        private Animator _animator;
        private int _locationIndex = 0;
        private NavMeshAgent _agent;
        [SerializeField] private int _hp = 3;
        // private Renderer _renderer;
        private string death = "Death";
        private string walk = "Walk";

        public int Hp { get => _hp; set => _hp = value; }

        private void Start()
        {
            InitializePatrolRoute();
            _agent = GetComponent<NavMeshAgent>();
            // _renderer = GetComponent<Renderer>();
            _animator = GetComponent<Animator>();
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
            _animator.SetTrigger(walk);
        }

        private void InitializePatrolRoute()
        {
            foreach (Transform item in _patrolRoute)
            {
                locations.Add(item);
            }
        }

        public void ReactToHit(int damage)
        {

            Damage(damage);
        }

        private void Damage(int damage)
        {
            _hp -= damage;
            if (_hp <= 0)
            {
                StartCoroutine(Die());
            }
        }

        private IEnumerator Die()
        {
            _conditions.KilledEnemy();
            _agent.isStopped = true;
            _animator.SetTrigger(death);
            // _renderer.material.color = Color.green;
            yield return new WaitForSeconds(1f);
            // gameObject.SetActive(false);
            // Destroy(gameObject);
        }


    }
}
