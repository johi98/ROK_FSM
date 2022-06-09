using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MonsterAnimations
{
    public enum MonsterAttackAnimation
    {
        Attack1,
        Attack2,
        Attack3,
        Attack4

    }


    //공격 초기 가중치
    public void InitMonsterAniDic(Dictionary<MonsterAttackAnimation, int> dic)
    {

        foreach (MonsterAttackAnimation name in Enum.GetValues(typeof(MonsterAttackAnimation)))
        {
            switch (name)
            {
                case MonsterAttackAnimation.Attack1:
                    dic.Add(name, 20);
                    break;
                case MonsterAttackAnimation.Attack2:
                    dic.Add(name, 20);
                    break;
                case MonsterAttackAnimation.Attack3:
                    dic.Add(name, 15);
                    break;
                case MonsterAttackAnimation.Attack4:
                    dic.Add(name, 15);
                    break;
                default:
                    dic.Add(name, 0);
                    break;
            }

        }
    }

}


