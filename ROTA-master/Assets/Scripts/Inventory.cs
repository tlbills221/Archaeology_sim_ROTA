using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int tileParent;
    public int artifactID;
    // Start is called before the first frame update
    void Start()
    {
        switch (tileParent)
        {
            // Sets where the artifact spawns at
            case 1:
                transform.position = new Vector3(-50f, 150f, -10f);
                break;
            case 2:
                transform.position = new Vector3(50f, 150f, -10f);
                break;
            case 3:
                transform.position = new Vector3(150f, 150f, -10f);
                break;
            case 4:
                transform.position = new Vector3(-50f, 50f, -10f);
                break;
            case 5:
                transform.position = new Vector3(50f, 50f, -10f);
                break;
            case 6:
                transform.position = new Vector3(150f, 50f, -10f);
                break;
            case 7:
                transform.position = new Vector3(-50f, -50f, -10f);
                break;
            case 8:
                transform.position = new Vector3(50f, -50f, -10f);
                break;
            case 9:
                transform.position = new Vector3(150f, -50f, -10f);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find(tileParent.ToString()).GetComponent<onClickTile>().isDone == true) //when the puzzle is done, send the artifact to the bag
        {
            GetComponent<Bounce>().inventory = true;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(278f, -50f, -10f), 250f * Time.deltaTime);
        }
    }
}
