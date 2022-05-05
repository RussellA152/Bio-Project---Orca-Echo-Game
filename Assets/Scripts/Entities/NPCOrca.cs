using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCOrca : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float interactDistance;

    List<GameObject> textList = new List<GameObject>();

    private float dist;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float playerDistance = Vector3.Distance(transform.position, player.transform.position);
        if (playerDistance <= interactDistance) { handleInteract(); }
    }

    private void handleInteract()
    {
        if (Input.GetKey(KeyCode.F)) {
            EventSystem.current.orcaPickup();
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        textList.Add(GameObject.FindGameObjectWithTag("Info"));
        textList.Add(GameObject.FindGameObjectWithTag("Header"));
        

        foreach (GameObject t in textList)
        {
            textHandler(t);
        }

        EventSystem.current.promptStart();
    }

    private void textHandler(GameObject t)
    {
        switch(t.tag)
        {
            case("Header"):
                setText(t);
                break;

            case ("Info"):
                setText(t);
                break;

            default:
                Debug.Log("Unknown Object");
                break;
        }
    }

    //Each NPC should have unique text to retrieve; pass it in from case
    private void setText(GameObject t)
    {
        TextPrompt script = t.GetComponent<TextPrompt>();
        script.clearPrompt();
        script.addPrompt("asdf");
        script.addPrompt("asdf1");
        script.addPrompt("asdf2");

    }
}
