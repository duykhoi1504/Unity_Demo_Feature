using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SkeletonGroundedState : EnemyState
{
    protected Enemy_Skeleton enemy;
    protected Transform player;
    public SkeletonGroundedState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName,Enemy_Skeleton _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        enemy = _enemy;
    }
    public override void Enter()
    {
        base.Enter();
        // player=GameObject.FindObjectOfType<Player>();
        player=PlayerManager.instance.player.transform;

    
    }
    public override void Update()
    {
        base.Update();
        if(enemy.IsPLayerDetected() || Vector2.Distance(enemy.transform.position,player.transform.position)<2){
            stateMachine.changeState(enemy.battleState);
        }
    }
    public override void Exit()
    {
        base.Exit();
    }
    
}
