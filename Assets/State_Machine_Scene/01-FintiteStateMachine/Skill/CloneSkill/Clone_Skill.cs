using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone_Skill : Skill
{
    [Header("Clone Info")]
    [SerializeField] private GameObject clonePrefab;
    [SerializeField] private float cloneDuration;
    [SerializeField] private bool canAttack;

public void CreateClone(Transform _tranform){
    GameObject newClone= Instantiate(clonePrefab);
    newClone.GetComponent<Clone_Skill_Controller>().SetUpClone(_tranform,cloneDuration,canAttack);
}
    // public override void UseSkill(){
    //     base.UseSkill();
    //     Debug.Log("dashSkill");
    // }
}
