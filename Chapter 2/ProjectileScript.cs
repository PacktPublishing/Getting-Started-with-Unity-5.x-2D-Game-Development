using UnityEngine;
using System.Collections;

//THIS SCRIPT VERSION IS AT THE END OF CHAPTER 2
public class ProjectileScript : MonoBehaviour {

    public float damage;                //How much damage will the enemy receive
    public float speed = 1f;            //How fast the projectile moves

    public Vector3 direction;           //What direction the projectile is heading

    public float lifeDuration = 10f;    //How long the projectile lives before self-destructing


    // Initialize the direction, set the right rotation and the timer for self-destruction
    void Start() {
        //Normalize the direction
        direction = direction.normalized;

        //Fix the rotation
        float angle = Mathf.Atan2(-direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //Set the timer for self-destruction
        Destroy(gameObject, lifeDuration);
    }

    // Update the position of the projectile according to time and speed
    void Update() {
        transform.position += direction * Time.deltaTime * speed;
    }
}
