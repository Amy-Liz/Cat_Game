using UnityEngine;


// not abstract as creating assets from this
[CreateAssetMenu(menuName = "PluggableAI/State")]
public class State : ScriptableObject
{

    public Action[] actions;
    public Transition[] transitions;
    public Color sceneGizmoColour = Color.gray;
    public string stateName;

    public void UpdateState(StateController controller)
    {
        DoActions(controller);
        CheckTransitions(controller);
    }

    private void DoActions(StateController controller)
    {

        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].Act(controller);
        }
    }

    // iterates over transitions, if decision true then transition
    private void CheckTransitions(StateController stateController)
    {
        for (int i = 0; i < transitions.Length; i++)
        {
            // true if transition, false if not
            bool decisionSucceeded = transitions[i].decision.Decide(stateController);

            if (decisionSucceeded)
            {
                stateController.TransitionToState(transitions[i].trueState);
            }
           else
            {
                stateController.TransitionToState(transitions[i].falseState);
            }
        }
    }
}
