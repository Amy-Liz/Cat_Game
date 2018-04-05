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
    }

    void OnDrawGizmos()
    {
        if (currentState != null && eyes != null)
        {
            Gizmos.color = currentState.sceneGizmoColour;
            Gizmos.DrawWireSphere(eyes.position, 10f);
        }
    }

    public void TransitionToState(State nextState)
    {
        if (nextState != remainState)
        {
            // change states
            currentState = nextState;
        }
    }

    #region GUI

    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            showOptionsMenu = true;
        }
    }

    private void OnGUI()
    {
        if (showOptionsMenu)
        {
            Rect rect = new Rect(gameObject.transform.position.x, gameObject.transform.position.y, 100, 100);

            rect = GUI.Window(0, rect, OptionsWindow, "Options");
        }

        if (showToysMenu)
        {
            Rect rect = new Rect(gameObject.transform.position.x, gameObject.transform.position.y, 100, 100);

            rect = GUI.Window(0, rect, ToysWindow, "Toys");
        }
    }

    void OptionsWindow(int windowID)
    {
        if (GUI.Button(new Rect(1, 20, 100, 20), "Give Treat"))
        {
            showOptionsMenu = false;
            catStats.hasTreat = true;

            if (catStats.hasToy)
            {
                catStats.hasToy = false;
                catStats.hasFavToy = false;
            }

            if (catStats.isPet)
            {
                catStats.isPet = false;
            }
        }

        if (GUI.Button(new Rect(1, 40, 100, 20), "Give Toy"))
        {
            showOptionsMenu = false;
            showToysMenu = true;
        }

        if (GUI.Button(new Rect(1, 60, 100, 20), "Pet"))
        {
            showOptionsMenu = false;
            catStats.isPet = true;
            catStats.hasTreat = false;

            if (catStats.hasToy)
            {
                catStats.hasToy = false;
                catStats.hasFavToy = false;
            }
        }
    }

    void ToysWindow(int windowID)
    {
        if(GUI.Button(new Rect(1, 20, 100, 20), "Yarn"))
        {
            showToysMenu = false;
            catStats.GiveToy("Yarn");

            UpdateOnToy();
        }

        if(GUI.Button(new Rect(1, 40, 100, 20), "Mouse"))
        {
            showToysMenu = false;
            catStats.GiveToy("Mouse");

            UpdateOnToy();
        }

        if(GUI.Button(new Rect(1, 60, 100, 20), "Ball"))
        {
            showToysMenu = false;
            catStats.GiveToy("Ball");

            UpdateOnToy();
        }

        if(GUI.Button(new Rect(1, 80, 100, 20), "Feather"))
        {
            showToysMenu = false;
            catStats.GiveToy("Feather");

            UpdateOnToy();
        }

        catStats.CheckToy();
    }

    private void UpdateOnToy()
    {
        if (catStats.isPet)
        {
            catStats.isPet = false;
        }

        if (catStats.hasTreat)
        {
            catStats.hasTreat = false;
        }

        // quick fix for friendly agent, will change in future
        if(catStats.favToy.ToString() == "none")
        {
            catStats.isDistressed = false;
        }
    }

    #endregion
}
