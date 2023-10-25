using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid_Script : MonoBehaviour
{

    public int gridSize = 11;
    public GameObject squarePrefab;

    //get screen height
    float screenHeight = 10;
    
    


    // Start is called before the first frame update
    void Start()
    {
        int incriment = 0;
        float squareSize = screenHeight / gridSize;
        //change scale of grid
        squarePrefab.transform.localScale = new Vector3(squareSize, squareSize, squareSize);
        

        for (float x = 0 - (gridSize / 2) + 1; x < gridSize/2; x++)
        {
            for (float y = 0 - (gridSize / 2) + 1; y < gridSize/2; y++)
            {
                //adjust x and y values so squares are togeather
                float xAdjust = -x * (squareSize / 2);
                float yAdjust = -y * (squareSize / 2);

                //create cube from prefab
                GameObject square = Instantiate(squarePrefab, new Vector3(xAdjust, yAdjust, 0), Quaternion.identity);
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
