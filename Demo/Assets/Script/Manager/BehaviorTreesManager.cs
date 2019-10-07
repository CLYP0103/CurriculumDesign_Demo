using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using BehaviorDesigner.Runtime;

public class BehaviorTreesManager : MonoBehaviour
{
    private static BehaviorTreesManager _instance;
    public static bool state = false;
    public static bool attack = false;
    public static BehaviorTreesManager Instance {
        get { return _instance; }
    }
    private List<BehaviorTree> patrolBehaviorTrees = new List<BehaviorTree>();
    private List<BehaviorTree> hitBehaviorTrees = new List<BehaviorTree>();
    // Start is called before the first frame update
    void Awake() {
        _instance = this;
    }
    void Start()
    {
        BehaviorTree[] bts = FindObjectsOfType<BehaviorTree>();//得到场景中所有行为树
        foreach (var bt in bts) {
            if (bt.Group == 1) {
                patrolBehaviorTrees.Add(bt);
            }
            else {
                hitBehaviorTrees.Add(bt);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //受击后,将Patrol行为树禁用掉
    public void Hit() { 
        foreach (var bt in patrolBehaviorTrees) {
            if (BehaviorManager.instance.IsBehaviorEnabled(bt)) { //判断行为树是否启用
                bt.DisableBehavior(); //禁用自身
            }
        }
        foreach (var bt in hitBehaviorTrees) {
            if (BehaviorManager.instance.IsBehaviorEnabled(bt) == false) { //判断行为树是否启用
                bt.EnableBehavior(); //启用
            }
        }
        state = false;//false代表禁用Patrol
    }
    //超出一定巡逻范围和可视范围,将Hit行为树禁用掉
    public void Patrol() { 
        foreach (var bt in hitBehaviorTrees) {
            if (BehaviorManager.instance.IsBehaviorEnabled(bt)) { //判断行为树是否启用
                bt.DisableBehavior(); //禁用自身
            }
        }
        foreach (var bt in patrolBehaviorTrees) {
            if (BehaviorManager.instance.IsBehaviorEnabled(bt) == false) { //判断行为树是否启用
                bt.EnableBehavior(); //启用
            }
        }
        state = true;//true代表禁用Hit
    }
}
