using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

//Orca INHERITS from Entity because its an entity
public class Orca : MonoBehaviour
{
    private CharacterController controller;
    private PostProcessVolume volume;
    private PostProcessingScan scan;
    private Transform camera;

    private float turnSmoothVelocity;

    [SerializeField] float speed, upSpeed, downSpeed, turnSmoothing;
    private void Start()
    {
        getComponents();
        getPpsProfiles();

        Cursor.lockState = CursorLockMode.Locked;

        camera = GetComponentInChildren<Camera>().transform;
    }

    // Orca overrides speak method
    //this method will probably never activate because the orca doesnt need to flee

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
    public void move()
    {

        float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(xAxis, 0f, yAxis).normalized;

        if (Input.GetKey(KeyCode.LeftShift)) { controller.Move(new Vector3(0, -upSpeed, 0) * Time.deltaTime); }
        else if (Input.GetKey(KeyCode.Space)) { controller.Move(new Vector3(0, downSpeed, 0) * Time.deltaTime); }

        // multiplying by time.deltatime will make sure movement is NOT frame-dependent
        if (move.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothing);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);


            Vector3 direction = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(direction.normalized * speed * Time.deltaTime);
        }

    }

    public void moveScanOrigin()
    {
        scan._Origin.value = transform.position;
    }

    public void scanToggle()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            scan.active = true;
            
        } else
        {
            scan.active = false;
        }
    }

    public float getSpeed()
    {
        return speed;
    }
}
