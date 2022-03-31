using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class keycontroller : MonoBehaviour
{
    Rigidbody rb;
    Transform tr;
    [SerializeField] TextMeshProUGUI text;
    public static int score = 0;
    float vertical;
    float Horizontal;
    bool isGrounded = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        rb.AddRelativeForce(0,0,vertical*20f);
        Horizontal = Input.GetAxis("Horizontal");
        tr.Rotate(0,Horizontal,0);
        if (Input.GetKeyDown("space") && isGrounded == true)
             {
            rb.AddForce(0,30f,0,ForceMode.Impulse);
            rb.drag = 1;
            rb.angularDrag = 1;
            }
    
    }
    void OnCollisionEnter(Collision col){
        if(col.gameObject.tag =="ground"){
            isGrounded = true;
            rb.drag = 0;
            rb.angularDrag = 0;
        }
        if(col.gameObject.tag =="key"){
            score = score + 1;
            text.text = score + "/6";
            Destroy(col.gameObject);
        }
    }
    void OnCollisionExit(Collision col){
        if(col.gameObject.tag =="ground"){
            isGrounded = false;
            rb.AddForce(0,-100f,0);
        }
    }
        // if (Input.GetKeyDown("w"))
        // {
        //     rb.AddForce(0,0,100f);
        // }
        // if (Input.GetKeyDown("d"))
        // {
        //     rb.AddForce(100f,0,0);
        // }
        // if (Input.GetKeyDown("a"))
        // {
        //     rb.AddForce(-100f,0,0);
        // }
    
}
