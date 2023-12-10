using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IBaseState
{
    private bool _isMoving;
    private Vector3 _destination;
    
    public void EnterState(Enemy enemy)
    {
        _isMoving = false;
        enemy.animatorEnemy.SetTrigger("PatrolState");
    }

    public void UpdateState(Enemy enemy)
    {
        if (Vector3.Distance(enemy.transform.position, enemy.player.transform.position) < enemy.chaseDistance)
        {
            enemy.SwictchState(enemy.chaseState);
        }
        if (!_isMoving)
        {
            _isMoving = true;
            int index = Random.Range(0, enemy.waypoints.Count);
            _destination = enemy.waypoints[index].position;
            enemy.navMeshAgent.destination = _destination;
        }
        else
        {
            if (Vector3.Distance(_destination, enemy.transform.position) <= 0.1)
            {
                _isMoving = false;
            }
        }
    }

    public void ExitState(Enemy enemy)
    {
        Debug.Log("Stop Patrol");
    }
}
