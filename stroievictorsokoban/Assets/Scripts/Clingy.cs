using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clingy : Block
{
   
    Vector2Int playerPos;
    public GameObject player;

    Vector2Int prevPos;
    bool move;


    // Start is called before the first frame update
    void Start()
    {
        base.touchedByPlayer = false;
        base.currentPos = this.gameObject.GetComponent<GridObject>().gridPosition;

        canDown = false;
        canUp = false;
        canRight = false;
        canLeft = false;
        //player = Manager.reference.player;
    }

    // Update is called once per frame
    void Update()
    {



        base.currentPos = this.gameObject.GetComponent<GridObject>().gridPosition;

        if (Input.GetKeyDown(KeyCode.W))
        {

            canUp = CheckUp();

            prevPos = base.currentPos;
            if (base.canUp) base.currentPos.y--;
            move = true;

        }

        if (Input.GetKeyDown(KeyCode.S))
        {


            canDown = CheckDown();

            prevPos = base.currentPos;
            if (base.canDown) base.currentPos.y++;
            move = true;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {

            canLeft = CheckLeft();

            prevPos = base.currentPos;
            if (base.canLeft) base.currentPos.x--;
            move = true;

        }

        if (Input.GetKeyDown(KeyCode.D))
        {

            canRight = CheckRight();

            prevPos = base.currentPos;
            if (base.canRight) base.currentPos.x++;
            move = true;


        }


        

    }


    private void LateUpdate()
    {
        if(move)
        {
            Manager.reference.blockArray[prevPos.x, prevPos.y] = null;
            this.gameObject.GetComponent<GridObject>().gridPosition = base.currentPos;
            move = false;
        }
    }


    public bool CheckUp()
    {
        if (currentPos.y == 1)
        {
            return false;
        }
        else
        {
            GameObject upblock = Manager.reference.blockArray[currentPos.x, currentPos.y - 1];


            if (upblock == null)
            {
                return false;

            }
            else
            {
                if (upblock.CompareTag("smooth"))
                {
                    return false;
                }
                else if (upblock.CompareTag("player"))
                {
                    return upblock.GetComponent<Player>().CheckUp();
                }
                else if (upblock.CompareTag("sticky"))
                {
                    return upblock.GetComponent<Block>().canUp;
                }
                else if (upblock.CompareTag("wall"))
                {
                    return false;
                }
                else //clingy
                {
                    return upblock.GetComponent<Clingy>().CheckUp();
                }
            }

        }
    }





    public bool CheckDown()
    {
        if (currentPos.y == 5)
        {
            return false;
        }
        else
        {
            GameObject downblock = Manager.reference.blockArray[currentPos.x, currentPos.y + 1];


            if (downblock == null)
            {
                return false;

            }
            else
            {
                if (downblock.CompareTag("smooth"))
                {
                    return false;
                }
                else if (downblock.CompareTag("player"))
                {
                    return downblock.GetComponent<Player>().CheckDown();
                }
                else if (downblock.CompareTag("sticky"))
                {
                    return downblock.GetComponent<Block>().canDown;
                }
                else if (downblock.CompareTag("wall"))
                {
                    return false;
                }
                else //clingy
                {
                    return downblock.GetComponent<Clingy>().CheckDown();
                }
            }

        }
    }




    public bool CheckLeft()
    {
        if (currentPos.x == 1)
        {
            return false;
        }
        else
        {

            GameObject leftblock = Manager.reference.blockArray[currentPos.x - 1, currentPos.y];


            if (leftblock == null)
            {
                return false;
            }
            else
            {
                if (leftblock.CompareTag("smooth"))
                {
                    return false;
                }
                else if (leftblock.CompareTag("player"))
                {
                    return leftblock.GetComponent<Player>().CheckLeft();
                }
                else if (leftblock.CompareTag("sticky"))
                {
                    return leftblock.GetComponent<Block>().canLeft;
                }
                else if (leftblock.CompareTag("wall"))
                {
                    return false;
                }
                else //clingy
                {
                    return leftblock.GetComponent<Clingy>().CheckLeft();
                }
            }

        }
    }


    public bool CheckRight()
    {
        if (currentPos.x == 10)
        {
            return false;
        }
        else
        {
            GameObject rightblock = Manager.reference.blockArray[currentPos.x + 1, currentPos.y];


            if (rightblock == null)
            {
                return false;
            }
            else
            {
                if (rightblock.CompareTag("smooth"))
                {
                    return false;
                }
                else if (rightblock.CompareTag("player"))
                {
                    return rightblock.GetComponent<Player>().CheckRight();
                }
                else if (rightblock.CompareTag("sticky"))
                {
                    return rightblock.GetComponent<Block>().canRight;
                }
                else if (rightblock.CompareTag("wall"))
                {
                    return false;
                }
                else //clingy
                {
                    return rightblock.GetComponent<Clingy>().CheckRight();
                }
            }

        }
    }

}
