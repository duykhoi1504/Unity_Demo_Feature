using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimEvents : MonoBehaviour
{
    // Start is called before the first frame update
    private PLayerController player;
    void Start()
    {
        player=GetComponentInParent<PLayerController>();
    }

    // Update is called once per frame
    private void AnimationTrigger(){
        player.AttackingOver();
    }
   
}
