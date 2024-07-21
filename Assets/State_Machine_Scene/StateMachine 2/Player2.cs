using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    // Start is called before the first frame update
    public enum Player_State2
    {
        Idle = 0,
        Move = 1,
    }

    [SerializeField] Player_State2 player_State2;
    [SerializeField] PLayer2StateMachine  _animator;
    void Start()
    {
        _animator = GetComponentInChildren<PLayer2StateMachine>();
    }
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            player_State2 = Player_State2.Move;
            
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            player_State2 = Player_State2.Idle;
        }
        UpdateAnim();
    }
     void UpdateAnim()
    {
        _animator.changeAnim(player_State2);
    }
}
