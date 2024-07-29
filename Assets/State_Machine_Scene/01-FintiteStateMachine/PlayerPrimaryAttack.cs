using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrimaryAttack : PlayerState
{
  private int comboCounter;
  private float lastTimeAttack;
  private float comboWindow = 2;
  public PlayerPrimaryAttack(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
  {
  }

  public override void Enter()
  {
    base.Enter();

    if (comboCounter > 2 || Time.time > lastTimeAttack + comboWindow)
      comboCounter = 0;

    player.anim.SetInteger("ComboCounter",comboCounter); 
    Debug.Log(comboCounter);
  }
  public override void Exit()
  {
    base.Exit();
    comboCounter++;
    lastTimeAttack = Time.time;
    // Debug.Log(lastTimeAttack);


  }
  public override void Update()
  {
    base.Update();
    if (triggerCalled)
    {
      stateMachine.ChangeState(player.idleState);
    }
  }
}
