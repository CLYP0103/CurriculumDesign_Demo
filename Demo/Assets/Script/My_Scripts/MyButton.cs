using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyButton  {

    //计时时间
    public float extendingDuration = 0.15f;
    public float delayingDuration = 0.15f;
    public float holdPercentDuration = 3f;

    //按下
    public bool isPressing = false;
    //按压
    public bool onPressed = false;
    //释放
    public bool onReleased = false;
    //持续
    public bool isExtending = false;
    //延迟
    public bool isDelaying = false;

    //按键时长百分比 （默认最长为3秒 返回 1）
    public float holdPercent = 0f;


    //现状
    private bool curState;
    //上一个状态
    private bool lastState;

    //Timer计时
    private  MyTimer extTimer = new MyTimer();
    private MyTimer delayTimer = new MyTimer();
    private MyTimer holdPerTimer = new MyTimer();

    public void Tick(bool input)
    {

        extTimer.Tick();
        delayTimer.Tick();
        holdPerTimer.Tick();

        curState = input;

        isPressing = curState;

        //初始化
        onPressed = false;
        onReleased = false;
        isDelaying = false;
        isExtending = false;
        holdPercent = 0f;

    

        if (lastState != curState)
        {
            if (curState)
            {
                //按下
                onPressed = true;
                StartTimer(delayTimer, delayingDuration);
                StartTimer(holdPerTimer,holdPercentDuration);
            }
            else
            {
                //释放
                onReleased = true;
                StartTimer(extTimer, extendingDuration);
                PauseTimer(holdPerTimer);
            }
        }

        //更新lastState
        lastState = curState;

        //判断isExtending
        if(extTimer.state == MyTimer.STATE.RUN)
        {
            isExtending = true;
        }

        //判断isDelaying
        if(delayTimer.state == MyTimer.STATE.RUN)
        {
            isDelaying = true;
        }

        //计算按键时长百分比
        if (holdPerTimer.state == MyTimer.STATE.FINISHED)
        {
           holdPercent = holdPerTimer.elapsedTime / holdPerTimer.duration;
            //重置
           holdPerTimer.elapsedTime = 0;
        }
    }

    //开始计时
    private void StartTimer(MyTimer timer,float duration)
    {
        timer.duration = duration;
        timer.Go();
    }


    //暂停计时
    private void PauseTimer(MyTimer timer)
    {
        timer.state = MyTimer.STATE.FINISHED;
    }

}
