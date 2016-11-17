using UnityEngine;

public class InteractableButton : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
            EventManager.StartListening(EventType.ActionButtonPressed, PressButton);
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
            EventManager.StopListening(EventType.ActionButtonPressed, PressButton);
    }

    void PressButton()
    {
        if (IWasDestroyed)
            return;

        Debug.Log("Pressed button");
    }

    bool IWasDestroyed
    {
        get
        {
            if (this == null)
                EventManager.StopListening(EventType.ActionButtonPressed, PressButton);
            return this == null;
        }
    }
}
