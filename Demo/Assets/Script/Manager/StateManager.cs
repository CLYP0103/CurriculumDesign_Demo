using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public RoleManager roleManager;
    public int HP;

    // Start is called before the first frame update
    void Start()
    {
        HP = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("EnemyWeapon"))
        {
            DoDamage();
        }
    }

    private void DoDamage()
    {
        HP--;
        if (HP <= 0) 
        {
            roleManager.SetTrigger("die");
        }
        else
        {
            roleManager.SetTrigger("hit");
        }
    }
}
