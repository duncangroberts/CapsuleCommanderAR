using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilt : MonoBehaviour
{

    public float speed;
    Rigidbody rb;
    Quaternion ori;
    public float sensitivity;
    public Vector3 trans;
    public bool startengines;
    bool increasespeed;
    float height;
    float climbrotation;
    float maxheight;
    float lastPosX;
    float lastPosY;
    float lastPosZ;
    bool left;
    bool right;
    bool up;
    bool down;
    GameObject lander;
    stabilise stablisier;



    // Use this for initialization
    void Start()
    {

        speed = 0;
        rb = GetComponent<Rigidbody>();
        sensitivity = 15.0f;
        stablisier = GetComponent<stabilise>();
        stablisier.enabled = false;
        









    }

    // Update is called once per frame
    void Update()
    {

        lander = GameObject.FindGameObjectWithTag("Player");



        if (left)

        {

            lander.transform.Rotate(0, 0, sensitivity * Time.deltaTime);
        }
        if (right)


        {

            lander.transform.Rotate(0, 0, -sensitivity * Time.deltaTime);
        }




        if (up)


        {

            lander.transform.Rotate(sensitivity * Time.deltaTime, 0, 0);

        }





        if (down)


        {

            lander.transform.Rotate(-sensitivity * Time.deltaTime, 0, 0);
        }

        
        if (transform.localEulerAngles.y > 0)
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 0, transform.localEulerAngles.z);
        }
        if (transform.localEulerAngles.y < 0)
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 0, transform.localEulerAngles.z);
        }
        
    }


    public void OnUpdown()
    {
        up = true;
        stablisier.enabled = false;
    }
    public void onupup()
    {
        up = false;
        stablisier.enabled = true;
    }
    public void ondowndown()
    {
        down = true;
        stablisier.enabled = false;
    }
    public void OnDownUp()
    {
        down = false;
        stablisier.enabled = true;
    }
    public void Onleftdown()
    {
        left = true;
        stablisier.enabled = false;
    }
    public void Onleftup()
    {
        left = false;
        stablisier.enabled = true;
    }
    public void onrightdown()
    {
        right = true;
        stablisier.enabled = false;
    }
    public void onrightup()
    {
        right = false;
        stablisier.enabled = true;
    }

}








        



