using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// singleton - only one oinstance in whole game
public class GameManager : MonoBehaviour
{

    // belongs to class itself as opposed to instance of class
    public static GameManager instance = null;

    public SceneManager sceneManager;

	// Use this for initialization
	void Start ()
    {

        if(instance = null)
        {
            instance = this;

        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        // get scene manager
        sceneManager = GetComponent<SceneManager>();

        // initialize game
        InitGame();
	
	}

    void InitGame()
    {

        //sceneManager. whatever we want to call to set up scene

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
