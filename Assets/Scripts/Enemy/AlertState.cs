using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertState : IEnemyState
{
    private Enemy enemy;

    public void Enter (Enemy enemy)
    {
        this.enemy = enemy;
        enemy.Agent.speed = 8f;
    }

    public void Execute()
    {
        if (GameManager.Instance.IsAlertActive)
        {
            enemy.Agent.SetDestination(GameManager.Instance.Player.transform.position);
        } 
        else if (enemy.Target != null && !GameManager.Instance.IsAlertActive)
        {
            enemy.ChangeState(new ChaseState());
        }
        else if (enemy.Target == null && !GameManager.Instance.IsAlertActive)
        {
            enemy.ChangeState(new IdleState());
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
}
