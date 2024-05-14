using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed;
    public Rigidbody2D rb;
    private float horizontalMotion;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(0, Random.Range(20, 40)));
    }

    // Update is called once per frame
    void Update()
    {

        Destroy(this.gameObject, 4f);
    }

    private void FixedUpdate()
    {
        Vector3 motion = new Vector3(speed * Time.deltaTime, 0, 0); //standard for vector motion (this is only for x axis)
        this.transform.position = this.transform.position + motion;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Orange IT")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
