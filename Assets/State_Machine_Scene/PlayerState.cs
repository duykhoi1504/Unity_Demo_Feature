using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerState
{
    
    protected PlayerStateMachine stateMachine;
    protected Player player;
    private string aniBoolName;
    public PlayerState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName)
    {
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.aniBoolName = _animBoolName;
    }
    public virtual void Enter()
    {
        Debug.Log("I enter " + aniBoolName);
    }
    public virtual void Update()
    {
        Debug.Log("I am in " + aniBoolName);

    }
    public virtual void Exit()
    {
        Debug.Log("I exit " + aniBoolName);

    }
}
