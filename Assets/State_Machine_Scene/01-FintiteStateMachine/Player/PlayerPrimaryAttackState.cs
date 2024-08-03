using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrimaryAttackState : PlayerState
{
  private int comboCounter;
  private float lastTimeAttack;
  private float comboWindow = 2;
  public PlayerPrimaryAttackState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
  {
  }

  public override void Enter()
  {
    base.Enter();
    //đảm bảo rằng hướng tấn công của nhân vật luôn dựa trên faceingDir , 
    //mà không bị ảnh hưởng bởi các lần di chuyển trước đó.

    xInput = 0;//need for fix bug on attack wrong direction

    if (comboCounter > 2 || Time.time > lastTimeAttack + comboWindow)
      comboCounter = 0;

    player.anim.SetInteger("ComboCounter", comboCounter);

    player.anim.speed = .9f;
    // Debug.Log(comboCounter);



    float attackDir = player.faceingDir;
    if (xInput != 0){
    // Debug.Log("xinput:"+ xInput);
      attackDir = xInput;
    }
    player.SetVelocity(player.attackMovement[comboCounter].x * attackDir, player.attackMovement[comboCounter].y);
    stateTimer = .1f;
  }
  public override void Exit()
  {
    base.Exit();

    player.StartCoroutine("BusyFor", .15f);
    player.anim.speed = 1f;

    comboCounter++;
    lastTimeAttack = Time.time;
    // Debug.Log(lastTimeAttack);


  }
  public override void Update()
  {
    base.Update();
    if (stateTimer < 0)
    {
      player.SetZeroVelocity();

    }
    if (triggerCalled)
    {
      stateMachine.ChangeState(player.idleState);
    }
  }
}
