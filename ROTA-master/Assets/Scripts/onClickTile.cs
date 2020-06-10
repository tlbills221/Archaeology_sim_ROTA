using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onClickTile : MonoBehaviour
{
    public Sprite Click, unClick, highlight, Check;
    public GameObject Camera;
    public bool isDone = false;


    // Update is called once per frame
    void Update()
    {
        if (Camera.GetComponent<activeTile>().activeTileNo != System.Convert.ToInt32(name))
        {
            if (gameObject.GetComponent<SpriteRenderer>().sprite == Click)
            {
                if (isDone == false)
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = unClick;
                    gameObject.GetComponent<Collider2D>().isTrigger = false;
                }
                else gameObject.GetComponent<SpriteRenderer>().sprite = Check;
            }
        }
    }

    void OnMouseDown()
    {
        int tool = Camera.GetComponent<zoomController>().currentTool;
        //print(tool);
        // Zoom in on a tile if the magnifer glass is selected
        if(Camera.GetComponent<activeTile>().activeTileNo == -1 && tool == 1 && gameObject.GetComponent<SpriteRenderer>().sprite != Check)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Click;
            Camera.GetComponent<activeTile>().activeTileNo = System.Convert.ToInt32(name);
            Camera.GetComponent<zoomController>().isZoom = true;
            gameObject.GetComponent<Collider2D>().isTrigger = true;
        }
        else if (Camera.GetComponent<activeTile>().activeTileNo == -1 && tool == 0 && gameObject.GetComponent<SpriteRenderer>().sprite != Check)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = highlight;
        }
    }
}
