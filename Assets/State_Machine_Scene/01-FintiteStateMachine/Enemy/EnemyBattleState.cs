using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBattleState : EnemyState

{
    float distanceEtoP;
    Enemy_Skeleton enemy;
    private Player player;

    public SkeletonBattleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Skeleton _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        enemy = _enemy;
    }
    public override void Enter()
    {
        base.Enter();
        player = GameObject.FindObjectOfType<Player>();

        // Debug.Log("iam baatllte");
    }
    public override void Update()
    {
        base.Update();
        if (enemy.IsPLayerDetected())
        {
                stateTimer=enemy.battleTime;
            if (enemy.IsPLayerDetected().distance < enemy.attackDistance)
            {
                if(canAttack())
                stateMachine.changeState(enemy.attackState);
            }
        }else{
            if(stateTimer<0 ||Vector2.Distance(player.transform.position,enemy.transform.position)>15)
                stateMachine.changeState(enemy.idleState);

        }
        // distanceEtoP= (player.transform.position-enemy.transform.position).magnitude;
        // Debug.Log("khoang cach "+distanceEtoP);
        Vector2 moveDir = (player.transform.position - enemy.transform.position).normalized;
        //  Debug.Log("huong "+ moveDir);
        // if(distanceEtoP<=5){

        enemy.SetVelocity(enemy.moveSpeed * moveDir.x, rb.velocity.y);
        // }else{
        //     stateMachine.changeState(enemy.moveState);
        // }

    }
    public override void Exit()
    {
        base.Exit();
    }
    bool canAttack(){
        if(Time.time>=enemy.lastTimeAttacked+enemy.attackCoolDown){
            enemy.lastTimeAttacked=Time.time;
            return true;
        }
        return false;
    
    }
}
