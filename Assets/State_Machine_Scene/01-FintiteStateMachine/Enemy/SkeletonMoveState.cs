using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMoveState : SkeletonGroundedState
{
    
    public SkeletonMoveState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Skeleton _enemy) : base(_enemyBase, _stateMachine, _animBoolName, _enemy)
    {
    }

    public override void Enter()
    {
        base.Enter();

    }
    public override void Update()
    {
        base.Update();
        Debug.Log("update move");
        enemy.SetVelocity(enemy.moveSpeed * enemy.faceingDir,rb.velocity.y);
        if (enemy.IsWallDetected() || !enemy.IsGroundDetected() )
        {
            enemy.Flip();
            stateMachine.changeState(enemy.idleState);
        }
       
    }
    public override void Exit()
    {
        base.Exit();
    }
}
