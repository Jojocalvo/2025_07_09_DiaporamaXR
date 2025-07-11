using UnityEngine;

public class DiapoMono_CreatePrefabAfterDeletePreviousInScene : MonoBehaviour
{

    public GameObject m_prefab;
    public bool m_setItToZero = false;
    public GameObject m_created;

    [ContextMenu("Create Prefab")]
    public void CreatePrefab()
    {
        if (m_created != null) { 
            if (Application.isPlaying) 
            GameObject.Destroy(m_created);
            else GameObject.DestroyImmediate(m_created);
        }

        GameObject prefab = GameObject.Instantiate(m_prefab);
        if (m_setItToZero)
        {
            prefab.transform.position = Vector3.zero;
            prefab.transform.rotation = Quaternion.identity;

        }
    }
}
