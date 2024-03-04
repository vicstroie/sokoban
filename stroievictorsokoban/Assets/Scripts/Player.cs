using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Vector2Int currentPos;




    // Start is called before the first frame update
    void Start()
    {
        currentPos = this.gameObject.GetComponent<GridObject>().gridPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            if(currentPos.y > 1) currentPos.y--;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if(currentPos.y < 5) currentPos.y++;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if(currentPos.x > 1) currentPos.x--;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if(currentPos.x < 10) currentPos.x++;
        }

        this.gameObject.GetComponent<GridObject>().gridPosition = currentPos;
    }
}
