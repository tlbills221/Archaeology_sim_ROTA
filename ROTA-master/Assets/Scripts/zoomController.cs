using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zoomController : MonoBehaviour
{
    public GameObject artifactPrefab;
    private bool startZoom = false;
    public bool isZoom = false;
    public bool puzzleEnd = false;
    private Vector3 defaultPos = new Vector3 (50f, 50f, -20f);
    public Vector3 zoomPos = new Vector3 (-10f, -10f, -20f);
    private int defaultSize = 150;
    private int zoomSize = 50;
    private float t = 0f;
    public GameObject DigTools;
    public GameObject ZoomedOutTools;
    public GameObject ScannerButton;
    public GameObject MagnifierButton;

    public int currentTool = 0; // 0: Scanner, 1: Magnifier Glass

    public int ReturnTool()
    {
        return currentTool;
    }

    private Outline outline;

    // Start is called before the first frame update
    void Start()
    {
        DigTools.SetActive(false);
        ZoomedOutTools.SetActive(true);
        
    }

    public void SelectScanner()
    {
        outline = ScannerButton.GetComponentInChildren<Outline>();
        outline.enabled = true;
        outline = MagnifierButton.GetComponentInChildren<Outline>();
        outline.enabled = false;
        currentTool = 0;
    }

    public void SelectMagnifier()
    {
        outline = MagnifierButton.GetComponentInChildren<Outline>();
        outline.enabled = true;
        outline = ScannerButton.GetComponentInChildren<Outline>();
        outline.enabled = false;
        currentTool = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (isZoom == true && currentTool == 1) //begin zoom in
        {
            DigTools.SetActive(true);
            ZoomedOutTools.SetActive(false);
            switch (gameObject.GetComponent<activeTile>().activeTileNo)
            {
                // Zoom in on selected tile
                case 1:
                    zoomPos = new Vector3 (-50f, 150f, -20f);
                    break;
                case 2:
                    zoomPos = new Vector3(50f, 150f, -20f);
                    break;
                case 3:
                    zoomPos = new Vector3(150f, 150f, -20f);
                    break;
                case 4:
                    zoomPos = new Vector3(-50f, 50f, -20f);
                    break;
                case 5:
                    zoomPos = new Vector3(50f, 50f, -20f);
                    break;
                case 6:
                    zoomPos = new Vector3(150f, 50f, -20f);
                    break;
                case 7:
                    zoomPos = new Vector3(-50f, -50f, -20f);
                    break;
                case 8:
                    zoomPos = new Vector3(50f, -50f, -20f);
                    break;
                case 9:
                    zoomPos = new Vector3(150f, -50f, -20f);
                    break;
            }
            t = t + 0.025f;
            Camera.main.orthographicSize = Mathf.Lerp(defaultSize, zoomSize, t);
            transform.position = Vector3.Lerp(defaultPos, zoomPos, t);
            if (transform.position == zoomPos && t >= 1f) //zoomed in done
            {
                t = 0f;
                isZoom = false;
            }
        }
        if (Input.GetKeyDown("escape") && puzzleEnd == true) //begin zoom out once the puzzle is done
        {
            startZoom = true;
        }

        if (startZoom == true)
        {
            GameObject.Find(gameObject.GetComponent<activeTile>().activeTileNo.ToString()).GetComponent<onClickTile>().isDone = true;


            t = t + 0.025f;
            Camera.main.orthographicSize = Mathf.Lerp(zoomSize, defaultSize, t);
            transform.position = Vector3.Lerp(zoomPos, defaultPos, t);
        }
        if (transform.position == defaultPos && t >= 1f) //zoomed out finish
        {
            DigTools.SetActive(false);
            ZoomedOutTools.SetActive(true);
            t = 0f;
            gameObject.GetComponent<activeTile>().activeTileNo = -1;
            puzzleEnd = false;
            startZoom = false;
            gameObject.GetComponent<activeTile>().puzzleStart = false;
        }
    }


}
