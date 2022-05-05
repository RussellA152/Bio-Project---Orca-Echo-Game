using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCOrca : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float interactDistance;

    List<GameObject> textList = new List<GameObject>();

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        //check condition for allow interactions within certain distance
        float playerDistance = Vector3.Distance(transform.position, player.transform.position);
        if (playerDistance <= interactDistance) { handleInteract(); }
    }

    private void handleInteract()
    {
        if (Input.GetKey(KeyCode.F)) {
            //Displays UI
            EventSystem.current.orcaPickup();
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        //gets header and body text fields
        textList.Add(GameObject.FindGameObjectWithTag("Info"));
        textList.Add(GameObject.FindGameObjectWithTag("Header"));
        

        foreach (GameObject t in textList)
        {
            //set text for each text field
            setText(t);
        }

        //start all prompts when text has been set
        EventSystem.current.promptStart();
    }

    private void setText(GameObject t)
    {
        //can check tag to add unique prompts
        //ex. if tag == "header" { add header text here }
        //num of headers added == num of info added
        TextPrompt script = t.GetComponent<TextPrompt>();
        script.addPrompt("asdf");
        script.addPrompt("asdf1");
        script.addPrompt("asdf2");

    }
}
