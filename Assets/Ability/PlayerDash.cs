using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dash")]
public class PLayerDash : PlayerAbility
{
    [SerializeField] private GameObject killVFX;
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
            Debug.Log("Skill 1 used");

            // Instantiate the visual effects at the player's position
            GameObject fx = Instantiate(killVFX, player.transform.position, Quaternion.identity);
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