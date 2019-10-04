using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    private static ObjectPoolManager m_Instance;
    private Dictionary<string, string> m_PrefabPathDict;
    private Dictionary<string, List<GameObject>> m_PrefabDict;


    public static ObjectPoolManager Instacne
    {
        get
        {
            return m_Instance;
        }
    }

    private void Awake()
    {
        m_Instance = this;
        m_PrefabPathDict = new Dictionary<string, string>();
        m_PrefabDict = new Dictionary<string, List<GameObject>>();
    }

    private void Init()
    {
        // 添加预制路径
        m_PrefabPathDict.Add("", "");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetGameObject(string key)
    {
        List<GameObject> list;
        if (m_PrefabDict.TryGetValue(key, out list))
        {
            if(list.Count > 0)
            {
                GameObject go = list[0];
                go.SetActive(true);
                list.RemoveAt(0);
                return go;
            }
            else
            {
                string path = m_PrefabPathDict[key];
                GameObject go = GameObject.Instantiate(Resources.Load<GameObject>(path));
                return go;
            }
        }
        else
        {
            list = new List<GameObject>();
            m_PrefabDict[key] = list;
            string path = m_PrefabPathDict[key];
            GameObject go = GameObject.Instantiate(Resources.Load<GameObject>(path));
            return go;
        }
    }

    public void RecycleGameObject(string key, GameObject go)
    {
        List<GameObject> list;
        go.SetActive(false);
        if (m_PrefabDict.TryGetValue(key, out list))
        {
            list.Add(go);
        }
        else
        {
            list = new List<GameObject>();
            list.Add(go);
            m_PrefabDict.Add(key, list);
        }
    }
}
