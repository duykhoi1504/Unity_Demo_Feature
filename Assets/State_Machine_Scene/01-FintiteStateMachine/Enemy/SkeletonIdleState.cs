using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkeletonIdleState : EnemyState
{
    Enemy_Skeleton enemy;
    public SkeletonIdleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Skeleton _enemy) : base(_enemy, _stateMachine, _animBoolName)
    {
        enemy = _enemy;
    }
    public override void Enter()
    {
        base.Enter();
        stateTimer = 1f;
    }
    public override void Update()
    {
        base.Update();
        if (stateTimer < 0)
            stateMachine.changeState(enemy.moveState);
    }
    public override void Exit()
    {
        base.Exit();
    }
}
