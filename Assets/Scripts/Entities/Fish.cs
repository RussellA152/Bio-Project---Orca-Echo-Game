using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Fish : Entity
{
    [SerializeField] private float speed;
    private float original_speed;
    private float flee_speed;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        original_speed = speed;
        flee_speed = speed * 3;
    }

    // Fish overrides speak method
    public override void move()
    {

    }

    public override void Die()
    {
        //custom particles play 

        base.Die();
    }

    public override void flee()
    {
        agent.speed = flee_speed;
    }
    public override void calm()
    {
        agent.speed = original_speed;
    }

    public override void follow()
    {

    }
}
