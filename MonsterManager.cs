using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MonsterManager : MonoBehaviour
{
    public Transform playerTr;
    public Animator animator;
    public MonsterNavigation monsterNav;
    public Rigidbody monsterRigidbody;
    public float monsterRotateSpeed;
    public bool checkPlayer = false;
    public GameObject parentSpaner;

    [SerializeField]
    float rotateSpeed = 20;

    [Header("MonsterAttackCollider")]
    public BoxCollider rightHandCollider;
    public BoxCollider leftHandCollider;

    public Monster enemy;

    void Awake()
    {
        parentSpaner = gameObject.transform.parent.gameObject;
        playerTr = GameObject.Find("Player").transform;
        animator = GetComponent<Animator>();
        monsterNav = GetComponent<MonsterNavigation>();
        monsterRigidbody = GetComponent<Rigidbody>();
        enemy = GetComponent<Monster>();
        monsterRotateSpeed = 0.2f;
    }


    public float CheckDistanceOfPlayer()
    {
        float _distanceToPlayer = Vector3.Distance(gameObject.transform.position, playerTr.position);

        return _distanceToPlayer;
    }

    public void LookPlayer()
    {
        Vector3 direction = (playerTr.position - this.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, monsterRotateSpeed * Time.deltaTime);
    }





}

