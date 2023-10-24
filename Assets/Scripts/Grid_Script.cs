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

        //find middle of grid
        float middle = (float)gridSize / 2f;
        //move grid to middle
        transform.position = new Vector3(-middle, -middle, 0);


        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
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
