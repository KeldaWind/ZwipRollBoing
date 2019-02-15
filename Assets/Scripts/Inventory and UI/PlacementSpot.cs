using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementSpot : MonoBehaviour
{
    [SerializeField] Transform placementPosition;
    bool occupied;
    public void SetOccupied(bool occ)
    {
        occupied = occ;
    }

    public bool Clear
    {
        get
        {
            return !occupied;
        }
    }

    public void PlaceNewObject(LevelObject newObjectPrefab)
    {
        
    }
}
