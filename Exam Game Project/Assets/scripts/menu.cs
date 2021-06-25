using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (this.gameObject.tag == "bs")
            {


                GameObject.FindGameObjectWithTag("GameController").GetComponent<main>().enbs();
            }
            if (this.gameObject.tag == "w")
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<main>().enw();
            }
            if (this.gameObject.tag == "gs")
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<main>().engs();
            }
            if (this.gameObject.tag == "f")
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<main>().enf();
            }
            if (this.gameObject.tag == "h")
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<main>().enh();
            }
            if (this.gameObject.tag == "dout")
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<main>().endo();
            }
            if (this.gameObject.tag == "din")
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<main>().endi();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (this.gameObject.tag == "bs")
            {


                GameObject.FindGameObjectWithTag("GameController").GetComponent<main>().disbs();
            }
            if (this.gameObject.tag == "w")
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<main>().disw();
            }
            if (this.gameObject.tag == "gs")
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<main>().disgs();
            }
            if (this.gameObject.tag == "f")
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<main>().disf();
            }
            if (this.gameObject.tag == "h")
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<main>().dish();
            }
            if (this.gameObject.tag == "dout")
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<main>().dido();
            }
            if (this.gameObject.tag == "din")
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<main>().didi();
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
