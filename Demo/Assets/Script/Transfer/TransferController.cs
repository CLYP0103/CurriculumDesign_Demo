using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferController : MonoBehaviour
{
    public Dictionary<string, Transform> m_TransferPointsDict;
    public Dictionary<string, Transform> m_TransferModelDict;
    public GameObject beTransferGameobject;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        m_TransferPointsDict = new Dictionary<string, Transform>();
        m_TransferModelDict = new Dictionary<string, Transform>();
        Transform modelTransform = transform.Find("TransferModel");
        Transform pointTransform = transform.Find("TransferPoints");
        foreach(Transform child in modelTransform)
        {
            m_TransferModelDict.Add(child.name, child);
        }
        foreach (Transform child in pointTransform)
        {
            m_TransferPointsDict.Add(child.name, child);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTransfer(string boatName,string destination,string triggerName,Transform beTransferedGameobjectTrans)
    {
        Transform boat = m_TransferModelDict[boatName];
        Transform point = m_TransferPointsDict[destination];
        Animator boatAnimator = boat.GetComponent<Animator>();
        beTransferedGameobjectTrans.gameObject.SetActive(false);
        boatAnimator.SetTrigger(triggerName);
        beTransferedGameobjectTrans.parent = boat;
        beTransferedGameobjectTrans.localPosition = Vector3.zero;
        beTransferGameobject = beTransferedGameobjectTrans.gameObject;
    }

    public void EndTransfer(string destination)
    {
        Transform point = m_TransferPointsDict[destination];
        beTransferGameobject.transform.parent = point;
        beTransferGameobject.transform.localPosition = Vector3.zero;
        beTransferGameobject.transform.parent = null;
        beTransferGameobject.SetActive(true);
        print(beTransferGameobject.name);
    }
}
