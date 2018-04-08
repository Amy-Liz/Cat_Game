using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decision/Toy")]
public class ToyDecision : Decision {

    public override bool Decide(StateController controller)
    {
        return CheckToyStatus(controller);
    }   

    private bool CheckToyStatus(StateController controller)
    {
        controller.catStats.CheckToy();

        return controller.catStats.GetToyStatus();
    }
}
