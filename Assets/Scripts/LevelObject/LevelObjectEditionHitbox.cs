using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObjectEditionHitbox : MonoBehaviour
{
    [SerializeField] LevelObject relatedObject;
    public LevelObject GetRelativeObject()
    {
        return relatedObject;
    }
}
