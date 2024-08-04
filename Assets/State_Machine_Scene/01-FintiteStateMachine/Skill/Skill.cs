using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Skill : MonoBehaviour
{
   [SerializeField]protected float coolDown;
   protected float coolDownTimer;
   protected Player player;
   
   protected virtual void Start(){
    player=PlayerManager.instance.player;
   }

    protected virtual void Update(){
        coolDownTimer-= Time.deltaTime;
    }
    public virtual bool CanUseSkill(){
        if(coolDownTimer<0){
            UseSkill();
            coolDownTimer=coolDown;
            return true;
        }
        return false;
    }
    public virtual void UseSkill(){
       
    }
}
