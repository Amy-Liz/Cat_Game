using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class StateController : MonoBehaviour
{

    public State currentState;
    // for staying in current state
    public State remainState;
    public CatStats catStats;
    public string catName;
    public string favToy;

    // eyes of agent
    public Transform eyes;

    // points to roam between
    public List<Transform> wayPointList;
    public int nextWayPoint;
    public NavMeshAgent navMeshAgent;
    public Transform persueTarget;

    private bool aiActive;
    private int stateTimeElapsed;

    private bool mouseOver = false;
    private Vector3 mousePos;
    private bool mouseClick = false;

    // Use this for initialization
    void Start()
    {

        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.enabled = true;
        aiActive = true;
        catStats = new CatStats(catName, favToy);

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

    // everytihng below is buggy but works!
    private void OnMouseOver()
    {
        mouseOver = true;

        if (Input.GetMouseButton(0))
        {
            mouseClick = true;
        }
        
        mousePos = Input.mousePosition;
        Debug.Log("MouseOver happened and is true");
    }

    private void OnMouseExit()
    {
        mouseOver = false;
        mouseClick = false;
        Debug.Log("MouseOver is no longer true");
    }

    private void OnGUI()
    {
        if (mouseOver && mouseClick)
        {
            Debug.Log("I should be drawing a box rn");
            GUI.Box(new Rect(mousePos.x, mousePos.y, 200f, 100f), "this is a test");
        }
    }
}
