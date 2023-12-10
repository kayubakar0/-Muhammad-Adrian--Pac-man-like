using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private IBaseState _currentState;
    public PatrolState patrolState = new PatrolState();
    public ChaseState chaseState = new ChaseState();
    public RetreatState retreatState = new RetreatState();
    
    //list waypoint
    public List<Transform> waypoints = new List<Transform>();
    
    //Navmesh Agent
    [HideInInspector] public NavMeshAgent navMeshAgent;
    
    //Player Component
    public float chaseDistance;
    public Player player;
    
    //Animator
    [HideInInspector]
    public Animator animatorEnemy;

    private void Awake()
    {
        animatorEnemy = GetComponent<Animator>();
        
        _currentState = patrolState;
        _currentState.EnterState(this);
        
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        if (player != null)
        {
            player.OnPowerUpStart += StartRetreating;
            player.OnPowerUpStop += StopRetreating;
        }
    }

    private void Update()
    {
        if (_currentState != null)
        {
            _currentState.UpdateState(this);
        }
    }

    public void SwictchState(IBaseState state)
    {
        _currentState.ExitState(this);
        _currentState = state;
        _currentState.EnterState(this);
    }

    private void StartRetreating()
    {
        SwictchState(retreatState);
    }

    private void StopRetreating()
    {
        SwictchState(patrolState);
    }

    public void Dead()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (_currentState != retreatState)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.GetComponent<Player>().Dead();
            }
        }
    }
}
