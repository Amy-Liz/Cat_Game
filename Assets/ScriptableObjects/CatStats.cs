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

    //TODO: Properties

    public string identifier; //name
    public Toys favToy;

    // always start unoccupied
    private bool isOccupied = false;
    // initially no noise
    private bool isDistressed = false;
    private bool hasToy = false;
    private Toys currentToy;
    private bool hasFavToy = false;
    private bool hasTreat = false;
    private bool isPet = false;
    private bool willPlay = true;

    public CatStats(string identifier, string favToy)
    {
        this.identifier = identifier;
        this.favToy = (Toys) Enum.Parse(typeof(Toys), favToy.ToLower());
    }

    public void CheckToy()
    {
        if (hasToy)
        {
            if (currentToy == favToy)
            {
                hasFavToy = true;
            }
        }

        // special case for friendly agent with no fav
        if (hasToy && favToy == Toys.none)
        {
            hasFavToy = true;
        }
    }

    public bool CheckNonFavToy()
    {
        if(hasToy && currentToy != favToy)
        {
            return true;
        }

        return false;
    }

    public void GiveToy(string toy)
    {
        hasToy = true;
        currentToy = (Toys)Enum.Parse(typeof(Toys), toy.ToLower());

        if (isPet)
        {
            isPet = false;
        }

        if (hasTreat)
        {
            hasTreat = false;
        }

        // quick fix for friendly agent, will change in future
        if (favToy.ToString().ToLower() == "none")
        {
            isDistressed = false;
        }
    }

    public void GiveTreat()
    {
        hasTreat = true;

        if (hasToy)
        {
            hasToy = false;
            hasFavToy = false;
        }

        if (isPet)
        {
            isPet = false;
        }
    }

    public void PetCat()
    {
        isPet = true;
        hasTreat = false;

        if (hasToy)
        {
            hasToy = false;
            hasFavToy = false;
        }
    }

    public void UpdateDistress()
    {
        isDistressed = !isDistressed;
    }

    public bool GetTreatStatus()
    {
        return hasTreat;
    }

    public bool GetToyStatus()
    {
        return hasToy;
    }

    public bool GetFavToyStatus()
    {
        return hasFavToy;
    }

    public bool GetDistressStatus()
    {
        return isDistressed;
    }

    public bool GetWillPlayStatus()
    {
        return willPlay;
    }

    public void SetWillPlayStatus(bool value)
    {
        willPlay = value;
    }

    public void OnLoudNoise()
    {
        isDistressed = true;

        if (hasToy)
        {
            hasToy = false;
        }

        if (hasFavToy)
        {
            hasFavToy = false;
        }

        if (hasTreat)
        {
            hasTreat = false;
        }
    }
}


