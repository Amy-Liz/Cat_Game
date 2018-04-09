using System;
using UnityEngine;


[CreateAssetMenu(menuName = "PluggableAI/Actions/Roam")]
public class RoamAction : Action
{
    Transform target;

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

        bool spotted = Look(controller);

        if (spotted)
        {
            //persue
        }
    }

    private bool Look(StateController controller)
    {

        RaycastHit hit;
        float radius = 1f;
        float range = 10f;

        // so we can see in debug
        Debug.DrawRay(controller.eyes.position, controller.eyes.forward.normalized * range, Color.green);

        if (Physics.SphereCast(controller.eyes.position, radius, controller.eyes.forward, out hit, range) && ((hit.collider.CompareTag("Timid")) || (hit.collider.CompareTag("Timid"))))
        {
            //found target
            target = hit.transform;
            return true;
        }
        else
        {
            return false;
        }
    }
}
