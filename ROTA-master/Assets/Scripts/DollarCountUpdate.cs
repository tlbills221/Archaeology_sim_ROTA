using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DollarCountUpdate : MonoBehaviour
{
    public static int dollarCount = 0; // The amount of grant money available
    Text count;

    // Start is called before the first frame update
    void Start()
    {
        count = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        dollarCount = ArtifactCountUpdate.artifactCount * 100;
        count.text = "Grant Dollars: $" + dollarCount;
    }
}