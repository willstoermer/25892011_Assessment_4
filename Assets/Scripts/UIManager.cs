using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class UIManager : MonoBehaviour
{
    public void LoadFirstLevel()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void LoadMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
