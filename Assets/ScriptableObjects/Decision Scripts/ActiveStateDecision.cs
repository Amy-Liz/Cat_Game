using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/ActiveState")]
public class ActiveStateDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        //did target want to play
        // follow until response?

        CatStats[] cats = FindObjectsOfType<CatStats>();
        bool playDecision = false;

        for(int i = 0; i < cats.Length; i++)
        {
            if(cats[i].identifier == controller.persueTarget.gameObject.tag)
            {
                playDecision = cats[i].GetWillPlayStatus();
            }
        }

        return playDecision;
    }
}
