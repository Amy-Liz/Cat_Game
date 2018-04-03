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

    private bool showToysMenu = false;
    private bool showOptionsMenu = false;

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

        if (catStats.hasTreat)
        {
            treatCounter++;
        }

        if (showToysMenu)
        {
            Debug.Log("I should be showing a new menu");

            Rect window = new Rect(0, 0, 200, 100);
            window = GUI.Window(1, window, ToysWindow, "Toys");
        }
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
        //mouseOver = false;
        //mouseClick = false;
        Debug.Log("MouseOver is no longer true");
    }

    private void OnGUI()
    {
        if(mouseOver && mouseClick)
        {
            showOptionsMenu = true;
        }

        if (showOptionsMenu)
        {

            Rect rect = new Rect(gameObject.transform.position.x, gameObject.transform.position.y, 200, 100);

            rect = GUI.Window(0, rect, OptionsWindow, "Options");
        }

        if (showToysMenu)
        {
            Rect rect = new Rect(mousePos.x, mousePos.y, 200, 100);

            rect = GUI.Window(0, rect, ToysWindow, "Toys");
        }
    }

    void OptionsWindow(int windowID)
    {
        if (GUI.Button(new Rect(1, 20, 100, 20), "Give Treat"))
        {
            catStats.hasTreat = true;
            showOptionsMenu = false;
            Debug.Log("Treat Given");
        }
        else if(GUI.Button(new Rect(1, 40, 100, 20), "Give Toy"))
        {
            showToysMenu = true;
            showOptionsMenu = false;
        }
    }

    void ToysWindow(int windowID)
    {
        if(GUI.Button(new Rect(1,20,100,20), "Yarn"))
        {
            showToysMenu = false;
            catStats.GiveToy("Yarn");
        }
    }

    void CheckBools()
    {

    }
}
