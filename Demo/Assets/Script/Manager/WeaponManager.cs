using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

    //RoleManager
    public RoleManager roleManager;

    //WeaponController 武器控制器
    public WeaponController weaponController;

    private void Awake()
    {
        weaponController = transform.parent.Find("Model").DeepFind("WeaponController").GetComponent<WeaponController>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetWeaponActive(bool flag)
    {
        weaponController.SetWeaponActive(flag);
    }

    public void SetEffectActive(bool flag)
    {
        weaponController.SetEffectActive(flag);
    }

    public void ChangeWeapon(int id)
    {
        weaponController.ChangeWeapon(id);
    }
}
