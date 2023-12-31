using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
        StartCoroutine(destroyObject());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator destroyObject()
    {
        yield return new WaitForSeconds(1f);

        Destroy(this.gameObject);
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("astroid"))
        {
            col.gameObject.GetComponent<astroid>().gotHit();
            Destroy(this.gameObject);
        }
    }
}
