using UnityEngine;
using System.Collections;

public class SmallBubble : MonoBehaviour {
    private Rigidbody rb;
    private Vector3 read;
    float mousex;
    float mousez;
    bool check = true;
    float nextupdate=0f;
    float waittime = 2f;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
	// Update is called once per frame
	void Update () {
        if (check)
        {

            
            rb.velocity = new Vector3(0f, 0f, 2f);
            check = false;
        }
        if (Time.time > nextupdate)
        {
            read = rb.velocity;
            nextupdate = Time.time + waittime;
            rb.velocity = new Vector3( read.x+(Random.value - .5f),  0f, read.z+(Random.value - .5f));
        }
    }
}
