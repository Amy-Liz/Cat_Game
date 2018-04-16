using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/WillPlay")]
public class WillPlayDecision : Decision {

    public override bool? Decide(StateController controller)
    {
        bool? playDecision = null;

        if (controller.catStats.hasResponse)
        {
            CatStats[] cats = FindObjectsOfType<CatStats>();
            for (int i = 0; i < cats.Length; i++)
            {
                if (cats[i].identifier == controller.target.gameObject.tag)
                {
                    playDecision = cats[i].GetWillPlayStatus();
                }
            }
        }

        return playDecision;
    }
}
