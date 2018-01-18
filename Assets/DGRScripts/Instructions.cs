using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Instructions : MonoBehaviour {

    public GameObject initialScan;
    public GameObject buttonDescriptions;
    public GameObject pickupdropoffDescriptions;
    public GameObject scalerDescriptions;
    public GameObject finaliseButtons;
    public GameObject directions;
    public GameObject next1but;
    public GameObject next2but;
    public GameObject next3but;
    public GameObject next4but;
    public GameObject next5but;
    public GameObject mainmenubut;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void next1()
    {
        initialScan.SetActive(false);
        buttonDescriptions.SetActive(true);
        pickupdropoffDescriptions.SetActive(false);
        scalerDescriptions.SetActive(false);
        finaliseButtons.SetActive(false);
        directions.SetActive(false);  
        next1but.SetActive(false);
        next2but.SetActive(true);
    }
    public void next2()
    {
        initialScan.SetActive(false);
        buttonDescriptions.SetActive(false);
        pickupdropoffDescriptions.SetActive(true);
        scalerDescriptions.SetActive(false);
        finaliseButtons.SetActive(false);
        directions.SetActive(false);
        next2but.SetActive(false);
        next3but.SetActive(true);
    }
    public void next3()
    {
        initialScan.SetActive(false);
        buttonDescriptions.SetActive(false);
        pickupdropoffDescriptions.SetActive(false);
        scalerDescriptions.SetActive(true);
        finaliseButtons.SetActive(false);
        directions.SetActive(false);
        next3but.SetActive(false);
        next4but.SetActive(true);
    }
    public void next4()
    {
        initialScan.SetActive(false);
        buttonDescriptions.SetActive(false);
        pickupdropoffDescriptions.SetActive(false);
        scalerDescriptions.SetActive(false);
        finaliseButtons.SetActive(true);
        directions.SetActive(false);
        next4but.SetActive(false);
        next5but.SetActive(true);
    }
    public void next5()
    {
        initialScan.SetActive(false);
        buttonDescriptions.SetActive(false);
        pickupdropoffDescriptions.SetActive(false);
        scalerDescriptions.SetActive(false);
        finaliseButtons.SetActive(false);
        directions.SetActive(true);
        next5but.SetActive(false);
        mainmenubut.SetActive(true);
    }
    public void mainmenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
