using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : Entity
{
    private void Start()
    {
        Speak();
    }

    // Fish overrides speak method
    public override void Speak()
    {
        Debug.Log("Fish Sounds!");
        //throw new System.NotImplementedException();
    }

    public override void Die()
    {
        //custom particles play 

        base.Die();
    }
}
