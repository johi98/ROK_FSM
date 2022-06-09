using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttackBehavior : StateMachineBehaviour
{
    [SerializeField]
    MonsterManager monsterManager;
    [SerializeField]
    float walkStopDistance = 1.6f;

    AudioSource monsterSource;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (monsterManager == null)
        {
            monsterManager = animator.gameObject.GetComponent<MonsterManager>();
        }
        if (monsterSource == null)
        {
            monsterSource = animator.gameObject.GetComponent<AudioSource>();
        }

        monsterManager.monsterNav.NavOff();
        monsterManager.monsterRigidbody.angularVelocity = Vector3.zero;



        GameManager.GameManagerInstance.soundManager.MonsterAttackSound2(monsterSource);
    }


    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        monsterManager.LookPlayer();


    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        monsterManager.monsterNav.NavOn();
        monsterManager.monsterRigidbody.angularVelocity = Vector3.zero;
    }
}
