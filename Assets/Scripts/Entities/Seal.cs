using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seal : Entity
{
    private void Start()
    {
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
}
