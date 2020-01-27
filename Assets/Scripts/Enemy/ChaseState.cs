using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : IEnemyState
{
    private Enemy enemy;

    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;
        enemy.Agent.speed = 7f;
    }

    public void Execute()
    {
        if (enemy.Target != null && !GameManager.Instance.IsAlertActive)
        {
            RaycastHit hit;
            Physics.Raycast(enemy.transform.position, (GameManager.Instance.Player.transform.position - enemy.transform.position), out hit, 10f);

            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Player"))
                {
                    enemy.LastPlayerPosition = hit.collider.transform.position;
                }
                enemy.Agent.SetDestination(enemy.LastPlayerPosition);
            }
        }
        else if (GameManager.Instance.IsAlertActive)
        {
            enemy.ChangeState(new AlertState());
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
