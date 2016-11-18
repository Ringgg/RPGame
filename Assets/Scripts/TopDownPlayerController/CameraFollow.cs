using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    [SerializeField]
    Transform m_target;

    Vector3 m_offset;

	// Use this for initialization
	void Start () {
        m_offset =  transform.position - m_target.position;
	}
	
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp( transform.position, m_target.position + m_offset, 0.3f );
    }

    // Update is called once per frame
    void Update () {
	}
}
