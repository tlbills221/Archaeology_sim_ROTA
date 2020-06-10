using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeTile : MonoBehaviour
{
    public int activeTileNo = -1; // no title is selected yet
    public bool puzzleStart = false;
    public GameObject buryPrefab;
    public GameObject soilPrefab;
    private int numSoil;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activeTileNo != -1 && puzzleStart == false && gameObject.GetComponent<zoomController>().isZoom == false) //spawn pieces relative to camera
        {
            puzzleStart = true;
            numSoil = Random.Range(30, 31); //number of soil pieces. Currently hardcoded to 30. If you increase this, the grid squares will need higher z-values
            
            //spawn layer 0 - buried artifact
            Vector3 pos = new Vector3(Random.Range(0.33f, 0.66f), Random.Range(0.125f, 0.875f), 0f);
            pos = Camera.main.ViewportToWorldPoint(pos); //Convert absolute position to position relative to the camera
            GameObject dig = Instantiate(buryPrefab);
            dig.transform.position = pos + new Vector3(0f, 0f, numSoil + 1f); //Put the buried artifact on bottom-most layer

            //spawn layer 1 - soil
            for (int i = 2; i <= numSoil; i++) //goes from 1 to Random, you can set how many soil pieces spawn here
            {
                Vector3 pos1 = new Vector3(Random.Range(0.33f, 0.66f), Random.Range(0.125f, 0.875f), 0f); //randomly place soil
                pos1 = Camera.main.ViewportToWorldPoint(pos1);
                GameObject soil = Instantiate(soilPrefab);
                soil.transform.position = pos1 + new Vector3(0f, 0f, i); //Cam at bottom, render from bottom to top
                int soilType = Random.Range(1, 4); //1 = fine, 2 = rocky, 3 = normal
                int spriteNum = -1;
                switch (soilType)
                {
                    case 1: //fine
                        spriteNum = Random.Range(5, 8);
                        break;
                    case 2: //rocky
                        spriteNum = Random.Range(8, 12);
                        break;
                    case 3: //normal
                        spriteNum = Random.Range(12, 15);
                        break;
                }
                soil.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(spriteNum.ToString());
                soil.AddComponent<PolygonCollider2D>();
                soil.GetComponent<SoilStuff>().soilType = soilType;

            } 


        }
    }
}
