using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : Entity
{
    private void Start()
    {
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
}
