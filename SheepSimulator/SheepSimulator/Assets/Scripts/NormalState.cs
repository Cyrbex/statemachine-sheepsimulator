using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalState : IEnemyState
{
    private StatePatternEnemy sheep;

    public NormalState(StatePatternEnemy statePatternEnemy)
    {
        sheep = statePatternEnemy;
    }

    public void OnTriggerEnter(Collider other)
    {
        
    }

    public void ToHungryState()
    {
        sheep.currentState = sheep.hungryState;
    }

    public void ToNormalState()
    {
        //Ei käytetä
    }

    public void ToRunAwayState()
    {
        sheep.currentState = sheep.runAwayState;
    }

    public void ToSleepState()
    {
        sheep.currentState = sheep.sleepState;
    }

    public void UpdateState()
    {
        Walk();
    }

    void Walk()
    {
        sheep.indicator.material.color = Color.green;
        sheep.navMeshAgent.speed = 1;

        if(sheep.navMeshAgent.remainingDistance <= sheep.navMeshAgent.stoppingDistance && !sheep.navMeshAgent.pathPending)
        {
            sheep.navMeshAgent.destination = sheep.transform.position + 
                new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));
        }

        sheep.navMeshAgent.isStopped = false;
    }

}
