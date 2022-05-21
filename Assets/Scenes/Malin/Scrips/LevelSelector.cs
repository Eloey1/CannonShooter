using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSelector : MonoBehaviour 
{
    [SerializeField] GameObject panel;
    [SerializeField] GameObject button;
    [SerializeField] GameObject thisCanvas;
    [SerializeField] int numberOfLevels = 5;
    [SerializeField] Vector2 iconSpacing;
    private Rect panelDimensions;
    private Rect iconDimensions;
    private int amountPerPage;
    private int currentLevelCount;

    void Start()
    {
        panelDimensions = panel.GetComponent<RectTransform>().rect;
        iconDimensions = button.GetComponent<RectTransform>().rect;

        int maxInARow = Mathf.FloorToInt((panelDimensions.width + iconSpacing.x) / (iconDimensions.width + iconSpacing.x));
        int maxInACol = Mathf.FloorToInt((panelDimensions.height + iconSpacing.y) / (iconDimensions.height + iconSpacing.y));
        amountPerPage = maxInARow * maxInACol;
        int totalPages = Mathf.CeilToInt((float)numberOfLevels / amountPerPage);
        LoadPanels(totalPages);
    }
    void LoadPanels(int numberOfPanels)
    {
        GameObject panelClone = Instantiate(panel) as GameObject;
        //PageSwiper panelSwiper = panel.AddComponent<PageSwiper>();
        //panelSwiper.totalPages = numberOfPanels;
        panel.AddComponent<PageSwiper>();

        for (int i = 1; i <= numberOfPanels; i++)
        {
            GameObject panel = Instantiate(panelClone) as GameObject;
            panel.transform.SetParent(thisCanvas.transform, false);
            panel.transform.SetParent(panel.transform);
            panel.name = "Page_" + i;
            panel.GetComponent<RectTransform>().localPosition = new Vector2(panelDimensions.width * (i - 1), 0);
            SetUpGrid(panel);
            int numberOfIcons = i == numberOfPanels ? numberOfLevels - currentLevelCount : amountPerPage;
            LoadIcons(numberOfIcons, panel);
        }
        Destroy(panelClone);
    }
    void SetUpGrid(GameObject panel)
    {
        GridLayoutGroup grid = panel.AddComponent<GridLayoutGroup>();
        grid.cellSize = new Vector2(iconDimensions.width, iconDimensions.height);
        grid.childAlignment = TextAnchor.MiddleCenter;
        grid.spacing = iconSpacing;
    }
    void LoadIcons(int numberOfIcons, GameObject parentObject)
    {
        for (int i = 1; i <= numberOfIcons; i++)
        {
            currentLevelCount++;
            GameObject icon = Instantiate(button) as GameObject;
            icon.transform.SetParent(thisCanvas.transform, false);
            icon.transform.SetParent(parentObject.transform);
            icon.name = "Level " + i;

            for (int j = 0; j < icon.GetComponentsInChildren<TextMeshProUGUI>().Length; j++)
            {
                icon.GetComponentsInChildren<TextMeshProUGUI>()[j].SetText("Level " + currentLevelCount);
            }

            icon.GetComponent<SwitchScene>().specificScene = i;
        }
    }
}
