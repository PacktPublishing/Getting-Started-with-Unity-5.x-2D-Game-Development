using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineBehaviour_DestroyOnExit : StateMachineBehaviour {

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        //Destroy the gameobject where the animator is attached to
        Destroy(animator.gameObject);
    }

}
