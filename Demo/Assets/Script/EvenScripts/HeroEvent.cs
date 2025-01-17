﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroEvent : MonoBehaviour
{
    public RoleController roleController;

    private void Awake()
    {
        roleController = transform.parent.GetComponent<RoleController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnEnterJump()
    {
        
    }

    public void OnExitJump()
    {
        
    }

    public void OnEnterAttack()
    {
        roleController.SetPlayerInputEnable(false);
        roleController.SetWeaponActive(true);
    }

    public void OnExitAttack()
    {
        roleController.SetPlayerInputEnable(true);
        roleController.SetWeaponActive(false);
    }

    public void OnEnterShoot(string effectName)
    {
        roleController.SetShootEffect(effectName);
    }

    public void SetSwordEffect(int flag)
    {
        roleController.SetEffectActive(flag == 1);
    }

    public void OnEnterDie()
    {
        roleController.SetPlayerInputEnable(false);
    }

    public void OnEnterHit()
    {
        roleController.SetPlayerInputEnable(false);
    }

    public void OnExitHit()
    {
        roleController.SetPlayerInputEnable(true);
    }
}
