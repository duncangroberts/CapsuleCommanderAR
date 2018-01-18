using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class initialload : MonoBehaviour {

    public GameObject backgroundsound;
    public AudioSource thestuff;

	// Use this for initialization
	void Start () {

        DontDestroyOnLoad(backgroundsound);
        thestuff.Play();
        StartCoroutine(loadthegame());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void startit()
    {
        SceneManager.LoadScene("Menu");
    }

    public IEnumerator loadthegame()
    {
        yield return new WaitForSeconds(2);
        startit();
    }
}
