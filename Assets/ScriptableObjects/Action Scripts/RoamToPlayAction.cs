using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/RoamToPlay")]
public class RoamToPlayAction : Action {

    public override void Act(StateController controller)
    {

        if (controller.targetSeen)
        {
            AskToPlay(controller);
        }
        else
        {
            Roam(controller);
        }
    }

    private void Roam(StateController controller)
    {
        controller.navMeshAgent.destination = controller.wayPointList[controller.nextWayPoint].position;

        if (controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance && !controller.navMeshAgent.pathPending)
        {
            controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.wayPointList.Count;
        }
    }

    private void AskToPlay(StateController controller)
    {

        GameObject agent = GameObject.Find("Timid");

        StateController agentController = agent.GetComponent<StateController>();

        agentController.StopNavMeshAgent();

        // ask
        controller.canvases[0].enabled = true;

        if (agentController.catStats.GetWillPlayStatus())
        {
            // yes
            agentController.canvases[0].enabled = true;
        }
        else
        {
            // no
            agentController.canvases[1].enabled = true;
        }

        controller.catStats.hasResponse = true;
    }
}
