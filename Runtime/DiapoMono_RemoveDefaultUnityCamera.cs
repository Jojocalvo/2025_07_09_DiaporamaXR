using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DiapoMono_RemoveDefaultUnityCamera : MonoBehaviour
{

    public string[] m_ignoreThoseCamera = new string[] {
        "RightEyeAnchor", "CenterEyeAnchor", "LeftEyeAnchor"
    };

    [ContextMenu("Remove Camera")]
    public void RemoveDefaultUnityCamera()
    {
        // Find all cameras in the scene
        Camera[] cameras = Camera.allCameras;

        bool cameraDestroyed = false;  

        foreach (Camera camera in cameras)
        {
            // Ignore cameras that match the specified names
            if (System.Array.Exists(m_ignoreThoseCamera, name => name == camera.name))
                continue;

            // Destroy the camera's game object
            if (Application.isPlaying)
                Destroy(camera.gameObject);
            else
                DestroyImmediate(camera.gameObject);

            cameraDestroyed = true;  // Set flag to true if a camera was destroyed
        }

        // If no camera was destroyed
        if (!cameraDestroyed)
        {
            Debug.Log("No camera named 'Main Camera' found in the scene, or all cameras are ignored.");
        }
    }
}
