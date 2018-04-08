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
                cats[i].OnLoudNoise();
            }
        }
    }
}
