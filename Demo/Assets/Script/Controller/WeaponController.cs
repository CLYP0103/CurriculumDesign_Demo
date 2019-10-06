using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject m_Weapon;
    public GameObject m_Sowrd;
    public GameObject m_Gun;
    public GameObject m_Arrow;

    public GameObject m_NowWeapon;
    public GameObject m_Effect;

    public Dictionary<int, GameObject> m_WeaponDict;                        // 武器字典

    private void Awake()
    {

        m_WeaponDict = new Dictionary<int, GameObject>();
        m_Weapon = transform.Find("Weapon").gameObject;
        m_Sowrd = m_Weapon.transform.Find("Sword").gameObject;
        m_Gun = m_Weapon.transform.Find("Gun").gameObject;
        m_Effect = m_Sowrd.transform.Find("Effect").gameObject;
        m_NowWeapon = m_Sowrd;

        m_WeaponDict.Add(0, m_Sowrd);
        m_WeaponDict.Add(1, m_Gun);
        m_WeaponDict.Add(2, m_Arrow);
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
        m_NowWeapon.SetActive(flag);
    }

    // 特效激活
    public void SetEffectActive(bool flag)
    {
        m_Effect.SetActive(flag);
    }

    public void ChangeWeapon(int id)
    {
        m_NowWeapon = m_WeaponDict[id];
        m_Effect = m_NowWeapon.transform.Find("Effect").gameObject;
    }

    public void SetShootEffect(string effectName,Vector3 direction)
    {
        GameObject go = ObjectPoolManager.Instacne.GetGameObject(effectName);
        //go.transform.position = m_Effect.transform.position;
        go.transform.position = m_Effect.transform.position;
        go.transform.forward = direction;
        go.transform.parent = null;
        go.GetComponent<Rigidbody>().velocity = direction* 30f ;
    }
}
