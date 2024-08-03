using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAbility : ScriptableObject
{
    // Start is called before the first frame updatep

    [SerializeField] private string abilityName; // Add SerializeField attribute

    public string AbilityName => abilityName; 
    public abstract void Use(PLayerController player);
     public abstract void UpdateCooldown(float deltaTime);
}
