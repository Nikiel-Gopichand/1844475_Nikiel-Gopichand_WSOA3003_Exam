using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowmove : MonoBehaviour
{
    public GameObject ap;
   
    Transform tf;
    // Start is called before the first frame update
    void Start()
    {
       
        tf = GetComponent<Transform>();
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy" || collision.gameObject.tag == "king")
        {
            collision.gameObject.GetComponent<gobmove>().tdmg(GameObject.FindGameObjectWithTag("GameController").GetComponent<playerController>().db());
            
        }
        GameObject.Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        tf.position += tf.right/-50;
    }
}
