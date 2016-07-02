using UnityEngine;
using System.Collections;

public class HeydarDisabledBehaviour : StateMachineBehaviour {

    private float RandomTime;
    private float CurrentTime;
    private float AnimToSwitch;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        RandomTime = Random.Range(5.0f, 10.0f);
        CurrentTime = 0.0f;
        AnimToSwitch = Random.Range(0.0f, 5.0f);
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CurrentTime += Time.deltaTime;
        //if (animator.GetBool("IsUsing"))
        //    animator.SetBool("IsUsing", false);
        //if (animator.GetBool("IsIdleLookingAround"))
        //    animator.SetBool("IsIdleLookingAround", false);

        if (CurrentTime >= RandomTime && AnimToSwitch < 2.0f)
        {
            CurrentTime = 0.0f;
            RandomTime = Random.Range(5.0f, 10.0f);
            AnimToSwitch = Random.Range(0.0f, 5.0f);
            animator.SetBool("IsIdlePain", false);
            animator.SetBool("IsIdleFear", true);
        }
        else if(CurrentTime >= RandomTime && AnimToSwitch > 2.0f)
        {
            CurrentTime = 0.0f;
            RandomTime = Random.Range(5.0f, 10.0f);
            AnimToSwitch = Random.Range(0.0f, 5.0f);
            animator.SetBool("IsIdleFear", false);
            animator.SetBool("IsIdlePain", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
