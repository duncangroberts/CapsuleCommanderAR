using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class speedindicatorcoclours : MonoBehaviour {

    public Text speed;
    GoogleARCore.HelloAR.CCARCONTROLLERV2 controller;
    Color green;
    Color Red;

	// Use this for initialization
	void Start () {

        controller = FindObjectOfType<GoogleARCore.HelloAR.CCARCONTROLLERV2>();
        green = new Color(0f, 0f, 255f);
        
		
	}
	
	// Update is called once per frame
	void Update () {

        if (controller.landerspeed > 40)
        {
            speed.color = Color.red;
        }
        else
        {
            speed.color = green;     
        }
		
	}
}
