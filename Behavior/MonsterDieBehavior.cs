using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDieBehavior : StateMachineBehaviour
{
    [SerializeField]
    MonsterManager monsterManager;
    MonsterPooling monsterPool;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (monsterManager == null)
        {
            monsterManager = animator.gameObject.GetComponent<MonsterManager>();
        }

        monsterPool = monsterManager.parentSpaner.GetComponent<MonsterPooling>();

    }

    

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        monsterPool.ReturnObj(animator.gameObject);
    }

}
