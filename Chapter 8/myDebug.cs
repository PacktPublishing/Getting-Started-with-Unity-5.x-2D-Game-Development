using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics; //Needed for the conditional attribute

public class myDebug : MonoBehaviour {

    [Conditional("DEBUG_MODE")] //Conditional attribute
	public static void Log(string message) {
        //Print the log in the console
        UnityEngine.Debug.Log(message);
    }

    void Start() {
        
    }
}
