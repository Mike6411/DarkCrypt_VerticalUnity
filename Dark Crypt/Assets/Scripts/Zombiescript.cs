using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombiescript : MonoBehaviour
{

    [SerializeField]
    private Vector3 randomPos;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private NavMeshAgent agent;

    [SerializeField]
    private float detectionRange;

    private bool isChasing;
    private bool isRoaming;
    private AudioSource detectedFX;


    private void Start()
    {
        randomPos= transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {

        //Chase Check
        if(Vector3.Distance(transform.position, player.transform.position) <= detectionRange)
        {
            //Chase player

        }else if (isChasing)
        {
            //Break chase
        }

        if(isRoaming) 
        { 
            if(Vector3.Distance(transform.position, randomPos) <= 1)
            {
                WalkToRandomSpot();
            }
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
        }
    }

    private void WalkToRandomSpot()
    {
        agent.speed = 0.75f;
    }
}
