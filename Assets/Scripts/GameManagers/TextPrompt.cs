using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextPrompt : MonoBehaviour
{

    //global singleton instance of the TextPrompt so that it can be accessed anywhere
    // any class can retrieve it, but only this class should be allowed to set it
    private TextMeshProUGUI prompt;
    private bool canChangeText;
    private Queue prompts = new Queue();

    private void Update()
    {
        //press e to display next prompt
        if (Input.GetKeyDown(KeyCode.E)) { canChangeText = true; }
        else { canChangeText = false; }
    }

    private void Start()
    {
        prompt = GetComponent<TextMeshProUGUI>();
        EventSystem.current.onPromptStart += startPrompts;
    }

    public void clearPrompt()
    {
        prompts.Clear();
        prompt.text = "";
    }

    //function call to queue in prompts
    public void addPrompt(string text)
    {
        prompts.Enqueue(text);
    }

    //function call to begin displaying prompts; call after all prompts are queued
    public void startPrompts()
    {
        StartCoroutine(DisplayTextBox(prompts));
    }
    IEnumerator DisplayTextBox(Queue prompts)
    {
        prompt.enabled = true;
        

        while (prompts.Count != 0)
        {
            canChangeText = false;
            prompt.text = prompts.Dequeue().ToString();
            yield return new WaitUntil(canClosePrompt);
        }

        prompt.enabled = false;

        EventSystem.current.promptEnd();

    }

    public bool canClosePrompt()
    {
        return canChangeText;
    }


}
