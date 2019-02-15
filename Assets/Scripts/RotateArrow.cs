using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateArrow : MonoBehaviour, IInteractible
{
    [SerializeField] ModificationType rotationType;

    public void Interact(LevelObjectModificationManager modificator)
    {
        modificator.ActionOnCurrentObject(rotationType);
    }
}
