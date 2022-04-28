using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Seal : Entity
{
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
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
