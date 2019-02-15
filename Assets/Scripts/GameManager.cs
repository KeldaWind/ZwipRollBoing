using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    private void Awake()
    {
        gameManager = this;

        ball.SetUpBall();

        StartPreparationPhase();
    }

    private void Update()
    {
    }

    #region Preparation
    [Header("Preparation")]
    [SerializeField] Camera preparationCamera;
    public  Camera PreparationCamera
    {
        get
        {
            return preparationCamera;
        }
    }

    [SerializeField] Canvas preparationCanvas;

    public void StartPreparationPhase()
    {
        preparationCamera.enabled = true;
        resolutionCamera.enabled = false;

        preparationCanvas.gameObject.SetActive(true);
        resolutionCanvas.gameObject.SetActive(false);

        ball.ResetBall();

        LevelManager.levelManager.ResetAllObjects();
    }

    public void UpdatePreparationPhase()
    {

    }

    #region Ball
    [SerializeField] ResolutionBall ball;

    #endregion
    #endregion

    #region Resolution
    [Header("Preparation")]
    [SerializeField] Camera resolutionCamera;
    public Camera ResolutionCamera
    {
        get
        {
            return resolutionCamera;
        }
    }

    [SerializeField] Canvas resolutionCanvas;
    public void StartResolutionPhase()
    {
        resolutionCamera.enabled = true;
        preparationCamera.enabled = false;

        resolutionCanvas.gameObject.SetActive(true);
        preparationCanvas.gameObject.SetActive(false);

        LevelManager.levelManager.CheckAllObjectsFunction();
        ball.ActivateResolutionBall();
    }

    public void UpdateResolutionPhase()
    {

    }
    #endregion
}
