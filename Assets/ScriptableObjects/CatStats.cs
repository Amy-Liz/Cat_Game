using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatStats : ScriptableObject {

    // all possible toys
    enum Toys
    {
        Yarn,
        Mouse,
        Ball,
        Bell,
        Feather
    };

    // always start unoccupied
    public bool agentOccupied = false;

    // initially no noise
    public bool loudNoise = false;

    private string identifier; //name
    private Toys favToy;
    // for looking
    public float lookSphereCastRadius = 1f;
}


