using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Orca INHERITS from Entity because its an entity
public class Orca : Entity
{
    private void Start()
    {
        Speak();
    }

    // Orca overrides the attack method
    public override void Speak()
    {
        Debug.Log("Orca Sounds!");
        //throw new System.NotImplementedException();
    }

    public override void Die()
    {
        //custom particles play 

        // I think base is the same as super.something() in java
        base.Die();
    }

}
