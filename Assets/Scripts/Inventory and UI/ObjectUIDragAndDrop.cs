using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectUIDragAndDrop : MonoBehaviour
{
    [SerializeField] LevelObjectType type;
    InventoryManager inventoryManager;

    public void SetUp(InventoryManager inventManager)
    {
        inventoryManager = inventManager;
    }

    public void Update()
    {
        transform.localPosition = Input.mousePosition - new Vector3(Screen.width/2, Screen.height/2, 0);

        if (Input.GetMouseButtonUp(0))
        {
            CheckForSpot();
            Destroy(gameObject);
        }
    }

    public bool CheckForSpot()
    {
        bool spotPresent = false;



        return spotPresent;
    }
}
