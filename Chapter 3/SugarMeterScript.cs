using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SugarMeterScript : MonoBehaviour {

    private Text sugarMeter; //Reference to the Text component
    private int sugar; //Amount of sugar that the player possesses

	void Start () {
        //Get the reference to the Sugar_Meter_Text
        sugarMeter = GetComponentInChildren<Text>();
        //Update the Sugar Meter graphic 
        updateSugarMeter();
    }
	
    //Function to increase or decrease the amount of sugar
    public void ChangeSugar(int value) {
        //Increase (or decrease, if value is negative) the amount of sugar
        sugar += value;
        //Check if the amount of suguar is negative, is so set it to zero
        if(sugar < 0) {
            sugar = 0;
        }
        //Update the Sugar Meter graphic 
        updateSugarMeter();
    }

    //Function to return the amount of sugur, since it is a private variable
    public int getSugarAmount() {
        return sugar;
    }

    //Function to update the Sugar Meter graphic 
    void updateSugarMeter() {
        //Assign the amount of sugar converted to a string to the text in the Sugar Meter
        sugarMeter.text = sugar.ToString();
    }
}
