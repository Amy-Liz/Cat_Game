using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyDecision : Decision {

    public override bool Decide(StateController controller)
    {
        return CheckToyStatus(controller);
    }   

    private bool CheckToyStatus(StateController controller)
    {

        controller.catStats.CheckToy();

        if (controller.catStats.hasFavToy)
        {
            return true;
        }

        // not fav
        return false;
    }
}
