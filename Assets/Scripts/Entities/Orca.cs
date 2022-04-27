using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

//Orca INHERITS from Entity because its an entity
public class Orca : Entity
{
    private CharacterController controller;
    private PostProcessVolume volume;
    private PostProcessingScan scan;

    [SerializeField] float speed, upSpeed, downSpeed;
    private void Start()
    {
        getComponents();
        getPpsProfiles();
    }

    // Orca overrides speak method

    public override void Die()
    {
        //custom particles play 

        // I think base is the same as super.something() in java

        base.Die();
    }

    //this method will probably never activate because the orca doesnt need to flee
    public override void flee()
    {

    }
    public override void calm()
    {

    }
    public override void follow()
    {

    }

    private void getPpsProfiles()
    {
        volume.profile.TryGetSettings(out scan);
    }

    private void getComponents()
    {
        controller = GetComponent<CharacterController>();
        volume = GetComponent<PostProcessVolume>();
    }

    private void Update()
    {
        move();
        moveScanOrigin();
        scanToggle();
    }
    public override void move()
    {
        Vector3 move = new Vector3(0, 0, 0);

        move += -transform.forward * Input.GetAxis("Vertical") * speed;
        move += -transform.right * Input.GetAxis("Horizontal") * speed;

        if (Input.GetKey(KeyCode.LeftShift)) { move += new Vector3(0, -upSpeed, 0); }
        if (Input.GetKey(KeyCode.Space)) { move += new Vector3(0, downSpeed, 0); }

        // multiplying by time.deltatime will make sure movement is NOT frame-dependent
        controller.Move(move * Time.deltaTime);

    }

    public void moveScanOrigin()
    {
        scan._Origin.value = transform.position;
    }

    public void scanToggle()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            scan.active = true;
        } else
        {
            scan.active = false;
        }
    }

}
