using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TranfromHelps  {

    //添加到Transform方法

    //深度优先找物体
    public static Transform DeepFind(this Transform parent,string TargetName)
    {
        //初始化 tempTrans
        Transform tempTrans = null;
        //遍历孩子找Target
        foreach (Transform child in parent)
        {
            if(child.name == TargetName)
            {
                return child;
            }
            else
            {
                //找儿子身上有没有
                tempTrans = DeepFind(child, TargetName);
                //找到了向上层返还
                if(tempTrans != null)
                {
                    return tempTrans;
                }
            }
        }

        return tempTrans;
    }


	
}
