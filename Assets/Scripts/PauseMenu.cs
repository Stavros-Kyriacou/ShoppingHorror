using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject controlsMenu;
    public GameObject settingsMenu;

    public void ToggleControls()
    {
        if (controlsMenu.activeInHierarchy)
        {
            controlsMenu.SetActive(false);
        }
        else
        {
            controlsMenu.SetActive(true);
        }
    }


}
