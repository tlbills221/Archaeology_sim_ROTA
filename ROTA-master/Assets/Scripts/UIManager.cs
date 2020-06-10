using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Setup tools for digging portion
    public string[] tools = { "mattock", "trowel", "brush" };
    // The array of dig tools
    public int currentTool = 0;
    // The tool that is currently selected

    public GameObject MattockButton;
    public GameObject BrushButton;
    public GameObject TrowelButton;


    private Outline outline;

    private void Start()
    {
        // Set an outline around the default tool
        // which is the mattock
        outline = MattockButton.GetComponentInChildren<Outline>();
        print(outline.IsActive());
        //print(outline);
        outline.enabled = true;
        print(outline.IsActive());
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SelectBrush()
    {
        RemoveOutline();
        currentTool = 2;
        SetOutline();

    }

    public void SelectMattock()
    {
        RemoveOutline();
        currentTool = 0;
        SetOutline();
    }

    public void SelectTrowel()
    {
        RemoveOutline();
        currentTool = 1;
        SetOutline();
    }

    private void RemoveOutline()
    {
        // remove the outline on the previous tool
        if (currentTool == 0)
        {
            outline = MattockButton.GetComponentInChildren<Outline>();
            outline.enabled = false;
        }
        else if (currentTool == 1)
        {
            outline = TrowelButton.GetComponentInChildren<Outline>();
            outline.enabled = false;
        }
        else if (currentTool == 2)
        {
            outline = BrushButton.GetComponentInChildren<Outline>();
            outline.enabled = false;
        }
    }

    private void SetOutline()
    {
        // set the outline on the new tool
        if (currentTool == 0)
        {
            outline = MattockButton.GetComponentInChildren<Outline>();
            outline.enabled = true;
        }
        else if (currentTool == 1)
        {
            outline = TrowelButton.GetComponentInChildren<Outline>();
            outline.enabled = true;
        }
        else if (currentTool == 2)
        {
            outline = BrushButton.GetComponentInChildren<Outline>();
            outline.enabled = true;
        }
    }

}
