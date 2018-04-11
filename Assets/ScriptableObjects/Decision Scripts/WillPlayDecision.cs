using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/WillPlay")]
public class WillPlayDecision : Decision {

    public override bool Decide(StateController controller)
    {
        CatStats[] cats = FindObjectsOfType<CatStats>();
        bool playDecision = false;

        for (int i = 0; i < cats.Length; i++)
        {
            Debug.Log(cats[i].identifier);

            if (cats[i].identifier == controller.persueTarget.gameObject.tag)
            {
                playDecision = cats[i].GetWillPlayStatus();
            }
        }

        return playDecision;
    }
}
