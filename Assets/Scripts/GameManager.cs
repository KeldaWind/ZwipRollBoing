using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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
    }
