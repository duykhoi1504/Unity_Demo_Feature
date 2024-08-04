using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    public PlayerDashState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        player.skill.clone.CreateClone(player.transform);
        stateTimer = player.dashDuration;

    }
    public override void Exit()
    {
        // player.SetVelocity(player.dashSpeed * player.dashDir, 26f);
        base.Exit();
        player.SetVelocity(0, rb.velocity.y);
        if (!player.IsGroundDetected())
        {
            rb.AddForce(new Vector2(player.dashSpeed * 20f * player.faceingDir, rb.velocity.y));
        }


    }
    public override void Update()
    {
        base.Update();
        // Debug.Log("Iam doing dash");
        if (!player.IsGroundDetected() && player.IsWallDetected())
        {
            stateMachine.ChangeState(player.wallSlide);
        }
        player.SetVelocity(player.dashSpeed * player.dashDir, 0);

        if (stateTimer < 0)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
