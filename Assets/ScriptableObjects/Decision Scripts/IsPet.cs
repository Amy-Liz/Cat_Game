using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decision/IsPet")]
public class IsPet : Decision {

    public override bool? Decide(StateController controller)
    {
        return controller.catStats.GetIsPetStatus();
    }
}
