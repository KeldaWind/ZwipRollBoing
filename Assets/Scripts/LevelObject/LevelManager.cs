using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelManager;
    public int stockOfCylinders;
    public int stockOfPyramids;
    public int stockOfCones;
    public string nextLevelName;

    private void Awake()
    {
        levelManager = this;
    }

    [SerializeField] List<LevelObject> levelObjects;

    public void AddNewObject(LevelObject newObj)
    {
        levelObjects.Add(newObj);
    }

    public void RemoveObject(LevelObject objToRemove)
    {
        levelObjects.Remove(objToRemove);
    }

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
