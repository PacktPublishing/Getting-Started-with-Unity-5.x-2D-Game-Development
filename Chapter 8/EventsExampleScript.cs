using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventsExampleScript : MonoBehaviour {

    //Float variable just for test. Can be set in the Inspector.
    public float myFloat;

    //Declaration of the event class. It has a float as parameter to pass.
    [System.Serializable]
    public class OnEveryFrame : UnityEvent<float> { }

    //Declare the variable event which will be shown in the Inspector
    public OnEveryFrame OnEveryFrameEvent;


    //Function that is called every frame
    void Update() {
        //fire the event at every frame
        OnEveryFrameEvent.Invoke(myFloat);
    }

}
