using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

    //Private variable to store the next waypoint in the chain
    //It is serializable, so it can be set in the Inspector
    [SerializeField]
    private Waypoint nextWaypoint;

    //Function to retrieve the next waypoint in the chain
    public Waypoint GetNextWaypoint() {
        return nextWaypoint;
    }

    //Function to retrieve the position of the waypoint
    public Vector3 GetPosition() {
        return transform.position;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
