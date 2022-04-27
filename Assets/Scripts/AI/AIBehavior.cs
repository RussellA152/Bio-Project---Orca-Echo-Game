using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIBehavior : MonoBehaviour
{
    [SerializeField] private Entity entityComponent;
    private NavMeshAgent agent;
    [SerializeField] private Transform destination; //where the AI will move towards
    [SerializeField] private Transform player;  //the player orca
    private float distance_from_player;  //distance between this AI and the player orca

    [SerializeField] private bool isOrca; //only true if on a orca gameobject

    [SerializeField] private float fleeDistance;

    private enum State
    {
        Calm, //calm state is the default, slow moving AI
        Flee, //flee state is a faster moving AI 
        Follow //follow state is for the lost orcas to follow the player
    }

    private State state;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        state = State.Calm;
    }

    private void Update()
    {
        distance_from_player = Vector3.Distance(this.transform.position, player.position);

        // if player is far from AI, then they won't flee
        if (distance_from_player > fleeDistance)
        {
            state = State.Calm;
            Debug.Log("Calm");
        }

        //if player is far close to AI, and they are not an orca, then flee
        else if(distance_from_player <= fleeDistance && !isOrca)
        {
            state = State.Flee;
            Debug.Log("Flee");
        }

        switch (state)
        {
            default:
            //default state, small fish and seals will just go to their destintation
            case State.Calm:
                entityComponent.calm();
                reachDestintation();
                break;

            // small fish and seals will use when they are near the player
            case State.Flee:
                entityComponent.flee();
                break;

            //lost orcas will use this function
            case State.Follow:
                entityComponent.follow();
                break;
        }
    }

    private void reachDestintation()
    {
        agent.SetDestination(new Vector3(destination.position.x,destination.position.y,destination.position.z));
    }

    //this function will be called from AI Orcas
    public void followOrca()
    {
        state = State.Follow;
    }

}
