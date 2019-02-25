using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class InventoryManager
{
    [Header("Level Objects")]
    [SerializeField] LevelObject cylinderPrefab;
    [SerializeField] LevelObject pyramidPrefab;
    [SerializeField] LevelObject conePrefab;

    int remainingNumberOfCylinder;
    int remainingNumberOfPyramid;
    int remainingNumberOfCone;

    [Header("UI")]
    [SerializeField] Transform dragAndDropObjectsParent;

    [SerializeField] ObjectUIDragAndDrop dndCylinderPrefab;
    [SerializeField] Text cylinderNumberText;

    [SerializeField] ObjectUIDragAndDrop dndPyramidPrefab;
    [SerializeField] Text pyramidNumberText;

    [SerializeField] ObjectUIDragAndDrop dndConePrefab;
    [SerializeField] Text coneNumberText;

    public void SetUp()
    {
        remainingNumberOfCylinder = LevelManager.levelManager.stockOfCylinders;
        remainingNumberOfPyramid = LevelManager.levelManager.stockOfPyramids;
        remainingNumberOfCone = LevelManager.levelManager.stockOfCones;
        UpdateUI();
    }


    public void UpdateUI()
    {
        cylinderNumberText.text = remainingNumberOfCylinder.ToString();
        pyramidNumberText.text = remainingNumberOfPyramid.ToString();
        coneNumberText.text = remainingNumberOfCone.ToString();
    }

    public ObjectUIDragAndDrop StartDragAndDrop(LevelObjectType type)
    {
        if (type == LevelObjectType.Cylinder)
        {
            ObjectUIDragAndDrop newDNDObject = Object.Instantiate(dndCylinderPrefab, dragAndDropObjectsParent);
            newDNDObject.transform.localPosition = Input.mousePosition;
            return newDNDObject;
        }
        else if (type == LevelObjectType.Pyramid)
        {
            ObjectUIDragAndDrop newDNDObject = Object.Instantiate(dndPyramidPrefab, dragAndDropObjectsParent);
            newDNDObject.transform.localPosition = Input.mousePosition;
            return newDNDObject;
        }
        else if (type == LevelObjectType.Cone)
        {
            ObjectUIDragAndDrop newDNDObject = Object.Instantiate(dndConePrefab, dragAndDropObjectsParent);
            newDNDObject.transform.localPosition = Input.mousePosition;
            return newDNDObject;
        }

        return null;
    }

    public void PlaceObject(LevelObjectType type, PlacementSpot newSpot, PlacementSpot originSpot)
    {
        if (newSpot != null)
        {
            LevelObject alreadyPlacedObj = newSpot.GetPlacedObject();
            if (alreadyPlacedObj != null)
            {
                switch (alreadyPlacedObj.GetLvlObjectType)
                {
                    case (LevelObjectType.Cylinder):
                        remainingNumberOfCylinder++;
                        break;

                    case (LevelObjectType.Pyramid):
                        remainingNumberOfPyramid++;
                        break;

                    case (LevelObjectType.Cone):
                        remainingNumberOfCone++;
                        break;
                }
            }
        }

        if (originSpot != null)
        {
            LevelObject originalSpotObj = originSpot.GetPlacedObject();
            if (originalSpotObj != null)
            {
                switch (originalSpotObj.GetLvlObjectType)
                {
                    case (LevelObjectType.Cylinder):
                        remainingNumberOfCylinder++;
                        break;

                    case (LevelObjectType.Pyramid):
                        remainingNumberOfPyramid++;
                        break;

                    case (LevelObjectType.Cone):
                        remainingNumberOfCone++;
                        break;
                }
            }
        }

        if (type == LevelObjectType.Cylinder)
        {
            if (remainingNumberOfCylinder <= 0)
                return;

            LevelObject newObject = Object.Instantiate(cylinderPrefab);
            newSpot.PlaceNewObject(newObject);
            remainingNumberOfCylinder--;
        }
        else if (type == LevelObjectType.Pyramid)
        {
            if (remainingNumberOfPyramid <= 0)
                return;

            LevelObject newObject = Object.Instantiate(pyramidPrefab);
            newSpot.PlaceNewObject(newObject);
            remainingNumberOfPyramid--;
        }
        else if (type == LevelObjectType.Cone)
        {
            if (remainingNumberOfCone <= 0)
                return;

            LevelObject newObject = Object.Instantiate(conePrefab);
            newSpot.PlaceNewObject(newObject);
            remainingNumberOfCone--;
        }
    }

    public void RetrieveObject(LevelObjectType type)
    {
        switch (type)
        {
            case (LevelObjectType.Cylinder):
                remainingNumberOfCylinder++;
                break;

            case (LevelObjectType.Pyramid):
                remainingNumberOfPyramid++;
                break;

            case (LevelObjectType.Cone):
                remainingNumberOfCone++;
                break;
        }
    }

    public void GetPrefab()
    {

    }
}

