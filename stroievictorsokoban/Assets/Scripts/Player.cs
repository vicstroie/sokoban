using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Vector2Int currentPos;
    public Vector2Int prevPos;




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
            //&& (Manager.reference.pos[3].y != currentPos.y - 1 && Manager.reference.pos[3].x != currentPos.x)
            if (currentPos.y > 1 ) currentPos.y--;
            prevPos = currentPos;
        }

        if (Input.GetKeyDown(KeyCode.S) )
        {
            //&& (Manager.reference.pos[3].y != currentPos.y + 1 && Manager.reference.pos[3].x != currentPos.x)
            if (currentPos.y < 5 ) currentPos.y++;
            prevPos = currentPos;
        }

        if (Input.GetKeyDown(KeyCode.A) )
        {
            //&& (Manager.reference.pos[3].y != currentPos.y && Manager.reference.pos[3].x != currentPos.x - 1)
            if (currentPos.x > 1 ) currentPos.x--;
            prevPos = currentPos;
        }

        if (Input.GetKeyDown(KeyCode.D) )
        {
            //&& (Manager.reference.pos[3].y != currentPos.y && Manager.reference.pos[3].x != currentPos.x + 1)
            if (currentPos.x < 10 ) currentPos.x++;
            prevPos = currentPos;
        }

        this.gameObject.GetComponent<GridObject>().gridPosition = currentPos;
    }
}
