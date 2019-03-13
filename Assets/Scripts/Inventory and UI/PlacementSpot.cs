using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementSpot : MonoBehaviour
{
    [SerializeField] Transform placementPosition;
    [SerializeField] MeshRenderer renderer;
    bool occupied;
    LevelObject placedObject;

    public LevelObject GetPlacedObject()
    {
        return placedObject;
    }

    public bool Clear
    {
        get
        {
            return !occupied;
        }
    }

    public void PlaceNewObject(LevelObject newObj)
    {
        RemoveObject();

        placedObject = newObj;
        placedObject.transform.position = placementPosition.position;

        LevelManager.levelManager.AddNewObject(placedObject);

        occupied = true;

        if (TutorialManager.tutorialManager != null)
            TutorialManager.tutorialManager.ShowSelectText();
    }

    public void RemoveObject()
    {
        if (placedObject != null)
        {
            LevelManager.levelManager.RemoveObject(placedObject);
            Destroy(placedObject.gameObject);
            placedObject = null;
        }

        occupied = false;
    }


    bool possibleDND;
    bool dnded;
    Vector3 startPos;
    public void StartPossibleDND()
    {
        if (placedObject == null)
            return;

        possibleDND = true;
        startPos = Input.mousePosition;
    }

    private void Start()
    {
        GameManager.gameManager.AddPlacementSpot(this);
    }

    private void Update()
    {
        if (possibleDND)
        {
            if(!dnded && Vector3.Distance(startPos, Input.mousePosition) > 50)
            {
                ObjectUIDragAndDrop newDNDObject = GameManager.gameManager.InvtManager.StartDragAndDrop(placedObject.GetLvlObjectType, false);

                if (newDNDObject != null)
                {
                    newDNDObject.SetUp(this);
                    dnded = true;
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                possibleDND = false;
                dnded = false;
            }
;        }
    }

    public void ShowRenderer()
    {
        if (renderer != null)
            renderer.enabled = true;
    }

    public void HideRenderer()
    {
        if (renderer != null)
            renderer.enabled = false;
    }
}
