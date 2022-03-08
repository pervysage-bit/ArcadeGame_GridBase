using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GridManager gridManager;

    public float speed = 5f;
    public Transform movePoint;

    private List<List<GameObject>> listGameObjects;
    private int currentColumn = 0;
    private int currentRow = 0;
    private int rows;
    private int cols;

    void Start()
    {
       // movePoint.parent = null;
    }

    void Update()
    {     
        PlayerMovementOnGrid();       
    }

    void PlayerPositionOnGrid()
    {
        listGameObjects = gridManager.GetGameObjects();
        rows = gridManager.rows;
        cols = gridManager.columns;
        movePoint.position = listGameObjects[currentRow][currentColumn].transform.position + new Vector3(0f, 0.5f, 0f);

    }

    void PlayerMovementOnGrid()
    {
       
        PlayerPositionOnGrid();        
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);


        // player move point controller, mathf.abs used because we only want positive value
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
        {
            movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
        }
        if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
        {
            movePoint.position += new Vector3(0f, 0f, Input.GetAxisRaw("Vertical"));
        }

    }
}