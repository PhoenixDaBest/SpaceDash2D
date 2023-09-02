using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class astroid : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float rotationSpeed;
    public float health;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * -speed;
        StartCoroutine(destroyObject());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, Random.Range(60, rotationSpeed) * Time.deltaTime);
    }

    IEnumerator destroyObject()
    {
        yield return new WaitForSeconds(5f);

        Destroy(this.gameObject);
    }

    public void gotHit()
    {
        health--;
        if(health == 0)
        {
            Destroy(this.gameObject);
        }
        
    }
}
