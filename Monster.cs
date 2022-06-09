using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Monster : MonoBehaviour , IDamageable
{


    public bool invincible;
    [Range(1, 9999)] public float startHealth;
    [Range(1, 9999)] public float startStamina;
    [SerializeField]
    protected float health;
    public float stamina;
    protected bool isDead = false;

    public event System.Action OnDeath;


    [SerializeField] float targetCheckRadius;
    [SerializeField] LayerMask targetLayer;
    [SerializeField] bool playerIsClose = false;
    [SerializeField]
    Animator monsterAnimator;
    MonsterManager monsterManager;


    private void Start()
    {
        health = startHealth;
        stamina = startStamina;
        monsterAnimator = GetComponent<Animator>();
        monsterManager = GetComponent<MonsterManager>();
    }
    private void FixedUpdate()
    {
        CheckTarget();
        monsterManager.checkPlayer = playerIsClose;
    }
    public virtual void TakeDamage(float damage)
    {
        if (!invincible && !isDead)
        {
            health -= damage;

            if (health <= 0)
            {

                monsterAnimator.SetTrigger("Die");
                //MonsterPooling.ReturnObj(gameObject);
                Die();
            }
        }
    }

    public void Die()
    {
        
        if (!isDead)
        {
            isDead = true;
            if (OnDeath != null)
            {

                
                monsterAnimator.SetTrigger("Die");
               
                OnDeath();
            }
        }

        //Destroy(gameObject);
    }


    void CheckTarget()
    {
        //플레이어가 가까이 있는지 체크하며 경로가 생성되었을 경우 전투를 시작함
        if (Physics.CheckSphere(transform.position, targetCheckRadius, targetLayer))
        {
            playerIsClose = true;
            if (monsterManager.monsterNav.PathIsReady(monsterManager.playerTr))
            {
              //  GameManager.GameManagerInstance.soundManager.CombatBGM();
            }

        }
        else
        {
            playerIsClose = false;
            MonsterCanNotFoundPlayer();
        }
    }
    //전투 종료
    void MonsterCanNotFoundPlayer()
    {
        //GameManager.GameManagerInstance.soundManager.IdleBGM();
        health = startHealth;
        
    }



}
