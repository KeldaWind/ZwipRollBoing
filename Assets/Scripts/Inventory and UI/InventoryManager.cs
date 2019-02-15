using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryManager : MonoBehaviour
{
    [Header("Level Objects")]
    [SerializeField] LevelObject cylinderPrefab;
    [SerializeField] LevelObject pyramidPrefab;
    [SerializeField] LevelObject conePrefab;

    [SerializeField] int totalNumberOfCylinder;
    int remainingNumberOfCylinder;
    [SerializeField] int totalNumberOfPyramid;
    int remainingNumberOfPyramid;
    [SerializeField] int totalNumberOfCone;
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
        remainingNumberOfCylinder = totalNumberOfCylinder;
        remainingNumberOfPyramid = totalNumberOfPyramid;
        remainingNumberOfCone = totalNumberOfCone;
    }

    public void UpdateUI()
    {
        cylinderNumberText.text = remainingNumberOfCylinder.ToString();
        pyramidNumberText.text = remainingNumberOfPyramid.ToString();
        coneNumberText.text = remainingNumberOfCone.ToString();
    }

    public void StartDragAndDrop(LevelObjectType type)
    {
        if (type == LevelObjectType.Cylinder)
        {
            ObjectUIDragAndDrop newDNDObject = Instantiate(dndCylinderPrefab, dragAndDropObjectsParent);
            newDNDObject.SetUp(this);
        }
        else if (type == LevelObjectType.Pyramid)
        {
            ObjectUIDragAndDrop newDNDObject = Instantiate(dndPyramidPrefab, dragAndDropObjectsParent);
            newDNDObject.SetUp(this);
        }
        else if (type == LevelObjectType.Cone)
        {
            ObjectUIDragAndDrop newDNDObject = Instantiate(dndConePrefab, dragAndDropObjectsParent);
            newDNDObject.SetUp(this);
        }
    }

    public void PlaceObject(LevelObjectType type)
    {
        if(type == LevelObjectType.Cylinder)
        {

        }
        else if (type == LevelObjectType.Pyramid)
        {

        }
        else if (type == LevelObjectType.Cone)
        {

        }
    }

    public void RetrievObject()
    {

    }

    public void GetPrefab()
    {

    }
}

