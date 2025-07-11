namespace Technocite
{


    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class DiapoMono_ChangeScene : MonoBehaviour
    {
        // Tableau des indices des scènes à ignorer
        [Tooltip("Liste des indices des scènes à ignorer")]
        public int[] scenesToIgnore = new int[] { 0 };

        // Fonction pour vérifier si la scène doit être ignorée
        private bool IsSceneIgnored(int sceneIndex)
        {
            foreach (int ignoredScene in scenesToIgnore)
            {
                if (sceneIndex == ignoredScene)
                {
                    return true; // Si la scène est dans le tableau à ignorer, retourner true
                }
            }
            return false; // Sinon, la scène n'est pas ignorée
        }

        [ContextMenu("Next Scene")]
        public void NextScene()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = currentSceneIndex + 1;

            // Chercher la prochaine scène qui n'est pas dans le tableau des scènes à ignorer
            while (IsSceneIgnored(nextSceneIndex) && nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                nextSceneIndex++;
            }

            // Si on est arrivé à la dernière scène, on recommence depuis la première scène
            if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
            {
                nextSceneIndex = 0;
                while (IsSceneIgnored(nextSceneIndex) && nextSceneIndex < SceneManager.sceneCountInBuildSettings)
                {
                    nextSceneIndex++;
                }
            }

            // Si on trouve une scène valide, on la charge
            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(nextSceneIndex);
                Debug.Log("Next Scene: " + SceneManager.GetSceneByBuildIndex(nextSceneIndex).name);
            }
            else
            {
                Debug.Log("Aucune scène suivante valide trouvée.");
            }
        }

        [ContextMenu("Previous Scene")]
        public void PreviousScene()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int previousSceneIndex = currentSceneIndex - 1;

            // Chercher la scène précédente qui n'est pas dans le tableau des scènes à ignorer
            while (IsSceneIgnored(previousSceneIndex) && previousSceneIndex >= 0)
            {
                previousSceneIndex--;
            }

            // Si on est arrivé à la première scène, on recommence depuis la dernière scène
            if (previousSceneIndex < 0)
            {
                previousSceneIndex = SceneManager.sceneCountInBuildSettings - 1;
                while (IsSceneIgnored(previousSceneIndex) && previousSceneIndex >= 0)
                {
                    previousSceneIndex--;
                }
            }

            // Si on trouve une scène valide, on la charge
            if (previousSceneIndex >= 0)
            {
                SceneManager.LoadScene(previousSceneIndex);
                Debug.Log("Previous Scene: " + SceneManager.GetSceneByBuildIndex(previousSceneIndex).name);
            }
            else
            {
                Debug.Log("Aucune scène précédente valide trouvée.");
            }
        }
    }



}