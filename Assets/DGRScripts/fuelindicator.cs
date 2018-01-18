using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fuelindicator : MonoBehaviour
{

    public Text fuel;
    GoogleARCore.HelloAR.CCARCONTROLLERV2 controller;
    Color green;
    Color Red;

    // Use this for initialization
    void Start()
    {

        controller = FindObjectOfType<GoogleARCore.HelloAR.CCARCONTROLLERV2>();
        green = new Color(0f, 0f, 255f);


    }

    // Update is called once per frame
    void Update()
    {

        if (controller.fuel < 100)
        {
            fuel.color = Color.red;
        }
        else
        {
            fuel.color = green;
        }

    }
}

