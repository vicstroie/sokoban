using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clingy : MonoBehaviour
{
    public bool touchedByPlayer;
    public Vector2Int currentPos;
    Vector2Int playerPos;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        touchedByPlayer = false;
        currentPos = this.gameObject.GetComponent<GridObject>().gridPosition;
        //player = Manager.reference.player;
    }

    // Update is called once per frame
    void Update()
    {

        currentPos = this.gameObject.GetComponent<GridObject>().gridPosition;


        playerPos = player.GetComponent<Player>().currentPos;
        if ((playerPos.x == currentPos.x + 1 && playerPos.y == currentPos.y)
            || (playerPos.x == currentPos.x && playerPos.y == currentPos.y + 1)
            || (playerPos.x == currentPos.x - 1 && playerPos.y == currentPos.y)
            || (playerPos.x == currentPos.x && playerPos.y == currentPos.y - 1))


        {
            touchedByPlayer = true;
        }
        else
        {
            touchedByPlayer = false;
        }



        if ((playerPos.y == currentPos.y - 1 && playerPos.x == currentPos.x))
        {
            if (currentPos.y > 1 && Input.GetKeyDown(KeyCode.W)) currentPos.y--;
        }

        if ((playerPos.y == currentPos.y + 1 && playerPos.x == currentPos.x))
        {
            if (currentPos.y < 5 && Input.GetKeyDown(KeyCode.S)) currentPos.y++;
        }

        if ((playerPos.y == currentPos.y && playerPos.x == currentPos.x - 1))
        {

            Debug.Log("PRIGHT");
            if (currentPos.x > 1 && Input.GetKeyDown(KeyCode.A)) currentPos.x--;
        }

        if ((playerPos.y == currentPos.y && playerPos.x == currentPos.x + 1))
        {
            if (currentPos.x < 10 && Input.GetKeyDown(KeyCode.D)) currentPos.x++;
            Debug.Log("PLEFT");
        }




        this.gameObject.GetComponent<GridObject>().gridPosition = currentPos;


    }
}
