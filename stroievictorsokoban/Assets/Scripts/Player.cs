using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class Player : Block
{

    private Vector2Int prevPos;
    private bool move;

    // Start is called before the first frame update
    void Start()
    {
        base.currentPos = this.gameObject.GetComponent<GridObject>().gridPosition;
        base.touchedByPlayer = true;
    }


    // Update is called once per frame
    void Update()
    {
        base.currentPos = this.gameObject.GetComponent<GridObject>().gridPosition;


        if (Input.GetKeyDown(KeyCode.W))
        {

            canUp = CheckUp();
            //canUp = true;

            prevPos = base.currentPos;
            if (base.canUp)  base.currentPos.y--;
            move = true;

        }

        if (Input.GetKeyDown(KeyCode.S) )
        {


            canDown = CheckDown();

            //canDown = true;
            prevPos = base.currentPos;
            if (base.canDown) base.currentPos.y++;
            move = true;
            
        }

        if (Input.GetKeyDown(KeyCode.A) )
        {

            canLeft = CheckLeft();

            //canLeft = true;
            prevPos = base.currentPos;
            if (base.canLeft) base.currentPos.x--;
            move = true;
            //prevPos = currentPos;
        }

        if (Input.GetKeyDown(KeyCode.D) )
        {

            canRight = CheckRight();

            //canRight = true;
            prevPos= base.currentPos;
            if (base.canRight) base.currentPos.x++;
            move = true;

            //prevPos = currentPos;
        }

        
        
    }

    private void LateUpdate()
    {
        //Maybe put this.gameObject.GetComponent<GridObject>().gridPosition = base.currentPos; here

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
            GameObject block = Manager.reference.blockArray[currentPos.x, currentPos.y - 1];


            if (block == null)
            {
                return true;

            }
            else
            {
                if (block.CompareTag("clingy"))
                {
                    return false;
                }
                else if (block.CompareTag("smooth"))
                {
                    return block.GetComponent<Smooth>().CheckUp();
                }
                else if (block.CompareTag("sticky"))
                {
                    return block.GetComponent<Block>().canUp;
                }
                else if (block.CompareTag("wall"))
                {
                    return false;
                }
                else {
                    return false;
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
            GameObject block = Manager.reference.blockArray[currentPos.x, currentPos.y + 1];


            if (block == null)
            {
                return true;

            }
            else
            {
                if (block.CompareTag("clingy"))
                {
                    return false;
                }
                else if (block.CompareTag("smooth"))
                {
                    return block.GetComponent<Smooth>().CheckDown();
                }
                else if (block.CompareTag("sticky"))
                {
                    return block.GetComponent<Sticky>().CheckDown();
                }
                else if (block.CompareTag("wall"))
                {
                    return false;
                }
                else
                {
                    return false;
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
            GameObject block = Manager.reference.blockArray[currentPos.x - 1, currentPos.y];


            if (block == null)
            {
                return true;

            }
            else
            {
                if (block.CompareTag("clingy"))
                {
                    return false;
                }
                else if (block.CompareTag("smooth"))
                {
                    return block.GetComponent<Smooth>().CheckLeft();
                }
                else if (block.CompareTag("sticky"))
                {
                    return block.GetComponent<Sticky>().CheckLeft();
                }
                else if (block.CompareTag("wall"))
                {
                    return false;
                }
                else
                {
                    return false;
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
            GameObject block = Manager.reference.blockArray[currentPos.x + 1, currentPos.y];


            if (block == null)
            {
                return true;

            }
            else
            {
                if (block.CompareTag("clingy"))
                {
                    return false;
                }
                else if (block.CompareTag("smooth"))
                {
                    return block.GetComponent<Smooth>().CheckRight();
                }
                else if (block.CompareTag("sticky"))
                {
                    return block.GetComponent<Sticky>().CheckRight();
                }
                else if (block.CompareTag("wall"))
                {
                    return false;
                }
                else
                {
                    return false;
                }
            }

        }
    }
       

}
