using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid_Script : MonoBehaviour
{

    public int gridSize = 11;
    public GameObject squarePrefab;
    public float scale = 1f;

    // Start is called before the first frame update
    void Start()
    {
        int incriment = 0;
        //change scale of grid
        squarePrefab.transform.localScale = new Vector3(scale, scale, scale);
        

   

        for (float x = 0 - (gridSize / 2) * scale + 1; x < gridSize/2; x++)
        {
            print(x);
            for (float y = 0 - (gridSize / 2) * scale + 1; y < gridSize/2; y++)
            {
                //convert x and y to floats
                float xFloat = (float)x * scale;
                float yFloat = (float)y * scale;

                //create cube from prefab
                GameObject square = Instantiate(squarePrefab, new Vector3(xFloat, yFloat, 0), Quaternion.identity);
                //make every other cube black
                if (incriment % 2 == 0)
                {
                    square.GetComponent<Renderer>().material.color = new Color(31/255f, 161/255f, 36/255f);
                }
                else
                {
                    square.GetComponent<Renderer>().material.color = new Color(17/255f, 186/255f, 22/255f);
                }

                incriment++;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
   
    }
}
