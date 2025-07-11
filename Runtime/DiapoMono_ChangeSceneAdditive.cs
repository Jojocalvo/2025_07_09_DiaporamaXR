namespace Technocite
{


    using UnityEngine;
    using UnityEngine.SceneManagement;
    using System.Collections;
    public class DiapoMono_ChangeSceneAdditive : MonoBehaviour
    {
        [Tooltip("Liste des indices des scènes à ignorer")]
        public int[] scenesToIgnore = new int[] { 0 };

        private Scene activeScene;

        private void Start()
        {
            activeScene = SceneManager.GetActiveScene();
        }

        private bool IsSceneIgnored(int sceneIndex)
        {
            foreach (int ignoredScene in scenesToIgnore)
            {
                if (sceneIndex == ignoredScene)
                    return true;
            }
            return false;
        }

        [ContextMenu("Next Scene")]
        public void NextScene()
        {
            StartCoroutine(SwitchScene(true));
        }

        [ContextMenu("Previous Scene")]
        public void PreviousScene()
        {
            StartCoroutine(SwitchScene(false));
        }

        private IEnumerator SwitchScene(bool forward)
        {
            int currentSceneIndex = activeScene.buildIndex;
            int targetSceneIndex = forward ? GetNextValidSceneIndex(currentSceneIndex) : GetPreviousValidSceneIndex(currentSceneIndex);

            if (targetSceneIndex == -1)
            {
                Debug.LogWarning("No valid scene found.");
                yield break;
            }

           
            // Unload current scene first
            AsyncOperation unloadOp = SceneManager.UnloadSceneAsync(activeScene);
            if (unloadOp != null) { 
                while (!unloadOp.isDone)
                {
                    yield return null;
                }
            }

            // Then load new scene additively
            AsyncOperation loadOp = SceneManager.LoadSceneAsync(targetSceneIndex, LoadSceneMode.Additive);
            while (!loadOp.isDone)
            {
                yield return null;
            }

            // Set the new scene as active
            Scene newScene = SceneManager.GetSceneByBuildIndex(targetSceneIndex);
            if (newScene.IsValid())
            {
                SceneManager.SetActiveScene(newScene);
                activeScene = newScene;
                Debug.Log("Switched to scene: " + newScene.name);
            }
        }

        private int GetNextValidSceneIndex(int currentIndex)
        {
            int totalScenes = SceneManager.sceneCountInBuildSettings;
            int nextIndex = currentIndex + 1;

            while (nextIndex < totalScenes && IsSceneIgnored(nextIndex))
                nextIndex++;

            if (nextIndex >= totalScenes)
            {
                nextIndex = 0;
                while (nextIndex < totalScenes && IsSceneIgnored(nextIndex))
                    nextIndex++;
            }

            return nextIndex < totalScenes ? nextIndex : -1;
        }

        private int GetPreviousValidSceneIndex(int currentIndex)
        {
            int previousIndex = currentIndex - 1;

            while (previousIndex >= 0 && IsSceneIgnored(previousIndex))
                previousIndex--;

            if (previousIndex < 0)
            {
                previousIndex = SceneManager.sceneCountInBuildSettings - 1;
                while (previousIndex >= 0 && IsSceneIgnored(previousIndex))
                    previousIndex--;
            }

            return previousIndex >= 0 ? previousIndex : -1;
        }
    }



}