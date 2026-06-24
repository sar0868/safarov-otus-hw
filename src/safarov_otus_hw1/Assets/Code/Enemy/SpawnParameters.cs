using System;
using UnityEngine;

namespace Code
{
    public sealed class SpawnParameters : MonoBehaviour
    {
        [SerializeField] private Transform _positionSpawnEnemy;
        [SerializeField] private int _count;
        [SerializeField] private PatrolRoute _patrolRoute;
        [SerializeField] private Conditions _conditions;

        // public Params GetParams()
        // {
        //     return new Params(
        //         _positionSpawnEnemy,
        //         _count,
        //         _patrolRoute,
        //         _conditions);
        // }

    }

    // [Serializable]
    // public struct Params
    // {
    //     public Transform positionSpawnEnemy;
    //     public int count;
    //     public PatrolRoute patrolRoute;
    //     public Conditions conditions;

    //     public Params(
    //         Transform positionSpawnEnemy,
    //         int count,
    //         PatrolRoute patrolRoute,
    //         Conditions conditions
    //         )
    //     {
    //         this.positionSpawnEnemy = positionSpawnEnemy;
    //         this.count = count;
    //         this.patrolRoute = patrolRoute;
    //         this.conditions = conditions;
    //     }
    // }
}
