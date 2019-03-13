using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectUIDragAndDrop : MonoBehaviour
{
    [SerializeField] LevelObjectType type;
    PlacementSpot relatedSpot;

    public void SetUp(PlacementSpot baseSpot)
    {
        relatedSpot = baseSpot;
    }

    public void Update()
    {
        transform.localPosition = Input.mousePosition - new Vector3(Screen.width/2, Screen.height/2, 0);

        if (Input.GetMouseButtonUp(0))
        {
            if (!CheckForSpot())
            {
                if (relatedSpot != null)
                {
                    Debug.Log("replaçage");
                    GameManager.gameManager.InvtManager.RetrieveObject(type);
                }
            }
            
            Destroy(gameObject);
        }
    }

    public bool CheckForSpot()
    {
        bool spotPresent = false;

        PlacementSpot goodSpot = null;

        LevelObjectType newSpotBasicObjectType = LevelObjectType.None;

        Ray ray = GameManager.gameManager.PreparationCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit[] hits = Physics.RaycastAll(ray);

        foreach (RaycastHit hit in hits)
        {
            PlacementSpot spot = hit.collider.GetComponent<PlacementSpot>();
            if (spot != null)
            {
                goodSpot = spot;
                spotPresent = true;
                if (spot != relatedSpot)
                {
                    if (spot.GetPlacedObject() != null)
                        newSpotBasicObjectType = spot.GetPlacedObject().GetLvlObjectType;

                    GameManager.gameManager.InvtManager.PlaceObject(type, spot, relatedSpot);
                    break;
                }
            }
        }

        if (relatedSpot != null && relatedSpot != goodSpot)
        {
            relatedSpot.RemoveObject();
            if(newSpotBasicObjectType != LevelObjectType.None)
            {
                GameManager.gameManager.InvtManager.PlaceObject(newSpotBasicObjectType, relatedSpot, null);
            }
        }

        return spotPresent;
    }
}
