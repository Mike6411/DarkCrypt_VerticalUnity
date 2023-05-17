using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombiescript : MonoBehaviour
{

    private Vector3 randomPos;
    private GameObject player;

    [SerializeField]
    private float detectionRange;

    [SerializeField]
    private AudioSource detectedFX;

    private Animator anim;

    private NavMeshAgent agent;
    private bool isChasing;
    private bool isRoaming;

    private void Start()
    {
        randomPos = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        isChasing = false;
        isRoaming = true;
    }

    private void Update()
    {

        //Chase Check
        if(Vector3.Distance(transform.position, player.transform.position) <= detectionRange)
        {
            ChasePlayer();
        }
        else if (isChasing)
        {
            WalkToRandomSpot();
        }

        if(isRoaming) 
        { 
            if(Vector3.Distance(transform.position, randomPos) <= 1)
            {
                WalkToRandomSpot();
            }
        }

        if(Vector3.Distance(transform.position, player.transform.position) <= 1)
        {
            anim.SetTrigger("attack");
        }
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.transform.position);

        if(!isChasing)
        {
            detectedFX.Play();
            isChasing = true;
            isRoaming = false;
            agent.speed = 2;

            //trigger anims
            anim.SetBool("isRunning", isChasing);
            anim.SetBool("isWalking", isRoaming);
        }
    }

    private void WalkToRandomSpot()
    {
        agent.speed = 0.75f;
        randomPos = MapManager.instance.GetRandomPos();

        agent.SetDestination(randomPos);

        isChasing= false;
        isRoaming= true;

        //trigger anims
        anim.SetBool("isRunning", isChasing);
        anim.SetBool("isWalking", isRoaming);
    }
}
