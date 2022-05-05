using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{    void Start()
    {
        EventSystem.current.onOrcaPickup += enableFrame;
        EventSystem.current.onPromptEnd += disableFrame;
        gameObject.SetActive(false);
    }

    //Sets UI to be active or not
    public void enableFrame() { gameObject.SetActive(true); }
    public void disableFrame() { gameObject.SetActive(false); }
}
