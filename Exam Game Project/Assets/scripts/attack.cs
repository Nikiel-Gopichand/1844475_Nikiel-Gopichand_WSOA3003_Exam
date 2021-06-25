using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    public GameObject sword;
    public Camera cam;
    public GameObject player;
    Transform tf;
    public GameObject bow;
    public GameObject arrow;
    public GameObject ap;
    bool on = false;
    public GameObject slash;
    public GameObject sp;
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 po = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,1));
        po.z = 0;
        tf.localRotation = Quaternion.Euler(0,0,(po.y-tf.position.y > 0 && po.x-tf.position.x < 0 ? 90 - Mathf.Atan2(po.y - tf.position.y, -1*(po.x - tf.position.x)) * 180 / Mathf.PI :
            (po.y - tf.position.y < 0 && po.x - tf.position.x < 0 ? 90 + Mathf.Atan2(-1*(po.y - tf.position.y), -1*(po.x - tf.position.x)) * 180 / Mathf.PI :
            (po.y - tf.position.y < 0 && po.x - tf.position.x > 0 ? 270 - Mathf.Atan2(-1*(po.y - tf.position.y), po.x - tf.position.x) * 180 / Mathf.PI : 
            (po.y - tf.position.y > 0 && po.x - tf.position.x > 0 ? 270 + Mathf.Atan2(po.y - tf.position.y, po.x - tf.position.x) * 180 / Mathf.PI : 0)))));
    
        if (Input.GetMouseButtonDown(0) == true)
        {
            sword.GetComponent<Animator>().SetTrigger("sword");
            Instantiate(slash, sp.transform.position, sp.transform.rotation);
        }
        if (Input.GetMouseButtonDown(1) == true && GameObject.FindGameObjectWithTag("GameController").GetComponent<playerController>().anum() > 0)
        {
            bow.GetComponent<Animator>().SetTrigger("bow");
            on = true;
            
        }
        if (bow.GetComponent<SpriteRenderer>().sprite.name == "bow-5_7" && on == true)
        {
            Instantiate(arrow, ap.transform.position, ap.transform.rotation);
            GameObject.FindGameObjectWithTag("GameController").GetComponent<playerController>().useA();
            on = false;
        }
  
    }
}
