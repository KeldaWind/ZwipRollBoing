using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    [Header("Modules")]
    [SerializeField] InventoryManager inventoryManager;
    public InventoryManager InvtManager
    {
        get
        {
            return inventoryManager;
        }
    }

    private void Awake()
    {
        gameManager = this;

        ball.SetUpBall();

        HideAllPlacementSpots = null;
        ShowAllPlacementSpots = null;

        StartPreparationPhase();

        inventoryManager.SetUp();
    }

    private void Update()
    {
        UpdateUIInteractions();

        inventoryManager.UpdateUI();
    }

    #region Preparation
    [Header("Preparation")]
    [SerializeField] Camera preparationCamera;
    public Camera PreparationCamera
    {
        get
        {
            return preparationCamera;
        }
    }

    [SerializeField] Canvas preparationCanvas;

    public void StartPreparationPhase()
    {
        if (won)
            return;

        preparationCamera.enabled = true;
        resolutionCamera.enabled = false;

        preparationCanvas.gameObject.SetActive(true);
        resolutionCanvas.gameObject.SetActive(false);

        ball.ResetBall();

        LevelManager.levelManager.ResetAllObjects();

        if(ShowAllPlacementSpots != null)
            ShowAllPlacementSpots();
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

        HideAllPlacementSpots();
    }

    public void UpdateResolutionPhase()
    {

    }

    public delegate void UpdatePlacementSpots();
    public UpdatePlacementSpots HideAllPlacementSpots;
    public UpdatePlacementSpots ShowAllPlacementSpots;

    public void AddPlacementSpot(PlacementSpot spot)
    {
        HideAllPlacementSpots += spot.HideRenderer;
        ShowAllPlacementSpots += spot.ShowRenderer;
    }
    #endregion

    #region UI interactions
    [Header("General References")]
    [SerializeField] GraphicRaycaster graphicRaycaster;
    [SerializeField] EventSystem eventSystem;
    PointerEventData pointerEventData;

    private void UpdateUIInteractions()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pointerEventData = new PointerEventData(eventSystem);
            pointerEventData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();
            graphicRaycaster.Raycast(pointerEventData, results);

            foreach(RaycastResult result in results)
            {
                ObjectUIStock stock = result.gameObject.GetComponent<ObjectUIStock>();
                if (stock != null)
                {
                    inventoryManager.StartDragAndDrop(stock.type);
                }
            }
        }        
    }
    #endregion

    #region WinGame
    [Header("WinGame")]
    [SerializeField] GameObject winGamePanel;
    bool won;

    public void WinGame()
    {
        Debug.Log("C'est gagné !");
        winGamePanel.SetActive(true);
        won = true;
    }

    public void LoadNextLevel()
    {
        try
        {
            SceneManager.LoadScene(LevelManager.levelManager.nextLevelName);
        }
        catch
        {
            GoBackToMenu();
        }
    }

    public void GoBackToMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
    #endregion
}
