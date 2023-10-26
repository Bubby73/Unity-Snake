using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid_Script : MonoBehaviour
{

    public int gridSize = 11;
    public GameObject squarePrefab;

    //get screen height

    //new 2d array to hold square coords






    // Start is called before the first frame update
    void Start()
    {
        int incriment = 0;
        float stepSize = 10f / gridSize;
        float[,] gridArr = new float[(gridSize ^ 2), 2];

        //change scale of grid
        squarePrefab.transform.localScale = new Vector3(stepSize, stepSize, stepSize);


        for (float x = 0 - (gridSize / 2) + 1; x < gridSize/2; x++)
        {
            for (float y = 0 - (gridSize / 2) + 1; y < gridSize/2; y++)
            {
                //adjust x and y values so squares are togeather
                float xAdjust = x * stepSize;
                float yAdjust = y * stepSize;

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

                //add cube coords to array
                gridArr[incriment, 0] = xAdjust;
                gridArr[incriment, 1] = yAdjust;
                
   



                incriment++;
            }
        }
        print(gridArr[2, 1]);
        



    }

    // Update is called once per frame
    void Update()
    {

    }
}