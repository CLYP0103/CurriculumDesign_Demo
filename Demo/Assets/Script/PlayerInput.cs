using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    //控制玩家输入是否有效
    public bool inputEnable ;

    [Header("===== 移动量 =====")]
    //玩家上下左右意图 
    public int directionUp;
    public int directionRight;
    public float directionMag;  // 两个方向和大小的集合

    //玩家移动量
    public float realDirectionUp;
    public float realDirectionRight;

    //角色移动向量
    public Vector3 moveVector;
    
    [Header("===== 按键名字 =====")]
    //移动键名称
    public string keyUp = "w";
    public string keyDown = "s";
    public string keyLeft = "a";
    public string keyRight = "d";

    //其他按键名称
    public string keyA = "j";
    public string keyB = "k";
    public string keyC = "space";
    public string keyD = "u";
    public string keyE = "i";
    public string keyF = "o";
    public string keyG = "l";

    //自己定义的按键类
    private MyButton ButtonA = new MyButton();
    private MyButton ButtonB = new MyButton();
    private MyButton ButtonC = new MyButton();
    private MyButton ButtonD = new MyButton();
    private MyButton ButtonE = new MyButton();
    private MyButton ButtonF = new MyButton();
    private MyButton ButtonG = new MyButton();


    [Header("===== 动作变量 =====")]
    //动作变量
    public bool jump;
    public bool attack;
    public bool roll;

    [Header("===== 其他变量 =====")]
    public bool knapsack;


    // Use this for initialization
    void Start () {

        inputEnable = true;

    }
	
	// Update is called once per frame
	void Update () {

        //Tick MyButton
        ButtonA.Tick(Input.GetKey(keyA));
        ButtonB.Tick(Input.GetKey(keyB));
        ButtonC.Tick(Input.GetKey(keyC));
        ButtonD.Tick(Input.GetKey(keyD));
        ButtonE.Tick(Input.GetKey(keyE));
        ButtonF.Tick(Input.GetKey(keyF));
        ButtonG.Tick(Input.GetKey(keyG));

        //玩家移动键意图
        directionUp = inputEnable ? ((Input.GetKey(keyUp) ? 1 : 0) - (Input.GetKey(keyDown) ? 1 : 0)) : 0;
        directionRight = inputEnable ? ((Input.GetKey(keyRight) ? 1 : 0) - (Input.GetKey(keyLeft) ? 1 : 0)) : 0;

        //更新realDirectionUp;  realDirectionRight;
        // InputEnable 可能略微移动存在Bug
        SquareToCircle(inputEnable ? Input.GetAxis("Horizontal") : Mathf.Lerp(Input.GetAxis("Horizontal"),0,0.95f),
                       inputEnable ? Input.GetAxis("Vertical") : Mathf.Lerp(Input.GetAxis("Vertical"), 0,0.95f));

        ////moveVector = new Vector2(realDirectionRight * cameraForward.x, realDirectionUp*cameraForward.z);
        moveVector = transform.right * realDirectionRight + transform.forward * realDirectionUp;
        directionMag = moveVector.magnitude;

        jump = inputEnable ? ButtonC.onPressed : false;

        //攻击
        attack = inputEnable ? ButtonA.onPressed : false;


        //翻滚
        roll = inputEnable ? ButtonE.onPressed : false;

        //背包
        knapsack =  ButtonG.onPressed ;
    }


    void SquareToCircle(float x , float y)
    {
        //球坐标x
        realDirectionRight = x * Mathf.Sqrt(1 - Mathf.Pow(y, 2) / 2);

        //球坐标y
        realDirectionUp = y * Mathf.Sqrt(1 - Mathf.Pow(x, 2) / 2);
    }

}
