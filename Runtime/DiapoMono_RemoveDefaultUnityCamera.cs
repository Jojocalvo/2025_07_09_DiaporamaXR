using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class DiapoMono_RemoveDefaultUnityCamera : MonoBehaviour
{
 
    [ContextMenu("Remove Camera")]
    public void RemoveDefaultUnityCamera()
    {
        // Find all cameras in the scene
        Camera[] cameras = Camera.allCameras;

        foreach (Camera camera in cameras)
        {
            // Check if the camera's name is "Main Camera"
            if (camera.gameObject.name == "Main Camera")
            {
                // Destroy the camera's game object
                if (Application.isPlaying) 
                    Destroy(camera.gameObject);
                 else  
                        DestroyImmediate(camera.gameObject);

                return; // Exit after destroying the camera
            }
        }

        // If no camera named "Main Camera" is found
        Debug.Log("No camera named 'Main Camera' found in the scene.");
    }
}
