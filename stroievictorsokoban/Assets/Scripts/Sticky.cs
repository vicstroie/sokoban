using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticky : MonoBehaviour
{

    public bool touchedByPlayer;
    public Vector2Int currentPos;
    Vector2Int playerPos;
    public GameObject player;

    public GameObject touching;


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
        
        for(int i = 0; i < 4; i++)
        {
            if (Manager.reference.touched[i])
            {

            }
        }

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



        if (touchedByPlayer) {


            if (Input.GetKeyDown(KeyCode.W))
            {

                /*
                    for(int i = 0; i < 5; i++)
                    {

                    }
                    */
                //if (Manager.reference.blocks[0].GetComponent<Player>().currentPos.x == currentPos.x + 1)


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
