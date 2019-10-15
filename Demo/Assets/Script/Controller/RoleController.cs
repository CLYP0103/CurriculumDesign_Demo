using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleController : MonoBehaviour
{

    //玩家输入
    PlayerInput pi;
    //
    RoleManager roleManager;

    [Header("===== 角色属性设置（移动速度，跑跳） =====")]
    public float jumpVelocity = 3.0f;
    public float rollVelocity = 3.0f;
    public float walkSpeed = 3.0f;
    public Vector3 roleMoveVelocity;
    public Vector3 thrustVelocity;
    private bool weapon = true;

    [Header("===== Other =====")]
    //角色 对象
    public GameObject role;
    //角色 刚体
    public Rigidbody roleRigidbody;
    //角色 动画控制器
    public Animator roleAnimator;

    public GameObject playerHandle;

    //控制变量
    public bool canAttack;
    //public bool canSkill;
    public bool canJump;
    public bool canRoll;
    public bool tryOpenKnapsack;
    private bool isGround;


    private void Awake()
    {

        playerHandle = transform.gameObject;
        //获取role
        role = transform.Find("Model").gameObject;
        //获取PlayerInput
        pi = GetComponent<PlayerInput>();

        //获取刚体
        roleRigidbody = transform.GetComponent<Rigidbody>();

        //获取Animator
        roleAnimator = transform.GetComponentInChildren<Animator>();
        //初始化
        canAttack = canJump = canRoll = true;

        roleManager = GetComponent<RoleManager>();
    }


    // Use this for initialization
    void Start()
    {

    }




    // Update is called once per frame
    void Update()
    {


        //调控动画机的forward变量
        roleAnimator.SetFloat("forward", pi.directionMag);


        //朝向的改变
        if (pi.directionMag > 0.1f)
        {
            role.transform.forward = Vector3.Slerp(role.transform.forward, pi.moveVector, 0.3f);
        }
        //需要增加移动速度和跑的速度
        roleMoveVelocity = pi.directionMag * role.transform.forward * walkSpeed;

        //检查落地
        isGround = roleAnimator.GetBool("isGround");


        //跳的动画播放
        if (pi.jump && isGround)
        {
            //触发跳的动画
            roleAnimator.SetTrigger("jump");
            //给竖直方向一个冲量
            AddThrustVelocity(jumpVelocity, 1);

        }

        //print("IsGround" + roleAnimator.GetBool("isGround"));

        //攻击的动画
        if (isGround && pi.attack)//)
        {
            roleAnimator.SetTrigger("attack");
        }

        if (canRoll && pi.roll)
        {
            roleAnimator.SetTrigger("roll");
            //thrustVelocity = new Vector3(0, 0, rollVelocity);
        }


        //如果玩家按下背包键
        tryOpenKnapsack = pi.knapsack;

        if(Input.GetKeyDown(KeyCode.P))
        {
            weapon = !weapon;
            roleManager.ChangeWeapon(weapon ? 0 : 1);
        }

    }

    void FixedUpdate()
    {


        roleRigidbody.velocity = new Vector3(roleMoveVelocity.x, roleRigidbody.velocity.y, roleMoveVelocity.z) + thrustVelocity;

        //冲量置零
        thrustVelocity = Vector3.zero;

    }


    //增加一个冲量速度 参数一：速度大小 参数二：方向 （0：代表 x轴; 1：代表 y轴; 2：代表 z轴）
    public void AddThrustVelocity(float tempthrustVelocity, int direction)
    {
        switch (direction)
        {
            case 0: thrustVelocity = new Vector3(tempthrustVelocity, 0, 0); break;
            case 1: thrustVelocity = new Vector3(0, tempthrustVelocity, 0); break;
            case 2: thrustVelocity = new Vector3(0, 0, tempthrustVelocity); break;
        }
    }



    /// <summary>
    /// 给外部类 修改Animator中 bool参数
    /// </summary>
    /// <param name="name"></param>
    /// <param name="flag"></param>

    public void SetAniamtorBool(string name, bool flag)
    {
        roleAnimator.SetBool(name, flag);
    }

    public void SetAnimatorTrigger(string name)
    {
        roleAnimator.SetTrigger(name);
    }

    public void SetAnimatorFloat(string name,float value)
    {
        roleAnimator.SetFloat(name, value);
    }

    public void SetPlayerInputEnable(bool flag)
    {
        pi.inputEnable = flag;
    }

    public void SetWeaponActive(bool flag)
    {
        roleManager.SetWeaponActive(flag);
    }

    public void SetEffectActive(bool flag)
    {
        roleManager.SetEffectActive(flag);
    }

    public void SetShootEffect(string effectName)
    {
        roleManager.SetShootEffect(effectName, role.transform.forward);
    }
}


