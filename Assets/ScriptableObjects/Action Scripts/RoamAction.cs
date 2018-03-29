using System;
using UnityEngine;


[CreateAssetMenu(menuName = "PluggableAI/Actions/Roam")]
public class RoamAction : Action
{

    public override void Act(StateController stateController)
    {
        Roam(stateController);
    }

    private void Roam(StateController controller)
    {
        controller.navMeshAgent.destination = controller.wayPointList[controller.nextWayPoint].position;
        controller.navMeshAgent.isStopped = false;

        if (controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance && !controller.navMeshAgent.pathPending)
       {
            controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.wayPointList.Count;
        }
    }
}
