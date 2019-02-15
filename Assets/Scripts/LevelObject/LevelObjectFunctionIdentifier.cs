using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObjectFunctionIdentifier : MonoBehaviour
{
    [SerializeField] LevelObjectFunction function;
    public LevelObjectFunction GetFunction()
    {
        return function;
    }
}
