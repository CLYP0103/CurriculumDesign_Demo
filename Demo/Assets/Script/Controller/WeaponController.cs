using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject m_Weapon;
    public GameObject m_Sowrd;
    public GameObject m_Gun;
    public GameObject m_Arrow;
    public GameObject m_Effect;

    private void Awake()
    {
        m_Weapon = transform.Find("Weapon").gameObject;
        m_Sowrd = m_Weapon.transform.Find("Sword").gameObject;
        m_Effect = m_Sowrd.transform.Find("Effect").gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 激活或关闭武器
    public void SetWeaponActive(bool flag)
    {
        m_Weapon.SetActive(flag);
    }

    // 特效激活
    public void SetEffectActive(bool flag)
    {
        m_Effect.SetActive(flag);
    }
}
