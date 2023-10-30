using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid_Script : MonoBehaviour
{

    public int gridSize = 11; //initial grid size
    public GameObject squarePrefab;

    private int direction = 1; //0 = up, 1 = right, 2 = down, 3 = left

    private int currentCube = 0; //current cube number

    private int score = 1;

    //set fps to 10
    void Awake()
    {
        Application.targetFrameRate = 3;
    }

    void Start()
    {

        if (gridSize % 2 == 0) //if grid size is even, make it odd
        {
            gridSize++;
        }

        int incriment = 0;
        float stepSize = 10f / gridSize;



        //change scale of grid
        squarePrefab.transform.localScale = new Vector3(stepSize, stepSize, stepSize);

        //generate grid
        for (float x = 0 - (gridSize / 2); x < gridSize/2 + 1; x++)
        {
            for (float y = 0 - (gridSize / 2); y < gridSize/2 + 1; y++)
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
                //gridArr[incriment, 0] = xAdjust;
                //gridArr[incriment, 1] = yAdjust;
                
                square.name = "Cube " + incriment;
                incriment++; //next cube
                
            }
        }


    }

    void Update()
    {
        //set current cube to red
        GameObject.Find("Cube " + currentCube).GetComponent<Renderer>().material.color = Color.green;
        float[] snakeArr = new float[(gridSize * gridSize)];

        //take arrow key input
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = 0;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = 1;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = 2;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = 3;
        }

        //move cube
        if (direction == 0)
        {
            if (currentCube + 1 < gridSize * gridSize)
            {
                currentCube ++;
            }
        }
        else if (direction == 1)
        {
            if (currentCube + gridSize < gridSize * gridSize)
            {
                currentCube = currentCube + gridSize;
            }
        }
        else if (direction == 2)
        {
            if (currentCube - 1 >= 0)
            {
                currentCube --;
            }
        }
        else if (direction == 3)
        {
            if (currentCube - gridSize >= 0)
            {
                currentCube = currentCube - gridSize;
            }
        }
        else
        {
            print("error");
        }

        for (int i = 0; i <= score; i++)
        {
            snakeArr[i] = currentCube;
            if (i > 0)
            {
                GameObject.Find("Cube " + (snakeArr[i - 1])).GetComponent<Renderer>().material.color = Color.red;
            }
            else
            {

                GameObject.Find("Cube " + (snakeArr[i])).GetComponent<Renderer>().material.color = Color.green;
            }
            //GameObject.Find("Cube " + (snakeArr[i])).GetComponent<Renderer>().material.color = Color.green;

        }
        
        print(currentCube);

        //set cube in array behind current cube to green

        




    }
        


}