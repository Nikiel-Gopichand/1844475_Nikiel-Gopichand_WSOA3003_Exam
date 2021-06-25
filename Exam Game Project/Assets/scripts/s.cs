using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy" || collision.gameObject.tag == "king")
        {
            collision.gameObject.GetComponent<gobmove>().tdmg(GameObject.FindGameObjectWithTag("GameController").GetComponent<playerController>().ds());
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity * -5;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (GetComponent<SpriteRenderer>().sprite.name == "slash4_3")
        {
            GameObject.Destroy(this.gameObject);
        }

    }
}
