using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnArtifact : MonoBehaviour
{
    public int collisionCount = 0;
    public GameObject artifactPrefab;
    public GameObject Camera;

    private void Start()
    {
        Camera = GameObject.Find("Main Camera");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Soil")
        {
            collisionCount++;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Soil")
        {
            collisionCount--;
        }
    }
    void OnMouseDown()
    {
        if (collisionCount == 0)
        {
            GameObject[] soil = GameObject.FindGameObjectsWithTag("Soil");
            for (int i = 0; i < soil.Length; i++)
            {
                Destroy(soil[i]);
            }
            GameObject newArt = Instantiate(artifactPrefab); //spawn artifact IMPORTANT
            newArt.GetComponent<Inventory>().tileParent = Camera.GetComponent<activeTile>().activeTileNo;
            newArt.transform.position = new Vector3(Camera.GetComponent<zoomController>().zoomPos.x, Camera.GetComponent<zoomController>().zoomPos.y, -1f);
            newArt.GetComponent<Inventory>().artifactID = Random.Range(0, 5);
            newArt.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(newArt.GetComponent<Inventory>().artifactID.ToString()); //works
            Debug.Log("Spawned Artifact! " + newArt.transform.position);
            Camera.GetComponent<zoomController>().puzzleEnd = true;
            Destroy(gameObject);


        }
    }
}
