using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArtifactCountUpdate : MonoBehaviour
{
    public int counter = 0; // The number of artifacts 
    public static int artifactCount = 0;
    Text count;

    // Start is called before the first frame update
    void Start()
    {
        count = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        artifactCount = counter;
        count.text = "Artifacts: " + artifactCount + "/1";
    }
}
