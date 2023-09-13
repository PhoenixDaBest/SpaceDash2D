using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class mainmenu : MonoBehaviour
{
    public GameObject playQuitPanel, title, introPanel, pressPanel;
    public bool mainmenuChecker, IntroChecker, controlsChecker, loadingChecker, pressToContinueAni = true;

    public float duration = 2;
    // Start is called before the first frame update
    void Start()
    {
        //DOTween.Init();
        startingPage();
        //StartCoroutine(disclaimerText());
        //pressToContinueButt.enabled = false;
    }

    void startingPage()
    {
        playQuitPanel.transform.DOMoveY(400, duration);
        title.transform.DOMoveY(1560, duration);

        mainmenuChecker = true;
    }

    public void exit()
    {
        //up
        title.transform.DOMoveY(2590, duration);

        //down
        playQuitPanel.transform.DOMoveY(-454, duration);

    }
}
