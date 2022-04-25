using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// An entity will be the main orca, or other orcas or enemies

// Entity is an abstract class so it cannot be placed on an enemy
public abstract class Entity : MonoBehaviour
{
    public int speed;
    public int health;

    //Speak is an abstract method so it wont have a body and it must be overriden
    public abstract void Speak();

    // a virtual method is sort of like an abstract but it can have a body of code in here and it can still be overriden.... but it doesnt HAVE to be overriden like an abstract method
    public virtual void Die()
    {
        Destroy(this.gameObject);
    }
}

