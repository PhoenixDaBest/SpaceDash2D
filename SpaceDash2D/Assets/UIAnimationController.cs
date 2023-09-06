using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class UIAnimationController : MonoBehaviour
{
    public GameObject playQuitPanel, title, introPanel, pressPanel;
    //public TMP_Text disclaimer1;
    public Text disclaimer, disclaimer1, disclaimer2;
    public Text pressText, toContinue;
    public Button pressToContinueButt;

    public float duration = 2;
    // Start is called before the first frame update
    void Start()
    {
        //DOTween.Init();
        entry();
        //StartCoroutine(disclaimerText());
        pressToContinueButt.enabled = false;
    }

    void entry()
    {
        playQuitPanel.transform.DOMoveY(543, duration);
        title.transform.DOMoveY(1757, duration);
    }

    public void exit()
    {
        playQuitPanel.transform.DOMoveY(-454, duration);
        title.transform.DOMoveY(2590, duration);
        pressPanel.transform.DOMoveY(-454, duration);
        introPanel.transform.DOMoveY(-454, duration);
        StartCoroutine(disclaimerPanel());
    }

    IEnumerator disclaimerPanel()
    {
        yield return new WaitForSeconds(duration + 1);

        introPanel.transform.DOMoveY(1000, duration);

        StartCoroutine(disclaimerText());
    }

    IEnumerator disclaimerText()
    {
        yield return new WaitForSeconds(1);
        disclaimer.DOText("! DISCLAIMER !", 1, false, ScrambleMode.Custom, "01101010101001");
        yield return new WaitForSeconds(1);
        disclaimer1.DOText("This Space Program is in beta", 1, false, ScrambleMode.Numerals, "34857083573890523489531313213");
        disclaimer2.DOText("Which means it's in development", 1, false, ScrambleMode.Numerals, "089345348953259489435732432143121234");
        StartCoroutine(disclaimerText2());
    }

    IEnumerator disclaimerText2()
    {
        yield return new WaitForSeconds(5);
        //disclaimer.DOText("! DISCLAIMER !", 1, false, ScrambleMode.Numerals, "8934755793457");
        yield return new WaitForSeconds(0);
        disclaimer1.DOText("This is a mini project done by Ravi", 1, true, ScrambleMode.Custom, "This Space Program is in beta");
        disclaimer2.DOText("The gameplay is unfinished and being refined", 1, true, ScrambleMode.Custom, "Which means it's in development");

        yield return new WaitForSeconds(5);
        StartCoroutine(pressToContinue());
    }

    IEnumerator pressToContinue()
    {
        pressPanel.transform.DOMoveY(88, duration);
        yield return new WaitForSeconds(1);
        pressText.DOText("Press", 1, false, ScrambleMode.Custom, "10110");
        yield return new WaitForSeconds(.5f);
        toContinue.DOText(" to continue", 1, false, ScrambleMode.Custom, "11011010");
        pressToContinueButt.enabled = true;

    }
}
