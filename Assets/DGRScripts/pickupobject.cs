using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupobject : MonoBehaviour {

    GameObject player;
    SpringJoint joint;
    Rigidbody rb;
    CapsuleCollider col1;



	// Use this for initialization
	void Start () {

        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
        col1 = GetComponent<CapsuleCollider>();
        col1.enabled = true;


    }
	
	// Update is called once per frame
	void Update () {


        //joint.maxDistance = 1;
        //joint.autoConfigureConnectedAnchor = true;
        
        
		
	}

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            joint = gameObject.AddComponent<SpringJoint>();
            joint.connectedBody = player.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            joint.anchor = new Vector3(0, 18, 0);
            joint.maxDistance = 0.05f;
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = new Vector3(0, 0, 0);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ignore"))
        {
            col1.enabled = false;
        }
    }
}
