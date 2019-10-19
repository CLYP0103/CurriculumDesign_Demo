using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferPointsController : MonoBehaviour
{
    public string m_BoatName;
    public string m_Destination;
    public string m_TriggerName;
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

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player")&&Input.GetKeyDown(KeyCode.F))
        {
            m_TransferController.StartTransfer(m_BoatName, m_Destination,m_TriggerName,other.gameObject.transform.parent);
        }
    }
}
