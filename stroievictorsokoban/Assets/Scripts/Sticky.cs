using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticky : Block
{

   
    Vector2Int playerPos;
    public GameObject player;

    public GameObject touching;


    // Start is called before the first frame update
    void Start()
    {
        base.touchedByPlayer = false;
        base.currentPos = this.gameObject.GetComponent<GridObject>().gridPosition;
        //player = Manager.reference.player;
    }

    // Update is called once per frame
    void Update()
    {

        base.currentPos = this.gameObject.GetComponent<GridObject>().gridPosition;

        if (currentPos.y == 1) base.cantUp = true; else base.cantUp = false;
        if (currentPos.y == 5) base.cantDown = true; else base.cantDown = false;
        if (currentPos.x == 1) base.cantLeft = true; else base.cantLeft = false;
        if (currentPos.x == 10) base.cantRight = true; else base.cantRight = false;


        playerPos = player.GetComponent<Player>().currentPos;



        if ((playerPos.x == base.currentPos.x + 1 && playerPos.y == base.currentPos.y) 
            || (playerPos.x == base.currentPos.x && playerPos.y == base.currentPos.y + 1)
            || (playerPos.x == base.currentPos.x - 1 && playerPos.y == base.currentPos.y)
            || (playerPos.x == base.currentPos.x && playerPos.y == base.currentPos.y - 1))


        {
            base.touchedByPlayer = true;
        }
        else
        {
            base.touchedByPlayer = false;
        }



        if (touchedByPlayer) {


            if (Input.GetKeyDown(KeyCode.W))
            {
                for (int i = 0; i < 4; i++)
                {
                    if (Manager.reference.pos[i].x == base.currentPos.x && Manager.reference.pos[i].y == base.currentPos.y - 1)
                    {
                        if (Manager.reference.blocks[i].GetComponent<Block>().cantUp) base.cantUp = true;
                    }
                }

                if (!base.cantUp) base.currentPos.y--;
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                for (int i = 0; i < 4; i++)
                {
                    if (Manager.reference.pos[i].x == base.currentPos.x && Manager.reference.pos[i].y == base.currentPos.y + 1)
                    {
                        if (Manager.reference.blocks[i].GetComponent<Block>().cantDown) base.cantDown = true;
                    }
                }

                if (!base.cantDown) base.currentPos.y++;
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                for (int i = 0; i < 4; i++)
                {
                    if (Manager.reference.pos[i].x == base.currentPos.x - 1 && Manager.reference.pos[i].y == base.currentPos.y)
                    {
                        if (Manager.reference.blocks[i].GetComponent<Block>().cantLeft) base.cantLeft = true;
                    }
                }


                if (!base.cantLeft) base.currentPos.x--;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                for (int i = 0; i < 4; i++)
                {
                    if (Manager.reference.pos[i].x == base.currentPos.x + 1 && Manager.reference.pos[i].y == base.currentPos.y)
                    {
                        if (Manager.reference.blocks[i].GetComponent<Block>().cantRight) base.cantRight = true;
                    }
                }

                if (!base.cantRight) base.currentPos.x++;
            }

            
        }
        

        this.gameObject.GetComponent<GridObject>().gridPosition = base.currentPos;


    }
}
