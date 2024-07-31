using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    Enemy enemy;
    public IdleState(Enemy _enemy)
    {
        enemy = _enemy;
    }
    public void Enter()
    {
        Debug.Log("enter idle");
    }

    public void Exit()
    {
        Debug.Log("exit idle");
      
        
    }

    public void Update()
    {
        Debug.Log("update idle");
        if(enemy.xInput!=0){
              EnemyStateMachine.Instance.changeState(enemy.moveState);
        }

    }
}
public class MoveState : IState
{
    Enemy enemy;
    public MoveState(Enemy _enemy)
    {
         enemy = _enemy;
    }
    public void Enter()
    {
        Debug.Log("enter move");

    }

    public void Exit()
    {
        Debug.Log("exit move");

    }

    public void Update()
    {
        Debug.Log("update Move");

        if(enemy.xInput==0){
              EnemyStateMachine.Instance.changeState(enemy.idleState);
        }

    }
}

