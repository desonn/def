using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class Adcontrol : MonoBehaviour {
    string gameId = "3463046";
    string videoad = "video";
    bool testMode = false;
    // Use this for initialization
    void Start () {
        Advertisement.Initialize(gameId, testMode);
              
    }
    public void DisplayAds()
    {
        Advertisement.Show();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
