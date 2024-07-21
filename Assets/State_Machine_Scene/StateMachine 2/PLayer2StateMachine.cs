using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PLayer2StateMachine : MonoBehaviour
{
    public abstract void changeAnim(Player2.Player_State2 state);
}
