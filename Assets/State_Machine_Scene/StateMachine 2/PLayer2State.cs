using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayer2State : PLayer2StateMachine
{
    // Start is called before the first frame update    
    Player2.Player_State2 oldState;
    Animator _animator;
    public override void changeAnim(Player2.Player_State2 state)
    {
        if(state==oldState)return;
        _animator.SetTrigger(state.ToString());
        oldState=state;
    }
    void Start()
    {
        _animator=this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
