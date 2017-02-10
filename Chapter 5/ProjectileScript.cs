using UnityEngine;
using System.Collections;

//THIS SCRIPT VERSION IS AT THE END OF CHAPTER 5
public class ProjectileScript : MonoBehaviour {

    public float damage;                //How much damage will the enemy receive
    public float speed = 1f;            //How fast the projectile moves

    public Vector3 direction;           //What direction the projectile is heading

    public float lifeDuration = 10f;    //How long the projectile lives before self-destructing


    private Rigidbody2D rb2D;           //Private variable to store the rigidbody2D


    // Initialize the direction, set the right rotation and the timer for self-destruction
    void Start() {
        //Get the reference to the Rigidbody2d
        rb2D = GetComponent<Rigidbody2D>();

        //Normalize the direction
        direction = direction.normalized;

        //Fix the rotation
        float angle = Mathf.Atan2(-direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //Set the timer for self-destruction
        Destroy(gameObject, lifeDuration);
    }

    // Update the position of the projectile according to time and speed
    void FixedUpdate() {
        rb2D.MovePosition(transform.position + direction * Time.fixedDeltaTime * speed);
    }
}
