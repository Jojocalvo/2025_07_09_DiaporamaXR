using UnityEngine;

public class DiapoMono_CreatePrefabInScene : MonoBehaviour
{

    public GameObject m_prefab;

    public bool m_setItToZero = false;

    [ContextMenu("Create Prefab")]
    public void CreatePrefab()
    {

        GameObject prefab = GameObject.Instantiate(m_prefab);
        if (m_setItToZero)
        {
            prefab.transform.position = Vector3.zero;
            prefab.transform.rotation = Quaternion.identity;

        }
    }
}
