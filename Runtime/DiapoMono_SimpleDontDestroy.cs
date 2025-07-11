using UnityEngine;

public class DiapoMono_SimpleDontDestroy : MonoBehaviour
{
    public void Awake()
    {
         DontDestroyOnLoad(gameObject);
    }
}
