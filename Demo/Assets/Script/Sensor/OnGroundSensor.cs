using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGroundSensor : MonoBehaviour {

    public CapsuleCollider PlayerHandleCollider;
    public RoleController roleController;

    //圆心偏移量
    public float offset = 0;

    //绘制胶囊体碰撞器所需要的两个圆心坐标
    private Vector3 point1;
    private Vector3 point2;


    //胶囊体半径
    private float raduis;


    private void Awake()
    {
        //获取PlayerHandle 身上得胶囊碰撞器
        PlayerHandleCollider = transform.parent.GetComponent<CapsuleCollider>();
        //获取半径
        raduis = PlayerHandleCollider.radius;

        //获取RoleController
        roleController = transform.parent.GetComponent<RoleController>();

    }

    // Use this for initialization
    void Start () {
		
	}
	
	
	void FixedUpdate () {

        //更新两个圆心坐标
        point1 = transform.position + transform.up * (raduis-offset);
        point2 = transform.position + transform.up * PlayerHandleCollider.height - transform.up * (raduis - offset);

        //检查碰撞
        Collider[] outputColliders = Physics.OverlapCapsule(point1, point2, raduis,LayerMask.GetMask("Ground"));

        if(outputColliders.Length != 0)
        {
            roleController.SetAniamtorBool("isGround", true);
        }
        else
        {
            roleController.SetAniamtorBool("isGround", false);
        }
	}
}
