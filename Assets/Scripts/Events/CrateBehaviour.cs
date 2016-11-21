using UnityEngine;
using System.Collections;

public class CrateBehaviour : MonoBehaviour
{
    private GameObject player;
    private bool joined = false;
    private bool canJoin = false;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        EventManager.StartListening(EventType.JoinCrateEvent, JoinToPlayer);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            canJoin = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("Listening stop");
            canJoin = false;
        }
    }

    void JoinToPlayer()
    {
        if (joined)
        {
            Destroy(gameObject.GetComponent<FixedJoint>());
            joined = false;
            canJoin = true;
        }
        else if (canJoin)
        {
            gameObject.AddComponent<FixedJoint>().connectedBody = player.GetComponent<Rigidbody>();
            joined = true;
        }

    }
}
