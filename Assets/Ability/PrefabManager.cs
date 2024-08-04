using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{

    public static PrefabManager Instance { get; private set; }
    [System.Serializable]
    //[System.Serializable]  ->
    //Unity sẽ tự động tạo một inspector GUI cho class đó, cho phép bạn chỉnh sửa các thuộc tính trong editor
    public class AbilityData
    {
        public string abilityName;
        public PlayerAbility ability;
    }

    // public List<PlayerAbility> Abilities;
    public List<AbilityData> Abilities = new List<AbilityData>();
    public PLayerController player;
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        // Update cooldowns for all abilities
        foreach (var abilityData in Abilities)
        {
            abilityData.ability.UpdateCooldown(Time.deltaTime);
        }
    }
    public void UseAbility(int index)
    {
        if (index >= Abilities.Count) return;
        var abilityData = Abilities[index];
        Debug.Log($"Using ability: {abilityData.abilityName}");
        abilityData.ability.Use(player);
    }

}
