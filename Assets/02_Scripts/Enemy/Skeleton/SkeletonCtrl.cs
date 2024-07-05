using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions.Must;

public class SkeletonCtrl : MonoBehaviour
{
    public Transform tr;
    public Transform playerTr;
    public NavMeshAgent agent;
    public Animator ani;
    public float traceDist = 20.0f;
    public float attackDist = 3.0f;
    public bool isDie = false;
    public float speed = 3.0f;

    void Start()
    {
        tr = GetComponent<Transform>();
        playerTr = GameObject.FindWithTag("Player").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        if (isDie)
            return;
        SkeletonMove();
    }
    private void SkeletonMove()
    {
        float disPos = Vector3.Distance(tr.position, playerTr.position);
        agent.speed = speed;
        if (!isDie && !PlayerDamage.isPlayerDie)
        {
                if (disPos <= attackDist)
            {
                agent.isStopped = true;
                ani.SetBool("IsAttack", true);

                Vector3 playerPos = (playerTr.position - tr.position).normalized;
                Quaternion rot = Quaternion.LookRotation(playerPos);
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 4.0f);
            }
            else if (disPos <= traceDist)
            {
                agent.destination = playerTr.position;
                agent.isStopped = false;
                ani.SetBool("IsAttack", false);
                ani.SetBool("IsTrace", true);
            }
            else
            {
                agent.isStopped = true;
                ani.SetBool("IsAttack", false);
                ani.SetBool("IsTrace", false);
            }
        }
        
    }
    public void PlayerDie()
    {
        agent.isStopped = true;
        ani.SetTrigger("PlayerDie");
    }
}
