using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Seal : Entity
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

    // Orca overrides speak method
    public override void move()
    {

    }

    public override void Die()
    {
        //custom particles play 


        base.Die();
    }

    public override void changeSpeed(float speed)
    {
        agent.speed = speed;
    }
}
