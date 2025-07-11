using System;
using UnityEngine;

public class DiapoMono_DiapoInScenePusher : MonoBehaviour
{
    public static Action m_next;
    public static Action m_previous;

    [ContextMenu("Next")]
    public void NextDiapo() { m_next?.Invoke(); }

    [ContextMenu("Previous")]
    public void PreviousDiapo() { m_previous?.Invoke(); }
}
