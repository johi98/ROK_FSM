using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PJH
{
    public class MonsterWalkBehavior : StateMachineBehaviour
    {
        [SerializeField]
        MonsterManager monsterManager;
        [SerializeField]
        float walkStopDistance = 1.6f;


        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (monsterManager == null)
            {
                monsterManager = animator.gameObject.GetComponent<MonsterManager>();
            }

            monsterManager.monsterNav.NavMove();
        }


        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (monsterManager != null && monsterManager.monsterNav.PathIsReady(monsterManager.playerTr))
            {
                monsterManager.monsterNav.MoveToPlayer(monsterManager.playerTr);
            }
            else
            {
                animator.SetBool("Walk", false);
            }

            if (monsterManager.CheckDistanceOfPlayer() < walkStopDistance || monsterManager.checkPlayer == false || !monsterManager.monsterNav.PathIsReady(monsterManager.playerTr))
            {
                animator.SetBool("Walk", false);
            }


        }

        public override void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

        }


    }
}
