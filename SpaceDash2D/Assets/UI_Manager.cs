using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject settingsPanel;
    public bool isPause;

    public void openSettingsPanel()
    {
        settingsPanel.SetActive(true);
        isPause = true;
    }
    public void closeSettingsPanel()
    {
        settingsPanel.SetActive(false);
        isPause = false;
    }


}
