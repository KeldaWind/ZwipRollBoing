using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelManager;

    private void Awake()
    {
        levelManager = this;
    }

    [SerializeField] LevelObject[] levelObjects;

    public void CheckAllObjectsFunction()
    {
        foreach(LevelObject obj in levelObjects)
        {
            obj.CheckColliders();
            obj.SetResolMat();
        }
    }

    public void ResetAllObjects()
    {
        foreach (LevelObject obj in levelObjects)
        {
            obj.SetPrepaMat();
        }
    }
}
