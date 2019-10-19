using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferModelController : MonoBehaviour
{
    public TransferController m_TransferController;

    private void Awake()
    {
        m_TransferController = transform.parent.parent.GetComponent<TransferController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Arrvie(string destination)
    {
        print(destination);
        m_TransferController.EndTransfer(destination);
    }
}
