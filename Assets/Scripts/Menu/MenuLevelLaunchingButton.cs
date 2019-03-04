using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLevelLaunchingButton : MonoBehaviour
{
    [SerializeField] string levelSceneName;

    public void LaunchLevel()
    {
        MenuManager.menuManager.LoadScene(levelSceneName);
    }
}
