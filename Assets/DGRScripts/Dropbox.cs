using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropbox : MonoBehaviour {

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ignore")
        {
            var box = GameObject.FindGameObjectWithTag("dropbox");
            Destroy(box);
        }
    }
}
