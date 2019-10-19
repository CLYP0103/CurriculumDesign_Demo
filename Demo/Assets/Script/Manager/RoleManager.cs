using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleManager : MonoBehaviour {

    public RoleController roleController;

    //[Header("===== 角色各种Manager =====")]
    //[Header("===== StateManager =====")]
    ////StateManager 负责管理角色属性 例如生命
    public StateManager stateManager;
    //public bool add;
    //public bool reduce;

    [Header("===== WeaponManager =====")]
    //WeaponManager 负责角色武器
    public WeaponManager weaponManager;

    //[Header("===== BattleManager =====")]
    ////BattleManager 负责角色战斗
    //public BattleManager battleManager;

    //[Header("===== KnapsackManager =====")]
    ////KnapsackManager 负责角色背包系统
    //public KnapsackManager knapsackManager;
    //public bool isOpenKnapsack;

    private void Awake()
    {
        //获取 StateManager
        stateManager = transform.DeepFind("Sensor").GetComponent<StateManager>();
        stateManager.roleManager = this;

        //获取 WeaponManager
        weaponManager = transform.Find("WeaponHandle").GetComponent<WeaponManager>();
        weaponManager.roleManager = this;

        //获取 BattleManager
        //battleManager = GetComponentInChildren<BattleManager>();
        //battleManager.roleManager = this;

        //获取 KnapsackManager
        //knapsackManager = GetComponentInChildren<KnapsackManager>();
        //knapsackManager.roleManager = this;
        //isOpenKnapsack = false;

        //获取 RoleController
        roleController = GetComponent<RoleController>();
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


    }


    public void SetWeaponActive(bool flag)
    {
        weaponManager.SetWeaponActive(flag);
    }

    public void SetEffectActive(bool flag)
    {
        weaponManager.SetEffectActive(flag);
    }

    public void ChangeWeapon(int id)
    {
        roleController.SetAnimatorFloat("attackId", id);
        weaponManager.ChangeWeapon(id);
    }

    public void SetShootEffect(string effectName, Vector3 direction)
    {
        weaponManager.SetShootEffect(effectName, direction);
    }

    public void SetTrigger(string triggerName)
    {
        roleController.SetAnimatorTrigger(triggerName);
    }
}
