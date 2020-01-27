using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Transform[] waypoints;

    private IEnemyState currentState;
    private NavMeshAgent agent;

    private Vector3 lastPlayerPosition;

    public Player Target { get; set; } = null;

    public Transform[] Waypoints
    {
        get { return waypoints; }
    }

    public NavMeshAgent Agent
    {
        get { return agent; }
    }

    public Vector3 LastPlayerPosition
    {
        get { return lastPlayerPosition; }
        set { lastPlayerPosition = value; }
    }
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ChangeState(new IdleState());
    }

    void Update()
    {
        currentState.Execute();
    }

    public void ChangeState(IEnemyState newState)
    {
        currentState = newState;
        currentState.Enter(this);
    }

    public void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(other);
    }

    public void OnTriggerExit(Collider other)
    {
        currentState.OnTriggerExit(other);
    }

    public void SetNewTarget(Vector3 target)
    {
        agent.SetDestination(target);
    }
}
