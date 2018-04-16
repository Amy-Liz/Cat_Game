using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decision/AskedToPlay")]
public class AskedToPlayDecision : Decision {

    public override bool? Decide(StateController controller)
    {
        return controller.catStats.askedToPlay;
    }
}
