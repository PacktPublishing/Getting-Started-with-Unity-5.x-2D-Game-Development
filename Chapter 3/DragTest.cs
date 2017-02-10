using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragTest : MonoBehaviour, IDragHandler {


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnDrag(PointerEventData eventData) {
        transform.position = eventData.position;
        transform.position = Input.mousePosition;
    }
}
