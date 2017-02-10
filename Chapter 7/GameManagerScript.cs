using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {

    //public waypoint list as an array of positions
    public Vector3[] waypoints;

    //Private bariable to store the reference to the Player's health
    private HealthBarScript playerHealth;

    // Use this for initialization
    void Start () {
        //Get the reference to the Player's health
        playerHealth = FindObjectOfType<HealthBarScript>();
    }
	
	// Update is called once per frame
	void Update () {
        
	}


    //**************************PLACING TOWER REGION***********************

    //Private variable to check if the mouse is hovering an area where a
    //Cupcake tower can be placed
    private bool _isPointerOnAllowedArea = true;

    //Function that returns true if the mouse is hovering an area where a
    //Cupcake tower can be placed
    public bool isPointerOnAllowedArea() {
        return _isPointerOnAllowedArea;
    }

    //Function which is called when the mouse enters in one of the
    //colliders of the Game Manager
    void OnMouseEnter() {
        //Set that the mouse is now hovering an area where placing Cupcake
        //towers is allowed
        _isPointerOnAllowedArea = true;
    }

    //Function which is called when the mouse exits from one of the
    //colliders of the Game Manager
    void OnMouseExit() {
        //Set that the mouse is not hovering anymore an area where placing
        //Cupcake towers is allowed
        _isPointerOnAllowedArea = false;
    }



    //*******************************GAME OVER REGION***********************

    //Variable to store the the screen displayed when the player loses
    public GameObject losingScreen;

    //Variable to store the screen displayed when the player wins
    public GameObject winningScreen;

    //Private function called when some gameover conditions are met, and displays 
    //the winning or losing screen depending from the value of the parameter passed.
    private void GameOver(bool playerHasWon) {
        //Check if the player has won from the parameter
        if (playerHasWon) {
            //Display the winning screen
            winningScreen.SetActive(true);
        }else {
            //Display the loosing screen
            losingScreen.SetActive(true);
        }

        //Freeze the game time, so to stop in some way the level to be executed
        Time.timeScale = 0;
    }


    //***********TRACKING REGION***************************

    //Private variable which acts as a counter of how many pandas are remained to defeat
    private int numberOfPandasToDefeat;

    //Function that decreases the number of pandas still to defeat every time a panda dies 
    public void OneMorePandaInHeaven() {
        numberOfPandasToDefeat--;
    }

    //Function that damages the player when a Panda reaches the player's cake.
    //Moreover, it monitors the player's health to trigger the GameOver function when needed
    public void BiteTheCake(int damage) {
        //Apply damage to the player and retrive a boolean to see if the cake has been eaten all
        bool IsCakeAllEaten = playerHealth.ApplyDamage(damage);
        //If the cake has been eaten all, the GameOver function is called in "losing mode"
        if (IsCakeAllEaten) {
            GameOver(false);
        }
        //The Panda that bit the cake will also explode, and therefore we have a Panda less to defeat
        OneMorePandaInHeaven();
    }

    //*************SPAWNING REGION********************

    //The Panda prefab that should be spawned as enemy
    public GameObject pandaPrefab;

    //The Spawning Point transform so to get where the pandas should be spawned
    private Transform spawner;

    //The number of waves that the player has to face in this level
    public int numberOfWaves;

    //The number of pandas that the player as to face per wave.
    //It increase when a wave is won.
    public int numberOfPandasPerWave;

    

    //Coroutine that spawns the different waves of Pandas
    private IEnumerator WavesSpawner() {
        //For each wave
        for(int i = 0; i < numberOfWaves; i++) {
            //Let the PandaSpawner coroutine to handle the single wave. When it finishes
            //also the wave is finished, and so this coroutine can continue.
            yield return PandaSpawner();
            //Increase the number of Pandas that are generated per wave
            numberOfPandasPerWave += 3;
        }

        //If the Player won all the waves, call the GameOver function in "winning" mode
        GameOver(true);
    }

    //Coroutine that spawns the pandas for a single wave, and waits until "all the pandas are in Heaven"
    private IEnumerator PandaSpawner() {
        //Initialize the number that needs to be defeated for this wave
        numberOfPandasToDefeat = numberOfPandasPerWave;

        //Progressively spawn pandas
        for (int i=0; i < numberOfPandasPerWave; i++) {
            //Spawn/Instantiate a Panda at the Spawner position
            Instantiate(pandaPrefab, spawner.position, Quaternion.identity);

            //Wait a time that depends both on how many pandas are left to be
            //spawned and by a random number
            float ratio = (i * 1f) / (numberOfPandasPerWave - 1);
            float timeToWait = Mathf.Lerp(3f, 5f, ratio) + Random.Range(0f, 2f);
            yield return new WaitForSeconds(timeToWait);
        }

        //Once all the Pandas are spawned, wait until all of them are defeated
        //by the player (or a gameover condition occurred before)
        yield return new WaitUntil(() => numberOfPandasToDefeat <= 0);
    }
}
