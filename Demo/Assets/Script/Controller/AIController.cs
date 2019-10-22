using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class AIController : MonoBehaviour {
    public Animator animator;
    void Awake() {
        //animator = transform.Find("Model").GetChild(0).GetComponent<Animator>();
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start() {
    }
    // Update is called once per frame
    private float dis = 0;
    void Update() {
        Vector3 enemyPos = transform.position;
        Vector3 playerPos = GameObject.Find("PlayerHandle").transform.position;
        dis = Vector3.Distance(enemyPos, playerPos);
        //Debug.Log(dis);
        if (dis >= 1.6 && BehaviorTreesManager.attack) {
            BehaviorTreesManager.Instance.Patrol();
            //Debug.Log("超出距离");
            BehaviorTreesManager.attack = false;

        }
    }
    // 受击
    void OnCollisionEnter(Collision collision) { 
        if (collision.gameObject.tag == "Weapon") {
            animator.SetTrigger("hit");
            BehaviorTreesManager.Instance.Hit();
            Debug.Log("Patrol禁用");
            
            
             //hit状态下超出范围
            
            //transform.LookAt(GameObject.Find("PlayerHandle").transform.position);
        }
    }

    // 碰撞结束
    void OnCollisionExit(Collision collision) {

    }

    // 碰撞持续中
    void OnCollisionStay(Collision collision) {

    }
}
