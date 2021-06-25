using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gobmove : MonoBehaviour
{
    bool detected = false;
    Rigidbody2D rb;
    public GameObject body;
    int health;
    int dmg;
    // Start is called before the first frame update
    int counter;
    void Start()
    {
        counter = 0;
        rb = GetComponent<Rigidbody2D>();
        if (this.gameObject.tag == "enemy")
        {


            health = GameObject.FindGameObjectWithTag("GameController").GetComponent<goblinStats>().getH();
            dmg = GameObject.FindGameObjectWithTag("GameController").GetComponent<goblinStats>().getD();
        }
        if (this.gameObject.tag == "king")
        {


            health = GameObject.FindGameObjectWithTag("GameController").GetComponent<goblinStats>().getKH();
            dmg = GameObject.FindGameObjectWithTag("GameController").GetComponent<goblinStats>().getKD();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<playerController>().takeDMG(dmg);
            rb.velocity = -2*(GameObject.FindGameObjectWithTag("Player").transform.position - this.transform.position).normalized;
            detected = false;
            counter = 180;
        }
    }
    public void tdmg(int dmg)
    {
        health -= dmg;
    }
    // Update is called once per frame
    void Update()
    {
        if (detected == false && Vector2.Distance(this.transform.position,GameObject.FindGameObjectWithTag("Player").transform.position) <= 5 && counter <= 0)
        {
            detected = true;
            counter = 0;
        }
        if (detected == true)
        {
            rb.velocity = (GameObject.FindGameObjectWithTag("Player").transform.position - this.transform.position).normalized*2/(this.gameObject.tag == "king" ? 5 : 1);
            
        }
        body.GetComponent<Animator>().SetInteger("moving", (int)rb.velocity.magnitude);
        if (rb.velocity.x < 0)
        {
     
            body.GetComponent<SpriteRenderer>().flipX = false;
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (rb.velocity.x > 0)
        {

            body.GetComponent<SpriteRenderer>().flipX = true;
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (health <= 0)
        {
            //loot
            GameObject.FindGameObjectWithTag("GameController").GetComponent<main>().loot();
            if (this.gameObject.tag == "king")
            {

                // loot 2 times
                GameObject.FindGameObjectWithTag("GameController").GetComponent<main>().loot();

            }
            GameObject.Destroy(this.gameObject);
        }
        counter--;
    }
}
