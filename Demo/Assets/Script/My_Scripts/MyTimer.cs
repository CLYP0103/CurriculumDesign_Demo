using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTimer  {

    public enum STATE
    {
        IDLE,
        RUN,
        FINISHED
    }

    public STATE state;

    public float duration = 1f;

    public float elapsedTime = 0f;

    public MyTimer()
    {

    }

    public MyTimer(float time)
    {
        duration = time;
    }

    public void Tick()
    {
        switch (state)
        {
            case STATE.IDLE:break;
            case STATE.RUN: elapsedTime += Time.deltaTime;
                    if (elapsedTime >= duration)
                    {
                       state = STATE.FINISHED;
                    }
                    break;
            case STATE.FINISHED:break;
            default:Debug.Log("MyTimer.Tick() error!!!");break;
        }
    }


    //开始计时 
    public void Go()
    {
        elapsedTime = 0f;
        state = STATE.RUN;
    }
}
