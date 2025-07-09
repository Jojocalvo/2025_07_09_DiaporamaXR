using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class DiapoMono_OnSceneLoadedAction : MonoBehaviour
{

    public UnityEvent m_onSceneLoaded;
    public int m_lastSceneLoadedIndex;
    public string m_lastSceneLoadedName;

    // This method is called when the scene is loaded
    private void OnEnable()
    {
        // Subscribe to the scene loaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // This method is triggered by the sceneLoaded event
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Invoke the UnityEvent when the scene is loaded
        m_onSceneLoaded?.Invoke();
        m_lastSceneLoadedIndex = scene.buildIndex;
        m_lastSceneLoadedName = scene.name;
    }

    // This method is called when the object is disabled
    private void OnDisable()
    {
        // Unsubscribe from the scene loaded event to avoid memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
