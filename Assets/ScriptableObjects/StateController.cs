using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class StateController : MonoBehaviour
{


    public State currentState;
    // for staying in current state
    public State remainState;
    public CatStats catStats;

    // eyes of agent
    public Transform eyes;

    // points to roam between
    public List<Transform> wayPointList;
    public int nextWayPoint;
    public NavMeshAgent navMeshAgent;
    public Transform persueTarget;

    private bool aiActive;
    private int stateTimeElapsed;

    // Use this for initialization
    void Start()
    {

        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.enabled = true;
        aiActive = true;

    }

    // Update is called once per frame
    void Update()
    {

        if (!aiActive)
        {
            return;
        }

        //check if AI is active first
        currentState.UpdateState(this);

    }

    void OnDrawGizmos()
    {
        if (currentState != null && eyes != null)
        {
            Gizmos.color = currentState.sceneGizmoColour;
            Gizmos.DrawWireSphere(eyes.position, 1f);
        }
    }

    public void TransitionToState(State nextState)
    {
        if (enabled = nextState != remainState)
        {
            // change states
            currentState = nextState;
            OnExitState();
        }
    }

    private void OnExitState()
    {
        stateTimeElapsed = 0;
    }
}
