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
    }
}
