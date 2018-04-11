using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Look")]
public class LookAction : Action {

	public override void Act(StateController controller)
    {
        Look(controller);
    }

    private void Look(StateController controller)
    {
        RaycastHit hit;
        float radius = 5f;
        float range = 50f;

        // so we can see in debug
        Debug.DrawRay(controller.eyes.position, controller.eyes.forward.normalized * range, Color.green);

        if (Physics.SphereCast(controller.eyes.position, radius, controller.eyes.forward, out hit, range) && (hit.collider.CompareTag("Agent")))
        {
            //found target
            Debug.Log("Target seen");
            controller.targetSeen = true;
        }
    }
}
