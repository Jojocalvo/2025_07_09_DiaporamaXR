using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DiapoMono_ParseNameAndIdToSceneId : MonoBehaviour
{
    public UnityEvent<int> m_onSceneIdChanged;
    public GroupOfNameAndIntegerIndexToSceneIndex m_idsToSceneId;


    [ContextMenu("Reset with class room 24")]
    public void ResetWithClassRoom24()
    {
        m_idsToSceneId.m_scenes.Clear(); // Clear any existing data

        // Loop through for 24 students
        for (int i = 1; i <= 24; i++)
        {
            NameAndIntegerIndexToSceneIndex student = new NameAndIntegerIndexToSceneIndex();

            // Set the scene title
            student.m_sceneTitle = $"Title. Eleve {i}";

            // Assign SceneID starting from 2 and incrementing by 1
            student.m_sceneId = 1 + i;

            // Generate the Name ID (e.g., LASTNAME_FIRSTNAME_1, LASTNAME_FIRSTNAME_2, ...)
            student.m_nameId = new string[] { $"LASTNAME_FIRSTNAME_{i}" };

            // Assign Integer ID (8001, 8002, ..., 8024)
            student.m_integerId = new int[] { 8000 + i };

            // Add student to the m_scenes list
            m_idsToSceneId.m_scenes.Add(student);
        }

    }

    public void TryToLoadSceneFromId(string idToFound) {

        GetSceneId(idToFound, out int id);
        if(id>-1)
            m_onSceneIdChanged?.Invoke(id);
    }

    public void GetSceneId(string idToFound, out int sceneId)
    {
        sceneId = -1; // Default value if no sceneId is found

        // Iterate through each scene group in the list
        foreach (var scene in m_idsToSceneId.m_scenes)
        {
            // Check if the idToFound matches any nameId in the scene
            for (int i = 0; i < scene.m_nameId.Length; i++)
            {
                if (scene.m_nameId[i] == idToFound)
                {
                    sceneId = scene.m_sceneId;
                    return;
                }
            }

            // Check if the idToFound matches any integerId in the scene
            for (int i = 0; i < scene.m_integerId.Length; i++)
            {
                if (scene.m_integerId[i].ToString() == idToFound)
                {
                    sceneId = scene.m_sceneId;
                    return;
                }
            }
        }
    }
}

[System.Serializable]
public class GroupOfNameAndIntegerIndexToSceneIndex
{
    public List<NameAndIntegerIndexToSceneIndex> m_scenes = new List<NameAndIntegerIndexToSceneIndex>();
}

[System.Serializable]
public class NameAndIntegerIndexToSceneIndex
{
    public string m_sceneTitle;
    public int m_sceneId;
    public string[] m_nameId;
    public int[] m_integerId;
}
