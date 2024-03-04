using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticky : MonoBehaviour
{

    bool touchedByPlayer;
    Vector2Int currentPos;
    Vector2Int playerPos;
    GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        touchedByPlayer = false;
        currentPos = this.gameObject.GetComponent<GridObject>().gridPosition;
        player = Manager.reference.player;
    }

    // Update is called once per frame
    void Update()
    {

        playerPos = player.GetComponent<Player>().currentPos;
        
        if((playerPos.x == currentPos.x + 1 || playerPos.x == currentPos.x - 1) && (playerPos.x == currentPos.x + 1 || playerPos.x == currentPos.x - 1))
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (currentPos.y > 1) currentPos.y--;
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                if (currentPos.y < 5) currentPos.y++;
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                if (currentPos.x > 1) currentPos.x--;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                if (currentPos.x < 10) currentPos.x++;
            }
        }
        

       

        this.gameObject.GetComponent<GridObject>().gridPosition = currentPos;


    }
}
