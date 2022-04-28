using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIBehavior : MonoBehaviour
{
    [SerializeField] private Entity entityComponent;
    [SerializeField] private Transform destination, player; //where the AI will move towards
    [SerializeField] private bool isOrca; //only true if on a orca gameobject
    [SerializeField] private float fleeDistance, calmSpeed, fleeSpeed, followSpeed;

    private float distance_from_player;  //distance between this AI and the player orca

    private NavMeshAgent agent;

    public enum State
    {
        Calm, //calm state is the default, slow moving AI
        Flee, //flee state is a faster moving AI 
        Follow //follow state is for the lost orcas to follow the player
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        followSpeed = FindObjectOfType<Orca>().getSpeed();
    }

    private void Update()
    {
        distance_from_player = Vector3.Distance(this.transform.position, player.position);

        if (isOrca) { setOrcaState(); }
        else { setNonOrcaState(); }

    }

    public void setOrcaState()
    {
        if (distance_from_player > fleeDistance) { changeState(State.Calm); }
        else { changeState(State.Follow); }
    }
    public void setNonOrcaState()
    {
        // if player is far from AI, then they won't flee
        if (distance_from_player > fleeDistance) { changeState(State.Flee); }
        //if player is far close to AI, and they are not an orca, then flee
        else { changeState(State.Flee); }
    }

    public void changeState(State state)
    {
        switch (state)
        {
            default:
            //default state, small fish and seals will just go to their destintation
            case State.Calm:
                entityComponent.changeSpeed(calmSpeed);
                reachDestination();
                break;

            // small fish and seals will use when they are near the player
            case State.Flee:
                entityComponent.changeSpeed(fleeSpeed);
                reachDestination();
                break;

            //lost orcas will use this function
            case State.Follow:
                entityComponent.changeSpeed(followSpeed);
                followPlayer();
                break;
        }
    }

    private void reachDestination()
    {
        agent.SetDestination(new Vector3(destination.transform.position.x, destination.transform.position.y, destination.transform.position.z));
    }

    private void followPlayer()
    {
        agent.SetDestination(new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z));
    }
}