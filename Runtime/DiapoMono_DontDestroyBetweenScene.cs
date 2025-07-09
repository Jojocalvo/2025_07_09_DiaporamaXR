using UnityEngine;

public class DiapoMono_DontDestroyBetweenScene : MonoBehaviour
{
    // Static reference to ensure only one instance of the object exists
    private static DiapoMono_DontDestroyBetweenScene instance;

    void Awake()
    {
        // If there is no instance of this object yet, make this one the instance and don't destroy it
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Ensure the object persists between scenes
        }
        else
        {
            // If an instance already exists, destroy this duplicate object
            Destroy(gameObject);
        }
    }
}
