using System;
using UnityEngine;

public class DiapoMono_MoveAtTransformByOnName : MonoBehaviour
{
    public string m_nameToLookAround = "XR Start Point";
    public Transform m_whatToMove;
    public bool m_useAtAwake = true;


    private void Reset()
    {
        m_whatToMove = transform;
    }

    private void Awake()
    {
        if (m_useAtAwake)
            MoveAtTarget();
    }

    private void MoveAtTarget()
    {
        // Look around for the object by name
        GameObject targetObject = GameObject.Find(m_nameToLookAround);

        if (targetObject != null)
        {
            m_whatToMove.position = targetObject.transform.position;
            m_whatToMove.rotation =targetObject. transform.rotation ;
        }
        else
        {
            m_whatToMove.position = Vector3.zero;
            m_whatToMove.rotation = Quaternion.identity ;

        }
    }
}
