using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decision/Loud Nouse")]
public class LoudNoiseDecision : Decision {

    public override bool? Decide(StateController controller)
    {
        return controller.catStats.GetDistressStatus();
    }
}
 