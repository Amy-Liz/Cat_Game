using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Shake")]
public class ShakeAction : Action {

    public override void Act(StateController controller)
    {
        Vector3 startingPos = controller.gameObject.transform.position;
        int shakeMod = 1;

        controller.gameObject.transform.position = startingPos * 10;
        controller.gameObject.transform.position = startingPos / 10;

    }
}
