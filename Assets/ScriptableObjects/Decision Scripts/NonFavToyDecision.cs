using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decision/NonFavToy")]
public class NonFavToyDecision : Decision {

    public override bool? Decide(StateController controller)
    {
        return controller.catStats.CheckNonFavToy();
    }
}
