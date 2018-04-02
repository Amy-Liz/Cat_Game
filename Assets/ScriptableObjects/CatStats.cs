using System;
using UnityEngine;

public class CatStats : ScriptableObject {

    // TODO: Hide values via get/set methods

    // all possible toys
    public enum Toys
    {
        Yarn,
        Mouse,
        Ball,
        Bell,
        Feather
    };

    public string identifier; //name
    public Toys favToy;

    // always start unoccupied
    public bool isOccupied = false;
    // initially no noise
    public bool loudNoise = false;
    public bool hasToy = false;
    public bool hasTreat = false;

    public CatStats(string identifier, string favToy)
    {
        this.identifier = identifier;
        this.favToy = (Toys) Enum.Parse(typeof(Toys),favToy);
    }
}


