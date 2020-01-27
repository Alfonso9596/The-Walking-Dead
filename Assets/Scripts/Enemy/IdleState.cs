using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IEnemyState
{
    private Enemy enemy;

    private int currentWaypoint = 0;

    public int CurrentWaypoint
    {
        get { return currentWaypoint; }
        set
        {
            if (value < enemy.Waypoints.Length)
            {
                currentWaypoint = value;
            } else
            {
                currentWaypoint = 0;
            }
        }
    }
    
    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;
        this.enemy.Agent.speed = 4f;
        this.enemy.Agent.angularSpeed = 100f;
    }

    public void Execute()
    {
        if (enemy.Target != null && !GameManager.Instance.IsAlertActive)
        {
            enemy.ChangeState(new ChaseState());
        } else if (GameManager.Instance.IsAlertActive)
        {
            enemy.ChangeState(new AlertState());
        } else if (enemy.Target == null && !GameManager.Instance.IsAlertActive)
        {
            Idle();
        }
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            enemy.Target = collider.GetComponent<Player>();
        }
    }

    public void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            enemy.Target = null;
        }
    }

    private void Idle()
    {
        if (enemy.Agent.remainingDistance <= 0.01f)
        {
            enemy.SetNewTarget(enemy.Waypoints[CurrentWaypoint].position);
            CurrentWaypoint++;
        }
    }
}
