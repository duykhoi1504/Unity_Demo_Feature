using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonStunnedState : EnemyState
{
    Enemy_Skeleton enemy;
    public SkeletonStunnedState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Skeleton _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        enemy = _enemy;
    }
    public override void Enter()
    {
        base.Enter();
        enemy.fx.InvokeRepeating("RedColorBlink",0,.1f);
        stateTimer = enemy.StunDuration;
        rb.velocity = new Vector2(enemy.stunDirection.x * -enemy.faceingDir, enemy.stunDirection.y);

    }
    public override void Update()
    {
        base.Update();
        if (stateTimer < 0)
            stateMachine.changeState(enemy.idleState);
    }
    public override void Exit()
    {
        base.Exit();
        enemy.fx.Invoke("CancelRedBlink",0);
    }

}
