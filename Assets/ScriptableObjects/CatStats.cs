using System;
using UnityEngine;

public class CatStats : ScriptableObject {

    // TODO: Hide values via get/set methods

    // all possible toys
    public enum Toys
    {
        yarn,
        mouse,
        ball,
        bell,
        feather,
        none,
    };

    public string identifier; //name
    public Toys favToy;

    // always start unoccupied
    public bool isOccupied = false;
    // initially no noise
    public bool loudNoise = false;
    public bool hasToy = false;
    public Toys currentToy;
    public bool hasFavToy = false;
    public bool hasTreat = false;
    public bool isPet = false;

    public CatStats(string identifier, string favToy)
    {
        this.identifier = identifier;
        this.favToy = (Toys) Enum.Parse(typeof(Toys), favToy.ToLower());
    }

    public void CheckToy()
    {
        if (hasToy)
        {
            if(currentToy == favToy)
            {
                hasFavToy = true;
            }
        }

        // special case for friendly agent with no fav
        if(hasToy && favToy == Toys.none)
        {
            hasFavToy = true;
        }
    }

    public void GiveToy(string toy)
    {
        currentToy = (Toys)Enum.Parse(typeof(Toys), toy);
    }
}


