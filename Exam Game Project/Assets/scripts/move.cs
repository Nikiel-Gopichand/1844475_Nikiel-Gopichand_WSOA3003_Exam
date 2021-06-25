using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public GameObject cam;
    Rigidbody2D rb;
    int speed = 3;
    public GameObject hair;
    public GameObject hand;
    public GameObject body;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"))*speed;
        body.GetComponent<Animator>().SetInteger("moving", (int)rb.velocity.magnitude);
        if (rb.velocity.x < 0)
        {
            hair.GetComponent<SpriteRenderer>().flipX =false;
            body.GetComponent<SpriteRenderer>().flipX = false;
            hand.GetComponent<SpriteRenderer>().flipX = false;
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (rb.velocity.x > 0)
        {
            hair.GetComponent<SpriteRenderer>().flipX = true;
            body.GetComponent<SpriteRenderer>().flipX = true;
            hand.GetComponent<SpriteRenderer>().flipX = true;
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}
