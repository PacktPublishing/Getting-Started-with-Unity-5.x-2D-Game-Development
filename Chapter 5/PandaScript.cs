using UnityEngine;
using System.Collections;

//THIS SCRIPT VERSION IS AT THE END OF CHAPTER 5
public class PandaScript : MonoBehaviour {

    //Private variable to store the animator for handling animations
    private Animator animator;

    //Public variables that express the characteristic of the Panda
    public float speed;     //The movement speed
    public float health;    //The amount of health

    //Hash representations of the Triggers of the Animator controller of the Panda
    private int AnimDieTriggerHash = Animator.StringToHash("DieTrigger");
    private int AnimHitTriggerHash = Animator.StringToHash("HitTrigger");
    private int AnimEatTriggerHash = Animator.StringToHash("EatTrigger");


    //Private variable to store the rigidbody2D
    private Rigidbody2D rb2D;

    // Use this for initialization
    void Start () {
        //Get the reference to the Animator
        animator = GetComponent<Animator>();

        //Get the reference to the Rigidbody2d
        rb2D = GetComponent<Rigidbody2D>();
    }

    //Function that based on the speed of the Panda makes it moving towards the destination point, specified as Vector3
    private void MoveTowards(Vector3 destination) {
        //Create a step and then move in towards destination of one step
        float step = speed * Time.fixedDeltaTime;
        rb2D.MovePosition(Vector3.MoveTowards(transform.position, destination, step));
    }

    /* Function that takes as input the damage that Panda received when hit by a sprinkle.
    *  After have detracted the damage to the amount of health of the Panda checks if the Panda
    *  is still alive, and so play the Hit animation, or if the health goes below zero the Die animation
    */
    private void Hit(float damage) {
        //Subtract the damage to the health of the Panda
        health -= damage;
        //Then it triggers the Die or the Hit animations based if the Panda is still alive
        if(health <= 0) {
            animator.SetTrigger(AnimDieTriggerHash);
        }
        else {
            animator.SetTrigger(AnimHitTriggerHash);
        }
    }
	
	//Function that detects projectiles
    void OnTriggerEnter2D(Collider2D other) {
        //Check if the other object is a projectile
        if(other.tag == "Projectile") {
            //Apply damage to this panda with the Hit function
            Hit(other.GetComponent<ProjectileScript>().damage);
        }
    }

}
