using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFunctionalities : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Function that loads the first level
    public void NewGame() {
        SceneManager.LoadScene(1);
    }

    //Function that displays the settings
    public void Settings() {
        //Your own code here
    }

    //Function that closes the game
    public void Quit() {
        Application.Quit();
    }
}
