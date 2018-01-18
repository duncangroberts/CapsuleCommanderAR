using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanderCollision : MonoBehaviour {

    GoogleARCore.HelloAR.CCARCONTROLLERV2 controller;
    MeshExploder exploder;
    float time;
    bool starttimer;
    Animator[] anim;


    public void Start()
    {
        starttimer = false;
        time = 0f;
        anim = GetComponentsInChildren<Animator>();
        
        
    }

    public void Update()
    {
        controller = FindObjectOfType<GoogleARCore.HelloAR.CCARCONTROLLERV2>();
        exploder = GetComponentInChildren<MeshExploder>();

        if (controller.integrity <= 0)
        {
            exploder.Explode();
            Destroy(gameObject);
        }

        if (starttimer)
        {
            time += Time.deltaTime;
        }
        else
        {
            time = 0;
        }

        if (time > 3)
        {
            foreach (Animator mover in anim)
            {
                mover.enabled = true;

            }

            controller.hideallUI();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
            if (controller.landerspeed > 40)
            {
                
            controller.landerdestroyed = true;
            controller.bang.Play();
            exploder.Explode();
            Destroy(gameObject);


        }

        if (collision.gameObject.tag == "pad")
        {
            controller.integrity -= controller.landerspeed * 2;
            starttimer = true;
        }
        if (collision.gameObject.tag == "obstacle")
        {
            controller.integrity -= controller.landerspeed * 5;
        }
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "pad")
        {
            
            starttimer = false;
        }
    }


}
