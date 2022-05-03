using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextPrompt : MonoBehaviour
{

    //global singleton instance of the TextPrompt so that it can be accessed anywhere
    // any class can retrieve it, but only this class should be allowed to set it
    public static TextPrompt instance { get; private set; }
    private TextMeshProUGUI prompt;
    private bool canChangeText;

    private void Awake()
    {
        //if there is an instance, and its not this one, delete this one
        if(instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void Update()
    {
        Debug.Log(canChangeText);
    }

    private void Start()
    {
        prompt = GetComponent<TextMeshProUGUI>();
        canChangeText = true;
        ChangeText("Echolocation allow orcas to coordinate their hunting efforts in absence of light. Edit this....");
    }

    // parameter is the text you are trying to display
    public void ChangeText(string text)
    {
        // starts a coroutine that takes in this string parameter as an argument
        StartCoroutine(ChangeTextTime(text));
            
    }
    IEnumerator CloseTextBox(string text)
    {
        // if the text box is disabled, then re enable it
        if (prompt.enabled == false)
            prompt.enabled = true;

        //set canChangeText to false so that the text box isnt interupted
        canChangeText = false;
        //change text box words to desired text
        prompt.text = text;
        // wait 3 seconds
        yield return new WaitForSeconds(3);
        // close text box
        prompt.enabled = false;
        // allow text to be changed again
        canChangeText = true;

    }


    IEnumerator ChangeTextTime(string text)
    {
        //canChangeText being false means theres already text being displayed, we dont want to interupt it, so just wait until that text has been displayed for atleast 3 seconds
        while (canChangeText == false)
            yield return null;

        // now that canChangeText is true start the coroutine that will display the text and then close the box
        StartCoroutine(CloseTextBox(text));
        
    }


}
