using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilStuff : MonoBehaviour
{
    public int soilType;
    public int tool;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        tool = GameObject.Find("UIManager").GetComponent<UIManager>().currentTool;
        Debug.Log("Tool: " + tool + ", Type: " + soilType);
        switch (soilType) //1 = fine, 2 = rocky, 3 = normal
        {
            case 1:
                if (tool == 2) //tools: brush - 2, mattock - 0, trowel - 1
                {
                    Destroy(gameObject);
                }
                break;
            case 2:
                if (tool == 0)
                {
                    Destroy(gameObject);
                }
                break;
            case 3:
                if (tool == 1)
                {
                    Destroy(gameObject);
                }
                break;

        }
    }
}
