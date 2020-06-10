using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    private float height;
    private float iter = 0f;
    public bool inventory = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (inventory == false)
        {
            height = 1f * Mathf.Sin(iter); //sets amplitude
            //Debug.Log(height);
            transform.position += new Vector3(0f, height, 0f);
            iter = iter + Mathf.PI / 32f; //sets frequency
            
        }
        if (iter > 2f * Mathf.PI)
        {
            iter = 0f;
        }
    }
}
