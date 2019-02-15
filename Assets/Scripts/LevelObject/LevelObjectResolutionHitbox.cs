using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObjectResolutionHitbox : MonoBehaviour
{
    [SerializeField] LevelObjectFunction function;

    public LevelObjectFunction GetObjectFunction()
    {
        return function;
    }
}
