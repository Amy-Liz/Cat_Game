using System;
using UnityEngine;

public class CatStats : ScriptableObject
{
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

    private bool isDistressed = false;
    private bool hasToy = false;
    private Toys currentToy;
    private bool hasFavToy = false;
    private bool hasTreat = false;
    private bool isPet = false;
    private bool inMoodToPlay = false;
    public bool hasResponse = false;
    public bool askedToPlay = false;

    public CatStats(string identifier, string favToy)
    {
        this.identifier = identifier;
        this.favToy = (Toys)Enum.Parse(typeof(Toys), favToy.ToLower());
    }

    public void CheckToy()
    {
        if (hasToy)
        {
            if (currentToy == favToy)
            {
                hasFavToy = true;
            }
            else
            {
                hasFavToy = false;
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
        if (hasToy && currentToy != favToy)
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

        if (askedToPlay)
        {
            askedToPlay = false;
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

        if (askedToPlay)
        {
            askedToPlay = false;
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

        if (askedToPlay)
        {
            askedToPlay = false;
        }
    }

    public void SetIsDistressed(bool value)
    {
        isDistressed = value;
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
        return inMoodToPlay;
    }

    public bool GetIsPetStatus()
    {
        return isPet;
    }

    public void SetWillPlayStatus(bool value)
    {
        inMoodToPlay = value;
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

        if (hasResponse)
        {
            hasResponse = false;
        }

        if (askedToPlay)
        {
            askedToPlay = false;
        }

        if (isPet)
        {
            isPet = false;
        }
    }

    public bool RespondToPlayRequest()
    {
        return inMoodToPlay;
    }
}


