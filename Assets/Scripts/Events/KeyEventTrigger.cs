using UnityEngine;

public class KeyEventTrigger : MonoBehaviour
{
    public EventType eventType;
    public KeyCode keyCode = KeyCode.C;

	void Update ()
    {
        if (Input.GetKeyDown(keyCode))
            EventManager.TriggerEvent(eventType);
        if (Input.GetMouseButtonDown(0))
            EventManager.TriggerEvent(EventType.ShootProjectile);
	}
}
