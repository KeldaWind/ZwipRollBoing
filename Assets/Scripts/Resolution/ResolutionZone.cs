using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionZone : MonoBehaviour
{
    bool won = false;

    private void OnTriggerStay(Collider other)
    {
        if(other.GetComponent<ResolutionBall>() != null && !won)
        {
            won = true;
            GameManager.gameManager.WinGame();
        }
    }
}
