using UnityEngine;
using System.Collections;

public class CupcakeTowerScript : MonoBehaviour {


    public int initialCost;   // How much this tower costs when it is bought
    public int upgradingCost; // How much this tower costs when it is upgraded
    public int sellingValue;  // How much this tower is valuable if sold

    //Boolean to check if the tower is upgradable
    public bool isUpgradable = true;

    private int upgradeLevel;        //Level of the Cupcake Tower
    public Sprite[] upgradeSprites; //Different sprites for the different levels of the Cupcake Tower
    public void Upgrade() {
        //Check if the tower is upgradable
        if (!isUpgradable) {
            return;
        }

        //Increase the level of the tower
        upgradeLevel++;

        //Check if the tower has reached its last level
        if(upgradeLevel < upgradeSprites.Length) {
            isUpgradable = false;
        }

        //Increase the stats of the tower
        rangeRadius += 1f;
        reloadTime -= 0.5f;

        //Change graphics of the tower
        GetComponent<SpriteRenderer>().sprite = upgradeSprites[upgradeLevel];

        //Increase the value of the tower;
        sellingValue += 5;

        //Increase the upgrading cost
        upgradingCost += 10;
    }

    public float rangeRadius;           //Maximum distance that the Cupcake Tower can shoot
    public float reloadTime;            //Time before the Cupcake Tower is able to shoot again
    public GameObject projectilePrefab; //Projectile type that is fired from the Cupcake Tower

    private float elapsedTime;          //Time elapsed from the last time the Cupcake Tower has shot

    //Implements the shooting logic
    void Update () {
        if (elapsedTime >= reloadTime) {
            //Reset elapsed Time
            elapsedTime = 0;

            //Find all the gameObjects with a collider within the range of the Cupcake Tower
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, rangeRadius);

            //Check if there is at least one gameObject found
            if (hitColliders.Length != 0) {
                //Loop over all the gameObjects to identify the closest to the Cupcake Tower
                float min = int.MaxValue;
                int index = -1;

                for (int i = 0; i < hitColliders.Length; i++) {
                    if (hitColliders[i].tag == "Enemy") {
                        float distance = Vector2.Distance(hitColliders[i].transform.position, transform.position);
                        if (distance < min) {
                            index = i;
                            min = distance;
                        }
                    }
                }
                if (index == -1)
                    return;

                //Get the direction of the target
                Transform target = hitColliders[index].transform;
                Vector2 direction = (target.position - transform.position).normalized;

                //Create the Projectile
                GameObject projectile = GameObject.Instantiate(projectilePrefab, transform.position, Quaternion.identity) as GameObject;
                projectile.GetComponent<ProjectileScript>().direction = direction;
            }
        }
        elapsedTime += Time.deltaTime;
    }

    //Function called when the player clicks on the Cupcake Tower
    void OnMouseDown() {
        //Assign this tower as the active tower for trading operations
        TradeCupcakeTowers.setActiveTower(this);
    }
}
