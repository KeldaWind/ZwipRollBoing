using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObjectModificationManager : MonoBehaviour
{
    LevelObject currentlySelectedObject;
    [SerializeField] Transform rotationArrowsParent;

    public void Start()
    {
        UpdateArrows();
    }

    #region Input
    public void CheckForObjectSelect()
    {
        LevelObject levelObject = null;

        Camera editCam = GameManager.gameManager.PreparationCamera;

        if (!editCam.enabled)
            return;

        Ray mouseRay = editCam.ScreenPointToRay(Input.mousePosition);

        RaycastHit[] hits = Physics.RaycastAll(mouseRay);

        foreach (RaycastHit hit in hits)
        {
            LevelObjectEditionHitbox touchedObject = hit.collider.GetComponent<LevelObjectEditionHitbox>();
            if (touchedObject != null)
            {
                levelObject = touchedObject.GetRelativeObject();
            }
        }

        currentlySelectedObject = levelObject;

        UpdateArrows();
    }

    public bool CheckForInteraction()
    {
        bool interacted = false;

        if (currentlySelectedObject == null)
            return interacted;

        Camera editCam = GameManager.gameManager.PreparationCamera;

        if (!editCam.enabled)
            return interacted;

        Ray mouseRay = editCam.ScreenPointToRay(Input.mousePosition);

        RaycastHit[] hits = Physics.RaycastAll(mouseRay);

        foreach (RaycastHit hit in hits)
        {
            IInteractible touchedInteractible = hit.collider.GetComponent<IInteractible>();
            if (touchedInteractible != null)
            {
                touchedInteractible.Interact(this);

                interacted = true;
            }
        }

        return interacted;
    }
    #endregion

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!CheckForInteraction())
            {
                CheckForObjectSelect();
            }
        }
    }

    #region Modifications
    public void ActionOnCurrentObject(ModificationType modifType)
    {
        if (currentlySelectedObject == null)
            return;

        if(modifType == ModificationType.RotateXPositive || modifType == ModificationType.RotateXNegative || modifType == ModificationType.RotateYPositive || modifType == ModificationType.RotateYNegative || modifType == ModificationType.RotateZPositive || modifType == ModificationType.RotateZNegative)
        {
            currentlySelectedObject.RotateObject(modifType);
        }

        UpdateArrows();
    }

    public void UpdateArrows()
    {
        if(currentlySelectedObject != null)
        {
            rotationArrowsParent.gameObject.SetActive(true);
            rotationArrowsParent.position = currentlySelectedObject.transform.position;
        }
        else
        {
            rotationArrowsParent.gameObject.SetActive(false);
        }
    }
    #endregion
}


public enum ModificationType
{
    RotateXPositive, RotateXNegative, RotateYPositive, RotateYNegative, RotateZPositive, RotateZNegative
}
