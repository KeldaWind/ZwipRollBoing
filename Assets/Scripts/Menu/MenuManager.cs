using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager menuManager;

    bool loading;

    private void Awake()
    {
        menuManager = this;
    }

    public void LoadScene(string levelToLaunch)
    {
        if (loading)
            return;

        loading = true;
        SceneManager.LoadScene(levelToLaunch);
    }
}
