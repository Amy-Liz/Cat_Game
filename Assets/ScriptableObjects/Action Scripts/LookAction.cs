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
        int agentLayer = 1 << LayerMask.NameToLayer("Timid Agent");

        Collider[] colliders = Physics.OverlapSphere(controller.gameObject.transform.position, 20f, agentLayer);

        for(int i = 0; i < colliders.Length; i++)
        {
            if(colliders[i].CompareTag("Timid"))
            {
                controller.targetSeen = true;
                controller.target = colliders[i].transform;
            }
        }
    }
}
