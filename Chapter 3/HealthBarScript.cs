using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBarScript : MonoBehaviour {

    public int maxHealth; //The maximum amount of health that the player can possess
    private Image fillingImage; //The reference to "Health_Bar_Filling" Image component
    private int health;  //The current amount of health of the player

    void Start () {
        //Get the reference to the filling image
        fillingImage = GetComponentInChildren<Image>();
        //set the health to the maximum
        health = maxHealth;
        //Update the graphics of the Health Bar.
        updateHealthBar();
    }

    //Function to apply damage to the player
    public bool ApplyDamage(int value) {
        //Apply damage to the player
        health -= value;
        //Check if the player has still health and update the Health Bar
        if(health > 0) {
            updateHealthBar();
            return false;
        }

        //In case the player has no health left, set health to zero and return true
        health = 0;
        updateHealthBar();
        return true;
    }
	
    //Function to update the Health Bar Graphic
    void updateHealthBar() {
        //Calculate the percentage (from 0% to 100%) of the current amount of health of the player
        float percentage = health * 1f / maxHealth;
        //Assign the percentage to the fillingAmount variable of the "Health_Bar_Filling"
        fillingImage.fillAmount = percentage;
    }
}
