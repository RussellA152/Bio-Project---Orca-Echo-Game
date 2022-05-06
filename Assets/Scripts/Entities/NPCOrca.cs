using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCOrca : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float interactDistance;
    [SerializeField] TextAsset headers, body;
    [SerializeField] Sprite img;
    [SerializeField] byte red, green, blue, alpha;

    private Image image, colorstrip;
    private Color color;

    List<GameObject> textList = new List<GameObject>();

    void Start()
    {
        color = new Color32(red, green, blue, alpha);
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

        image = GameObject.FindGameObjectWithTag("Image").GetComponent<Image>();
        colorstrip = GameObject.FindGameObjectWithTag("Color").GetComponent<Image>();

        colorstrip.color = color;
        image.sprite = img;
        

        foreach (GameObject t in textList)
        {
            //set text for each text field
            handleTextChange(t);
        }

        //start all prompts when text has been set
        EventSystem.current.promptStart();
    }

    private void setText(GameObject t, TextAsset text)
    {
        //can check tag to add unique prompts
        //ex. if tag == "header" { add header text here }
        //num of headers added == num of info added
        TextPrompt script = t.GetComponent<TextPrompt>();
        string[] textList = text.ToString().Split('+');
        foreach (string s in textList)
        {
            script.addPrompt(s);
        }
    }

    private void handleTextChange(GameObject t)
    {
        switch (t.tag)
        {
            case ("Header"):
                setText(t, headers);
                break;
            case ("Info"):
                setText(t, body);
                break;
            default:
                break;
        }
    }
}
