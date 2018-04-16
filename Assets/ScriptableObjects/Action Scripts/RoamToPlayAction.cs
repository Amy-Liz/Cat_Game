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

        bool agentWillPlay = agentController.catStats.GetWillPlayStatus();

        if (agentWillPlay)
        {
            // yes
            agentController.canvases[0].enabled = true;
            agentController.canvases[1].enabled = false;
        }
        else if (!agentWillPlay)
        {
            // no
            agentController.canvases[1].enabled = true;
            agentController.canvases[0].enabled = false;
        }

        Debug.Log("Agent response to play request:" + agentWillPlay);

        agentController.navMeshAgent.isStopped = false;
        controller.navMeshAgent.isStopped = false;

        agentController.catStats.askedToPlay = true;
        controller.catStats.hasResponse = true;
    }
}
