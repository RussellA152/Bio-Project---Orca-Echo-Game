using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seal : Entity
{
    private void Start()
    {
        Speak();
    }

    // Orca overrides speak method
    public override void Speak()
    {
        Debug.Log("Seal Sounds!");
        //throw new System.NotImplementedException();
    }

    public override void Die()
    {
        //custom particles play 


        base.Die();
    }
}
