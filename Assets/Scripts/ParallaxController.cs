using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour {
    [HideInInspector]
    public float parallaxAmount;
    [Range(0,500)]
    public float parallaxValue = 500f;
    public Transform target;
    public float damping = 1;
    public float lookAheadFactor = 3;
    public float lookAheadReturnSpeed = 0.5f;
    public float lookAheadMoveThreshold = 0.1f;
    public float offsetX, offsetY;
    private float m_OffsetZ;
    private Vector3 m_LastTargetPosition;
    private Vector3 m_CurrentVelocity;
    private Vector3 m_LookAheadPos;
    bool startLerp = false;

    // Use this for initialization
    private void Start()
    {
        m_LastTargetPosition = target.position;
        m_OffsetZ = (transform.position - target.position).z;
        transform.parent = null;
    }


    // Update is called once per frame
    private void Update()
    {
        // only update lookahead pos if accelerating or changed direction
        float xMoveDelta = (target.position - m_LastTargetPosition).x;

        bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

        if (updateLookAheadTarget)
        {
            m_LookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta);
        }
        else
        {
            m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);
        }

        Vector3 aheadTargetPos = target.position + m_LookAheadPos + Vector3.forward * m_OffsetZ;
        Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_CurrentVelocity, damping);

        if( m_CurrentVelocity.x  > 0)
        {
            parallaxAmount = parallaxValue / 1000 * m_CurrentVelocity.x;
        }
        transform.position = newPos + new Vector3(offsetX, offsetY, 0);

        m_LastTargetPosition = target.position;

        if(startLerp)
        {
            offsetX = Mathf.Lerp(offsetX, 0, 0.1f);
            offsetY = Mathf.Lerp(offsetY, 0, 0.1f);
            if(Mathf.Round(offsetX) == 0 && Mathf.Round(offsetY) == 0)
            {
                startLerp = false;
            }
        }
    }

    void StartLerp()
    {
        startLerp = true;
    }
}
