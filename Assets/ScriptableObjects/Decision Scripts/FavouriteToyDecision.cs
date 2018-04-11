using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decision/FavToy")]
public class FavouriteToyDecision : Decision
{
    public override bool? Decide(StateController controller)
    {
        return CheckFavToyStatus(controller);
    }

    private bool CheckFavToyStatus(StateController controller)
    {
        controller.catStats.CheckToy();

        return controller.catStats.GetFavToyStatus();
    }
}
