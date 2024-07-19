using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PLayerFire")]
public class PLayerFire : PlayerAbility
{
    [SerializeField] GameObject killVFX;
        [SerializeField] private float killCoolDown;
    
    private float killCoolDownTimer;
      private void OnEnable()
    {
        // Ensuring the cooldown timer is reset when the scriptable object is enabled
        killCoolDownTimer = 0f;
    }
    public override void Use(PLayerController player)
    {
        if (killCoolDownTimer <= 0f)
        {
            // Ability can be used
            killCoolDownTimer = killCoolDown;
            Debug.Log("Skill 2 used");

            // Instantiate the visual effects at the player's position
            Vector2 hitPos=new Vector2(player.transform.position.x + 3f*player.transform.localScale.x, player.transform.position.y);
            GameObject fx = Instantiate(killVFX, hitPos, Quaternion.identity);
            
            Destroy(fx, 2f);
        }
        else
        {
            Debug.Log("Skill is on cooldown");
        }
    }
     public override void UpdateCooldown(float deltaTime)
    {
        if (killCoolDownTimer > 0f)
        {
            killCoolDownTimer -= deltaTime;
        }
    }
}
