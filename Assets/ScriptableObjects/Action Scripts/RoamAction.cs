using System;
using UnityEngine;


[CreateAssetMenu(menuName = "PluggableAI/Actions/Roam")]
public class RoamAction : Action
{
    public override void Act(StateController controller)
    {
            Roam(controller);
    }

    private void Roam(StateController controller)
    {
        if(controller.targetSeen)
        {
            // stop
            controller.navMeshAgent.isStopped = true;
            // ask to play
        }
        else
        {
            controller.navMeshAgent.destination = controller.wayPointList[controller.nextWayPoint].position;
            controller.navMeshAgent.isStopped = false;

            if (controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance && !controller.navMeshAgent.pathPending)
            {
                controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.wayPointList.Count;
            }
        }
    }
}
