using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    public static EnemyStateMachine Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    public IState currentState;


    public void initState(IState state)
    {
        currentState = state;
        currentState.Enter();
    }
    public void changeState(IState newState)
    {
        currentState.Exit();

        currentState = newState;

        currentState.Enter();
    }
    // void Update(){
    //     currentState.Update();
    // }
}
