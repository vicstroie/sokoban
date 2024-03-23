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
        //nextPos = currentPos;
    }


    // Update is called once per frame
    void Update()
    {
        base.currentPos = this.gameObject.GetComponent<GridObject>().gridPosition;


        if (Input.GetKeyDown(KeyCode.W))
        {


            if (CheckUp())
            {
                nextPos.y = currentPos.y - 1;
                nextPos.x = currentPos.x;
                move = true;
            }

        }

        if (Input.GetKeyDown(KeyCode.S))
        {

            if (CheckDown())
            {
               
                nextPos.y = currentPos.y + 1;
                nextPos.x = currentPos.x;
                move = true;
            }


        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (CheckLeft())
            {

                nextPos.x = currentPos.x - 1;
                nextPos.y = currentPos.y;
                move = true;
            }


        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (CheckRight())
            {
                nextPos.x = currentPos.x + 1;
                nextPos.y = currentPos.y;
                move = true;
            }

        }


    }

    private void LateUpdate()
    {

        if(move)
        {
            Manager.reference.blockArray[currentPos.x, currentPos.y] = null;
            currentPos = nextPos;
            this.gameObject.GetComponent<GridObject>().gridPosition = currentPos;
            nextPos = Vector2Int.zero;
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
                    return block.GetComponent<Sticky>().CheckUp();
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
