using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class TradeCupcakeTowers : MonoBehaviour, IPointerClickHandler {

    // Variable to store the Sugar Meter
    protected static SugarMeterScript sugarMeter;

    //Variable to store the current selected tower by the player
    protected static CupcakeTowerScript currentActiveTower;

	// Use this for initialization
	void Start () {
        //If the reference to the Sugar Meter is missing, the script gets it
        if (sugarMeter == null) {
            sugarMeter = FindObjectOfType<SugarMeterScript>();
        }     
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Static function that allows other scripts to assign the new/current selected tower
    public static void setActiveTower(CupcakeTowerScript cupcakeTower) {
        currentActiveTower = cupcakeTower;
    }

    // Abstract function triggered when one of the trading buttons is pressed, however the
    // implementation is specific for each trade operation.
    public abstract void OnPointerClick(PointerEventData eventData);
}
