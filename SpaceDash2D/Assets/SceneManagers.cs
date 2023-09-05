using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagers : MonoBehaviour
{
    public UIAnimationController UIA;
    // Start is called before the first frame update
    void Start()
    {
        UIA = GameObject.Find("UIManager").GetComponent<UIAnimationController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playGame()
    {
        UIA.exit();
        StartCoroutine(waitingToPlay(2, 1));
        //SceneManager.LoadScene(1);
    }

    IEnumerator waitingToPlay(float x, int scene)
    {
        yield return new WaitForSeconds(x);

        SceneManager.LoadScene(scene);
    }
}
