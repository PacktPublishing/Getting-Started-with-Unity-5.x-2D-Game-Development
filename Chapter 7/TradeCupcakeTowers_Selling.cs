using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TradeCupcakeTowers_Selling : TradeCupcakeTowers {



    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if(currentActiveTower == null) {
            gameObject.SetActive(false);
        }
        else {
            gameObject.SetActive(true);
        }
    }

    public override void OnPointerClick(PointerEventData eventData) {
        //Check if there is a tower selected before to proceed
        if (currentActiveTower == null)
            return;

        //Add to the player's sugar the value of the tower
        sugarMeter.ChangeSugar(currentActiveTower.sellingValue);
        //Remove the Cupcake tower from the scene
        Destroy(currentActiveTower);
    }
}
