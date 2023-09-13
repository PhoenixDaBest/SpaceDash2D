using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIAnimationController1 : MonoBehaviour
{

    public GameObject loading;
    public int duration;

    public GameObject gameBackground;
    public GameObject player;

    public Text narrat;



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

        setHeightWidthValues();
        exit();

        StartCoroutine(starting()); 
    }

    void setHeightWidthValues()
    {
        canvasHeight = Vector3.Distance(obj.transform.position, objy.transform.position);
        canvasWidth = Vector3.Distance(obj.transform.position, objx.transform.position);

        middleHeight = canvasHeight / 2;
        topTitleHeight = canvasHeight - 200;
        bottomHeight = canvasHeight + 200;

        Debug.Log(Vector3.Distance(obj.transform.position, objx.transform.position));

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void exit()
    {
        //up
        loading.transform.DOMoveY(canvasHeight + 200, duration);

    }

    IEnumerator starting()
    {
        yield return new WaitForSeconds(3);

        gameBackground.GetComponent<SpriteRenderer>().material.DOFade(0, 2);


        yield return new WaitForSeconds(2);

        player.transform.DOMoveY(-3.89f, duration);


        yield return new WaitForSeconds(3);

        StartCoroutine(textSeq());
    }

    IEnumerator textSeq()
    {
        //Seq-1
        narrat.DOText("110110111 10 110 1011010111, 110101", 1, false, ScrambleMode.None);

        yield return new WaitForSeconds(1.5f);

        narrat.DOText("Welcome to the simulation, player", 1, false, ScrambleMode.Custom, "110110111 10 110 1011010111, 110101");

        //Seq-1
        yield return new WaitForSeconds(5f);
        narrat.DOText("", .1f, false, ScrambleMode.None);
        narrat.DOText("1101 10 1 1010 1010110101 10110101 101 101", 1, false, ScrambleMode.None);

        yield return new WaitForSeconds(1.5f);

        narrat.DOText("This is a beta simulation initiated by Dev", 1, false, ScrambleMode.Custom, "1101 10 1 1010 1010110101 10110101 101 101");

        yield return new WaitForSeconds(5f);

        //Seq-1
        narrat.DOText("", .1f, false, ScrambleMode.None);
        narrat.DOText("1011 10101101 101101 1011 10 11011 1101011", 1, false, ScrambleMode.None);

        yield return new WaitForSeconds(1.5f);

        narrat.DOText("Try touching either side of your screen", 1, false, ScrambleMode.Custom, "1011 10101101 101101 1011 10 11011 1101011");

        yield return new WaitForSeconds(5f);

        //Seq-1
        narrat.DOText("", .1f, false, ScrambleMode.None);
        narrat.DOText("110 1011011 10 10110 10 10101 1010 101 10101", 1, false, ScrambleMode.None);

        yield return new WaitForSeconds(1.5f);

        narrat.DOText("you should be able to move left and right", 1, false, ScrambleMode.Custom, "110 1011011 10 10110 10 10101 1010 101 10101");

        yield return new WaitForSeconds(5f);

        //Seq-1
        narrat.DOText("", .1f, false, ScrambleMode.None);
        narrat.DOText("110 1011011 10 10110 10 10101 1010 101 10101", 1, false, ScrambleMode.None);

        yield return new WaitForSeconds(1.5f);

        narrat.DOText("you should be able to move left and right", 1, false, ScrambleMode.Custom, "110 1011011 10 10110 10 10101 1010 101 10101");

        yield return new WaitForSeconds(5f);

        //Seq-1
        narrat.DOText("", .1f, false, ScrambleMode.None);
        narrat.DOText("1101110 10", 1, false, ScrambleMode.None);

        yield return new WaitForSeconds(1.5f);

        narrat.DOText("Great !", 1, false, ScrambleMode.Custom, "1101110 10");

        yield return new WaitForSeconds(5f);

        //Seq-1
        narrat.DOText("", .1f, false, ScrambleMode.None);
        narrat.DOText("1101110 10", 1, false, ScrambleMode.None);

        yield return new WaitForSeconds(1.5f);

        narrat.DOText("Great !", 1, false, ScrambleMode.Custom, "1101110 10");

        yield return new WaitForSeconds(2f);

        //Seq-1
        narrat.DOText("", .1f, false, ScrambleMode.None);
        narrat.DOText("1101 1010111010 10 1010", 1, false, ScrambleMode.None);

        yield return new WaitForSeconds(1.5f);

        narrat.DOText("The simulation is over", 1, false, ScrambleMode.Custom, "1101 1010111010 10 1010");

        yield return new WaitForSeconds(5f);

        //Seq-1
        narrat.DOText("", .1f, false, ScrambleMode.None);
        narrat.DOText("110110101", 1, false, ScrambleMode.None);

        yield return new WaitForSeconds(1.5f);

        narrat.DOText("Goodbye", 1, false, ScrambleMode.Custom, "110110101");

        yield return new WaitForSeconds(5f);
        Application.Quit();
    }

}
