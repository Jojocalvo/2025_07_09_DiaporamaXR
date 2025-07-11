using UnityEngine;

public class DiapoMono_DiapoOfObjectInSceneListener : MonoBehaviour
{
    public GameObject[] m_diaporama;
    public int m_index;

    private void OnEnable()
    {
        DiapoMono_DiapoInScenePusher.m_next += NextDiapo;
        DiapoMono_DiapoInScenePusher.m_previous += PreviousDiapo;
        SelectDiapo(m_index); // Ensure correct initial state
    }

    private void OnDisable()
    {
        DiapoMono_DiapoInScenePusher.m_next -= NextDiapo;
        DiapoMono_DiapoInScenePusher.m_previous -= PreviousDiapo;
    }

    [ContextMenu("Next")]
    public void NextDiapo()
    {
        m_index = (m_index + 1) % m_diaporama.Length;
        SelectDiapo(m_index);
    }

    [ContextMenu("Previous")]
    public void PreviousDiapo()
    {
        m_index = (m_index - 1 + m_diaporama.Length) % m_diaporama.Length;
        SelectDiapo(m_index);
    }

    public void SelectDiapo(int index)
    {
        for (int i = 0; i < m_diaporama.Length; i++)
        {
            if (m_diaporama[i] != null)
                m_diaporama[i].SetActive(i == index);
        }
    }
}
