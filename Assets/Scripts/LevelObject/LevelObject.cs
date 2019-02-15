using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObject : MonoBehaviour
{
    [SerializeField] LevelObjectType type;
    public LevelObjectType GetLvlObjectType
    {
        get
        {
            return type;
        }
    }

    [Header("Colliders")]
    [SerializeField] Collider zwipCollider;
    [SerializeField] Collider rollCollider;
    [SerializeField] Collider boingCollider;

    [Header("Rendering")]
    [SerializeField] Renderer objRenderer;
    [SerializeField] Material prepaMat;
    [SerializeField] Material resolMat;

    public void CheckColliders()
    {
        switch (GetObjectFunction())
        {
            case (LevelObjectFunction.Zwip):
                if(zwipCollider != null)
                    zwipCollider.enabled = true;
                if (rollCollider != null)
                    rollCollider.enabled = false;
                if (boingCollider != null)
                    boingCollider.enabled = false;
                break;

            case (LevelObjectFunction.Roll):
                if (zwipCollider != null)
                    zwipCollider.enabled = false;
                if (rollCollider != null)
                    rollCollider.enabled = true;
                if (boingCollider != null)
                    boingCollider.enabled = false;
                break;

            case (LevelObjectFunction.Boing):
                if (zwipCollider != null)
                    zwipCollider.enabled = false;
                if (rollCollider != null)
                    rollCollider.enabled = false;
                if (boingCollider != null)
                    boingCollider.enabled = true;
                break;

            case (LevelObjectFunction.None):
                if (zwipCollider != null)
                    zwipCollider.enabled = false;
                if (rollCollider != null)
                    rollCollider.enabled = false;
                if (boingCollider != null)
                    boingCollider.enabled = false;
                break;
        }
    }

    #region Modifications
    public void RotateObject(ModificationType rot)
    {
        Vector3 rotation = new Vector3();

        switch (rot)
        {
            case(ModificationType.RotateXPositive):
                rotation.x = 90;
                break;

            case (ModificationType.RotateXNegative):
                rotation.x = -90;
                break;

            case (ModificationType.RotateYPositive):
                rotation.y = 90;
                break;

            case (ModificationType.RotateYNegative):
                rotation.y = -90;
                break;

            case (ModificationType.RotateZPositive):
                rotation.z = 90;
                break;

            case (ModificationType.RotateZNegative):
                rotation.z = -90;
                break;
        }

        transform.Rotate(rotation, Space.World);
    }
    #endregion

    #region Functions
    public LevelObjectFunction GetObjectFunction()
    {
        Ray ray = new Ray();

        ray.origin = new Vector3(GameManager.gameManager.ResolutionCamera.transform.position.x, transform.position.y, transform.position.z);
        ray.direction = new Vector3(1, 0, 0);

        RaycastHit[] hits = Physics.RaycastAll(ray);

        foreach(RaycastHit hit in hits)
        {
            LevelObjectFunctionIdentifier identifier = hit.collider.GetComponent<LevelObjectFunctionIdentifier>();
            if (identifier != null)
                return identifier.GetFunction();
        }

        return LevelObjectFunction.None;
    }
    #endregion

    public void SetPrepaMat()
    {
        objRenderer.material = prepaMat;
    }

    public void SetResolMat()
    {
        objRenderer.material = resolMat;
    }
}

public enum LevelObjectType
{
    None, Cylinder, Pyramid, Cone
}

public enum LevelObjectFunction
{
    None, Zwip, Roll, Boing
}

