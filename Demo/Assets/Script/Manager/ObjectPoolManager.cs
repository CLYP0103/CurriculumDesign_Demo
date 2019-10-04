using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    private static ObjectPoolManager m_Instance;

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
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
