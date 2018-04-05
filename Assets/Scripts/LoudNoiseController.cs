using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoudNoiseController : MonoBehaviour {

    private StateController[] controllers = new StateController[3];

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnGUI()
    {
        if(GUI.Button(new Rect(0,0,100,20), "BANG"))
        {
            StateController[] controllers = FindObjectsOfType<StateController>();

            for(int i = 0; i < controllers.Length; i++)
            {
                controllers[i].catStats.isDistressed = true;
            }
        }
    }
}
