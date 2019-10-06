using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
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
    void Update() {

    }
    void OnCollisionEnter(Collision collision) { // 销毁当前游戏物体
        if ((collision.gameObject.tag == "Weapon")) {
            animator.SetTrigger("hit");
            Debug.Log("asd");
        }
        print(collision.gameObject.name);
    }

    // 碰撞结束
    void OnCollisionExit(Collision collision) {

    }

    // 碰撞持续中
    void OnCollisionStay(Collision collision) {

    }
}
