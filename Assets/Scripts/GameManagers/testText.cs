
using UnityEngine;

//place this script on an object with a trigger collider to display the text
public class testText : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        TextPrompt.instance.ChangeText("Testing text");
    }
}
