using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FSM_PissWaypoint : StateMachineBehaviour
{
    GameObject NPC_00;

    // list of gameObject waypoints
    List<GameObject> waypoints;
    [SerializeField] Transform WaypointTarget;

    

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // debug statement 
        Debug.Log("Entering Piss State");

        // get all waypoints with tag Waypoint
        waypoints = new List<GameObject>(GameObject.FindGameObjectsWithTag("Waypoint"));
        WaypointTarget = waypoints[Random.Range(0, waypoints.Count)].transform;

        NPC_00 = GameObject.Find("NPC_00");
        NPC_00.GetComponent<NavMeshAgent>().SetDestination(WaypointTarget.position);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Debug log showing the current state
        Debug.Log("On State Update ~ Piss State");
        //Debug.Log($"Distance from piss spot - { Vector3.Distance(NPC_00.transform.position, WaypointTarget.position)}");
        // get parent object of the object containing the animator

        if (Vector3.Distance(NPC_00.transform.position, WaypointTarget.position) < 0.1f)
        {
            NPC_00.GetComponentInChildren<Animator>().SetBool("isPissing", false);
            Debug.Log("No more piss");
        }

        //NPC_00.transform.position = Vector3.MoveTowards(animator.transform.position, WaypointTarget.position, GameManager.Instance.NPC_AI_01.Speed * Time.deltaTime);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NPC_00.GetComponent<NavMeshAgent>().ResetPath();
        // debug statement 
        Debug.Log("Exiting Piss State");
    }

}
