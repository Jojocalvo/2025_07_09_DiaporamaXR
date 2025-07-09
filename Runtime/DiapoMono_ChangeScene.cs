using UnityEngine;
using UnityEngine.SceneManagement;

public class DiapoMono_ChangeScene : MonoBehaviour
{
    // Tableau des indices des sc�nes � ignorer
    [Tooltip("Liste des indices des sc�nes � ignorer")]
    public int[] scenesToIgnore = new int[]{0};

    // Fonction pour v�rifier si la sc�ne doit �tre ignor�e
    private bool IsSceneIgnored(int sceneIndex)
    {
        foreach (int ignoredScene in scenesToIgnore)
        {
            if (sceneIndex == ignoredScene)
            {
                return true; // Si la sc�ne est dans le tableau � ignorer, retourner true
            }
        }
        return false; // Sinon, la sc�ne n'est pas ignor�e
    }

    [ContextMenu("Next Scene")]
    public void NextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        // Chercher la prochaine sc�ne qui n'est pas dans le tableau des sc�nes � ignorer
        while (IsSceneIgnored(nextSceneIndex) && nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex++;
        }

        // Si on est arriv� � la derni�re sc�ne, on recommence depuis la premi�re sc�ne
        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
            while (IsSceneIgnored(nextSceneIndex) && nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                nextSceneIndex++;
            }
        }

        // Si on trouve une sc�ne valide, on la charge
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
            Debug.Log("Next Scene: " + SceneManager.GetSceneByBuildIndex(nextSceneIndex).name);
        }
        else
        {
            Debug.Log("Aucune sc�ne suivante valide trouv�e.");
        }
    }

    [ContextMenu("Previous Scene")]
    public void PreviousScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int previousSceneIndex = currentSceneIndex - 1;

        // Chercher la sc�ne pr�c�dente qui n'est pas dans le tableau des sc�nes � ignorer
        while (IsSceneIgnored(previousSceneIndex) && previousSceneIndex >= 0)
        {
            previousSceneIndex--;
        }

        // Si on est arriv� � la premi�re sc�ne, on recommence depuis la derni�re sc�ne
        if (previousSceneIndex < 0)
        {
            previousSceneIndex = SceneManager.sceneCountInBuildSettings - 1;
            while (IsSceneIgnored(previousSceneIndex) && previousSceneIndex >= 0)
            {
                previousSceneIndex--;
            }
        }

        // Si on trouve une sc�ne valide, on la charge
        if (previousSceneIndex >= 0)
        {
            SceneManager.LoadScene(previousSceneIndex);
            Debug.Log("Previous Scene: " + SceneManager.GetSceneByBuildIndex(previousSceneIndex).name);
        }
        else
        {
            Debug.Log("Aucune sc�ne pr�c�dente valide trouv�e.");
        }
    }
}
