using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene(1);
    }
}