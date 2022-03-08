using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private List<List<GameObject>> gameObjects;
    private GameObject temp;
    private float horizontalSpacing = 0;
    private float verticalSpacing = 0;
    private int counter = 0;

    public GameObject prefabCube;
    public int rows;
    public int columns;


    // Start is called before the first frame update
    public void Start()
    {
        gameObjects = new List<List<GameObject>>();
        GridInstantiate();
    }

    void GridInstantiate()
    {
        for (int i = 0; i < rows; i++)
        {
            gameObjects.Add(new List<GameObject>());
            for (int j = 0; j < columns; j++)
            {
                CellPosition();
                temp = Instantiate(prefabCube, new Vector3(horizontalSpacing, 0.5f, verticalSpacing), prefabCube.transform.rotation);
                counter++;
                gameObjects[i].Add(temp);

            }
        }
    }

    void CellPosition()
    {
        if (counter == rows)
        {
            verticalSpacing += 1f;
            counter = 0;
            horizontalSpacing = 1f;
        }
        else
        {
            horizontalSpacing += 1f;
        }
    }
    public List<List<GameObject>> GetGameObjects()
    {
        return gameObjects;
    }
}
