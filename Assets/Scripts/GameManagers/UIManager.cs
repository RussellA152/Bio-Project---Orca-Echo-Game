using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventSystem.current.onOrcaPickup += enableFrame;
        EventSystem.current.onPromptEnd += disableFrame;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void enableFrame() { gameObject.SetActive(true); }
    public void disableFrame() { gameObject.SetActive(false); }
}
