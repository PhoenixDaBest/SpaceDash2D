using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIAnimationController : MonoBehaviour
{
    public GameObject playQuitPanel, title;

    public float duration = 2;
    // Start is called before the first frame update
    void Start()
    {
        entry();
    }

    void entry()
    {
        playQuitPanel.transform.DOMoveY(543, duration).SetEase(Ease.OutBack);
        title.transform.DOMoveY(1757, duration).SetEase(Ease.OutBack);
    }

    public void exit()
    {
        playQuitPanel.transform.DOMoveY(-1502, duration).SetEase(Ease.InBack);
        title.transform.DOMoveY(2590, duration).SetEase(Ease.InBack);
    }
}
