using UnityEngine;

public class FSM_Piss : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject NPC_00 = GameObject.Find("NPC_00");
        // get AIState_Piss child in NPC_000
        GameObject AIState_Piss = NPC_00.transform.Find("AIState_Piss").gameObject;
        // access animator component of AIState_Piss
        Animator AIState_Piss_animator = AIState_Piss.GetComponent<Animator>();
        // rebind AIState_Piss
        AIState_Piss_animator.Rebind(); // This restarts the animator from the beginning
    }
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
