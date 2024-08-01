using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    public EnemyStateMachine stateMachine{get;private set;}
    protected Enemy enemyBase;

    protected bool triggerCalled;
    private string animBoolName;
    protected float stateTimer;

    public EnemyState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName)
    {
        this.enemyBase = _enemyBase;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Update()
    {
        
        stateTimer-=Time.deltaTime;
    }

    public virtual void Enter()
    {
        triggerCalled = false;
        enemyBase.anim.SetBool(animBoolName, true);
    }

    public virtual void Exit()
    {
        enemyBase.anim.SetBool(animBoolName, false);

    }
    //     public IdleState(Enemy _enemy)
    //     {
    //         enemy = _enemy;
    //     }
    //     public void Enter()
    //     {
    //         Debug.Log("enter idle");
    //     }

    //     public void Exit()
    //     {
    //         Debug.Log("exit idle");


    //     }

    //     public void Update()
    //     {
    //         Debug.Log("update idle");
    //         if(enemy.xInput!=0){
    //               EnemyStateMachine.Instance.changeState(enemy.moveState);
    //         }

    //     }
    // }
    // public class MoveState : IState
    // {
    //     Enemy enemy;
    //     public MoveState(Enemy _enemy)
    //     {
    //          enemy = _enemy;
    //     }
    //     public void Enter()
    //     {
    //         Debug.Log("enter move");

    //     }

    //     public void Exit()
    //     {
    //         Debug.Log("exit move");

    //     }

    //     public void Update()
    //     {
    //         Debug.Log("update Move");

    //         if(enemy.xInput==0){
    //               EnemyStateMachine.Instance.changeState(enemy.idleState);
    //         }

    //     }
}

