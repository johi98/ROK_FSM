using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MonsterIdleBehavior : StateMachineBehaviour
{

    Dictionary<MonsterAnimations.MonsterAttackAnimation, int> attackDic = new Dictionary<MonsterAnimations.MonsterAttackAnimation, int>();
 
    MonsterAnimations trollAni = new MonsterAnimations();

    [SerializeField]
    MonsterManager monsterManager;
    MonsterAnimations.MonsterAttackAnimation monsterAttackAni;

    public float walkDistance;
    bool animationChoosen = true;
    bool waitEvent;
    IEnumerator waitTimeCor;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(monsterManager == null)
        {
            monsterManager = animator.gameObject.GetComponent<MonsterManager>();
        }
     

        if(attackDic.Count == 0)
        {
            trollAni.InitMonsterAniDic(attackDic);
                
        }

    
        monsterManager.monsterNav.NavOn();
        
        if(monsterManager.checkPlayer == false)
        {
            monsterManager.monsterNav.NavOff();
        }
        monsterManager.monsterNav.NavStop();



        waitEvent = false;
        waitTimeCor = WaitTime();
        monsterManager.StartCoroutine(waitTimeCor);

        animationChoosen = false;
        monsterManager.CheckDistanceOfPlayer();
    }


    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (monsterManager.checkPlayer)
        {
            monsterManager.monsterNav.NavOn();
        }

        if (waitEvent == true && monsterManager.checkPlayer)
        {
            if(monsterManager != null)
            {

                if (monsterManager.CheckDistanceOfPlayer() > walkDistance)
                {
                    if(monsterManager.monsterNav.PathIsReady(monsterManager.playerTr))
                    {
                        animator.SetBool("Walk", true);
                        animationChoosen = true;
                    }
          
                }
                //걷기보다 짧을 경우 공격애니메이션 실행
                else if (monsterManager.CheckDistanceOfPlayer() <= walkDistance && animationChoosen == false )
                {
                    monsterAttackAni = WeightedRandomizer.From(attackDic).TakeOne();
                    animator.SetTrigger(monsterAttackAni.ToString());
                    animationChoosen = true;
                }

            }
        }
      

    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(0.3f);
        waitEvent = true;
    }

}


