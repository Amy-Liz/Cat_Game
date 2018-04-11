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
    public Canvas[] canvases;
    public ParticleSystem[] particles;

    // points to roam between
    public List<Transform> wayPointList;
    public int nextWayPoint;
    public NavMeshAgent navMeshAgent;
    public Transform target;
    public bool targetSeen = false;

    private int stateTimeElapsed;

    private bool showToysMenu = false;
    private bool showOptionsMenu = false;

    // Use this for initialization
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.enabled = true;
        navMeshAgent.isStopped = false;
        catStats = new CatStats(catName, favToy);

        // no messages on start
        for(int i = 0; i < canvases.Length; i++)
        {
            canvases[i].enabled = false;
        }

        if(gameObject.tag == "Timid")
        {
            catStats.UpdateDistress();
        }

        for (int i = 0; i < particles.Length; i++)
        {
            particles[i].Pause();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentState.name);

        if(currentState.name.Contains("Joy"))
        {
            Debug.Log("only joy should be showing");
            particles[0].Play();
        }
        else if(currentState.name.Contains("Love"))
        {
            particles[1].Play();
        }
        else if(currentState.name.Contains("Distress"))
        {
            particles[2].Play();
        }
        else if(currentState.name.Contains("Satisfied"))
        {
            particles[3].Play();
        }
        else if(currentState.name.Contains("Disappointed"))
        {
            particles[4].Play();
        }

        SetAgentPlayStatus();

        if (catStats.hasResponse)
        {
            catStats.hasResponse = false;
            navMeshAgent.isStopped = false;
        }

        currentState.UpdateState(this);
    }

    void OnDrawGizmos()
    {
        if (currentState != null)
        {
            Gizmos.color = currentState.sceneGizmoColour;
            Gizmos.DrawWireSphere(gameObject.transform.position, 10f);
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

    public void StopNavMeshAgent()
    {
        navMeshAgent.isStopped = true;
    }

    public void SetAgentPlayStatus()
    {
        // will play in Joy or Satisfied states 
        if(currentState.name.Contains("Joy") || currentState.name.Contains("Satisfied"))
        {
            catStats.SetWillPlayStatus(true);
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

            catStats.GiveTreat();

            if(gameObject.tag == "Timid")
            {
                catStats.UpdateDistress();
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
            catStats.PetCat();
        }
    }

    void ToysWindow(int windowID)
    {
        if(GUI.Button(new Rect(1, 20, 100, 20), "Yarn"))
        {
            showToysMenu = false;
            catStats.GiveToy("Yarn");

            if(gameObject.tag == "Timid")
            {
                // removes timid agent from distressed state
                catStats.UpdateDistress();
            }
        }

        if(GUI.Button(new Rect(1, 40, 100, 20), "Mouse"))
        {
            showToysMenu = false;
            catStats.GiveToy("Mouse");
        }

        if(GUI.Button(new Rect(1, 60, 100, 20), "Ball"))
        {
            showToysMenu = false;
            catStats.GiveToy("Ball");
        }

        if(GUI.Button(new Rect(1, 80, 100, 20), "Feather"))
        {
            showToysMenu = false;
            catStats.GiveToy("Feather");
        }

        catStats.CheckToy();
    }

    #endregion
}
