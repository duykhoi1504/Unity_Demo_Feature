using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTrigger : MonoBehaviour
{
    private Player player => GetComponentInParent<Player>();
    // Start is called before the first frame update
    private void AnimationTrigger(){
        player.AimationTrigger();
    }
}
