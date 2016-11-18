using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public class CharacterMovement
    {
        Transform m_transform; // movement target transform
        Rigidbody m_rigidbody;
        float m_speed;
        float m_forceMul;
        float m_desiredAngle;

        public CharacterMovement( Transform trans, Rigidbody rb, float forceMul )
        {
            m_transform = trans;
            m_rigidbody = rb;
            m_forceMul = forceMul;
        }

        public void Tick( float dt )
        {
            m_rigidbody.AddForce( m_speed * m_forceMul * m_transform.forward * dt );

        }

        public void SetDirection( Vector3 dir )
        {
            dir.Normalize();
            float desiredAngle = Quaternion.FromToRotation( Vector3.forward, dir ).eulerAngles.y;
            float currentAngle = Quaternion.FromToRotation( Vector3.forward, m_transform.forward ).eulerAngles.y;


            if ( desiredAngle - currentAngle >= 180.0f )
            {
                desiredAngle -= 360.0f;
            }
            else if ( desiredAngle - currentAngle <= -180.0f )
            {
                desiredAngle += 360.0f;
            }

            float angle = Mathf.Lerp( currentAngle, desiredAngle, 0.4f );

            m_rigidbody.MoveRotation( Quaternion.AngleAxis( angle, Vector3.up ) );
        }

        public void SetSpeed( float val )
        {
            m_speed = val;
        }
    }

    CharacterMovement m_movement;
    Rigidbody m_rb;

    // Use this for initialization
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();

        m_movement = new CharacterMovement( transform, m_rb, 3000 );
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxisRaw( "Vertical" );
        float horizontal = Input.GetAxisRaw( "Horizontal" );

        Vector3 dir = new Vector3( horizontal, 0, vertical );
        dir.Normalize();

        if ( dir.sqrMagnitude > 0 )
            m_movement.SetDirection( dir );

        float speed = Mathf.Abs( vertical ) + Mathf.Abs( horizontal );
        speed = Mathf.Clamp01( speed );

        m_movement.SetSpeed( speed );
        m_movement.Tick( Time.deltaTime );
    }
}
