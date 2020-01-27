using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyState 
{
    void Execute();
    void Enter(Enemy enemy);
    void OnTriggerEnter(Collider collider);
    void OnTriggerExit(Collider collider);
}
