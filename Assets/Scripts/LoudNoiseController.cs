using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoudNoiseController : MonoBehaviour
{


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
            CatStats[] cats = FindObjectsOfType<CatStats>();

            for(int i = 0; i < cats.Length; i++)
            {
                UpdateBools(cats[i]);
            }
        }
    }

    private void UpdateBools(CatStats current)
    {

        Debug.Log("agent: " + current.name);

        current.isDistressed = true;

        if (current.hasToy)
        {
            current.hasToy = false;
        }

        if (current.hasFavToy)
        {
            current.hasFavToy = false;
        }

        if (current.hasTreat)
        {
            current.hasTreat = false;
        }
    }
}
