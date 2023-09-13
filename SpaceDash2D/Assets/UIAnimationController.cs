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
    public GameObject loading;
    public GameObject blackBG;
    public GameObject controllerText, oneHandedButton, twoHandedButton;
    public Button pressToContinueButt;

    public bool mainmenuChecker, IntroChecker, controlsChecker, loadingChecker, pressToContinueAni = true;

    public float duration = 2;

    [Header("canvas")]
    public GameObject obj;
    public GameObject objy;
    public GameObject objx;
    public float canvasHeight;
    public float canvasWidth;
    public float middleHeight;
    public float bottomHeight;
    public float topTitleHeight;


    // Start is called before the first frame update
    void Start()
    {
        RectTransform objectRectTransform = blackBG.gameObject.GetComponent<RectTransform>();
        //Debug.Log("width: " + objectRectTransform.rect.width + ", height: " + objectRectTransform.rect.height);
        setHeightWidthValues(objectRectTransform);

        exit();
        //DOTween.Init();
        StartCoroutine(waiting(1));
        


        //StartCoroutine(disclaimerText());
        pressToContinueButt.enabled = false;
    }

    void setHeightWidthValues(RectTransform objectRectTransform)
    {
        canvasHeight = Vector3.Distance(obj.transform.position, objy.transform.position);
        canvasWidth = Vector3.Distance(obj.transform.position, objx.transform.position);

        middleHeight = canvasHeight / 2;

        topTitleHeight = canvasHeight - 200;
        bottomHeight = obj.transform.position.y + 200;
        
        Debug.Log(Vector3.Distance(obj.transform.position, objx.transform.position));

    }

    IEnumerator waiting(float x)
    {
        yield return new WaitForSeconds(x);
        blackBG.SetActive(false);
        startingPage();
    }

    void startingPage()
    {
        playQuitPanel.transform.DOMoveY(bottomHeight + 200, duration);
        title.transform.DOMoveY(topTitleHeight - 100, duration);

        mainmenuChecker = true;
    }

    IEnumerator disclaimerPanel()
    {
        yield return new WaitForSeconds(duration + 1);

        introPanel.transform.DOMoveY(middleHeight, duration);

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
        disclaimer1.DOText("Never gonna give you up", 1, true, ScrambleMode.Custom, "This Space Program is in beta");
        disclaimer2.DOText("never gonna let you down", 1, true, ScrambleMode.Custom, "Which means it's in development");
        IntroChecker= true;
        yield return new WaitForSeconds(5);
        IntroChecker = true;
        StartCoroutine(pressToContinue());
    }

    IEnumerator controllerPanels()
    {
        yield return new WaitForSeconds(1);

        controllerText.transform.DOMoveY(topTitleHeight, duration);

        yield return new WaitForSeconds(1);

        controllerText.GetComponent<Text>().DOText("CONTROLS", 1, true, ScrambleMode.Custom, "1101110101");

        yield return new WaitForSeconds(1);

        oneHandedButton.transform.DOMoveX((canvasWidth/4)*3 + 70, duration);
        
        twoHandedButton.transform.DOMoveX((canvasWidth / 4) + 20, duration);
        
        controlsChecker = true;
    }

    IEnumerator loadingPanels()
    {
        yield return new WaitForSeconds(1);

        loading.transform.DOMoveY(middleHeight, duration);

        yield return new WaitForSeconds(1);

        StartCoroutine(nextScene());
        while (true)
        {
            loading.GetComponent<Text>().DOText("LOADING", 1, true, ScrambleMode.Custom, "11011101");

            yield return new WaitForSeconds(3);

            loading.GetComponent<Text>().DOText("11011101", 1, true, ScrambleMode.Custom, "LOADING");

            yield return new WaitForSeconds(1);
        }


    }

    IEnumerator nextScene()
    {
        yield return new WaitForSeconds(5);

        UnityEngine.SceneManagement.SceneManager.LoadScene("tutorial");
    }

    IEnumerator pressToContinue()
    {
        
        pressPanel.transform.DOMoveY(88, duration);
        if (pressToContinueAni)
        {
            yield return new WaitForSeconds(1);
            pressText.DOText("Press", 1, false, ScrambleMode.Custom, "10110");
            yield return new WaitForSeconds(.5f);
            toContinue.DOText(" to continue", 1, false, ScrambleMode.Custom, "11011010");
            pressToContinueAni = false;
        }
        pressToContinueButt.enabled = true;
    }

    public void OnClickSelectController(int no)
    {
        PlayerPrefs.SetInt("controller", no);

        Debug.Log(PlayerPrefs.GetInt("controller"));

        StartCoroutine(pressToContinue());
    }

    public void OnPressedToContinue()
    {
        exit();

        if (!IntroChecker)
        {
            Debug.Log("is playing");
            StartCoroutine(disclaimerPanel());
        }
        else if (!controlsChecker)
        {
            StartCoroutine(controllerPanels());
        }
        else if (!loadingChecker)
        {
            StartCoroutine(loadingPanels());
        }
        pressToContinueButt.enabled = false;
    }

    public void exit()
    {
        //up
        controllerText.transform.DOMoveY(canvasHeight + 400, duration);
        title.transform.DOMoveY(canvasHeight + 400, duration);

        //down
        pressPanel.transform.DOMoveY(-454, duration);
        introPanel.transform.DOMoveY(-454, duration);
        playQuitPanel.transform.DOMoveY(-454, duration);
        loading.transform.DOMoveY(-454, duration);

        //right
        oneHandedButton.transform.DOMoveX(canvasWidth + 300, duration);
        oneHandedButton.transform.DOMoveY(middleHeight, duration);
        //left
        twoHandedButton.transform.DOMoveX(-200, duration);
        twoHandedButton.transform.DOMoveY(middleHeight, duration);

    }
}
