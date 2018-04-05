using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decision/Treat")]
public class TreatDecision : Decision {

    public override bool Decide(StateController controller)
    {
        return CheckTreatStatus(controller);
    }

    private bool CheckTreatStatus(StateController controller)
    {
        return controller.catStats.hasTreat;
    }
}
