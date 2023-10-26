using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid_Script : MonoBehaviour
{

    public int gridSize = 11; //initial grid size
    public GameObject squarePrefab;

    private int direction = 1; //0 = up, 1 = right, 2 = down, 3 = left

    void Start()
    {
        int incriment = 0;
        float stepSize = 10f / gridSize;
        float[,] gridArr = new float[(gridSize * gridSize), 2];



        //change scale of grid
        squarePrefab.transform.localScale = new Vector3(stepSize, stepSize, stepSize);

        //generate grid
        for (float x = 0 - (gridSize / 2) + 1; x < gridSize/2; x++)
        {
            for (float y = 0 - (gridSize / 2) + 1; y < gridSize/2; y++)
            {
                //adjust x and y values so squares are togeather
                float xAdjust = x * stepSize;
                float yAdjust = y * stepSize;

                //create cube from prefab
                GameObject square = Instantiate(squarePrefab, new Vector3(xAdjust, yAdjust, 0), Quaternion.identity);

                //alternate colours
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
                
                //save cube to array
                square.name = "Cube " + incriment;


                incriment++; //next cube
            }
        }


    }

    void Update()
    {
        //change random square colour to red
        for (int i = 0; i < (gridSize * gridSize); i++)
        {
            int r = Random.Range(0, 255);
            int g = Random.Range(0, 255);
            int b = Random.Range(0, 255);
            GameObject.Find("Cube " + i).GetComponent<Renderer>().material.color = new Color(r/255f, g/255f, b/255f);
        }


    }
}