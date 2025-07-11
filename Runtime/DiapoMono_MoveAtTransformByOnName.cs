using System;
using UnityEngine;

public class DiapoMono_MoveAtTransformByOnName : MonoBehaviour
{
    public string m_nameToLookAround = "XR Start Point";
    public Transform m_whatToMove;
    public bool m_useAtOnEnable = true;


    private void Reset()
    {
        m_whatToMove = transform;
    }

    private void OnEnable()
    {
        if (m_useAtOnEnable)
            MoveAtTarget();
    }

    [ContextMenu("Move At Target")]
    public void MoveAtTarget()
    {
        // Look around for the object by name
        GameObject targetObject = GameObject.Find(m_nameToLookAround);

        if (targetObject != null)
        {
            m_whatToMove.position = targetObject.transform.position;
            m_whatToMove.rotation =targetObject. transform.rotation ;
            Debug.Log("On a target");
        }
        else
        {
            m_whatToMove.position = Vector3.zero;
            m_whatToMove.rotation = Quaternion.identity;
            Debug.Log("ça a pas target");
        }
    }
}
