using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticky : Block
{

   
    Vector2Int playerPos;
    public GameObject player;

    public GameObject touching;


    Vector2Int prevPos;
    bool move;




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
        if (move)
        {
            Manager.reference.blockArray[prevPos.x, prevPos.y] = null;
            this.gameObject.GetComponent<GridObject>().gridPosition = base.currentPos;
            move = false;
        }
    }



    public bool CheckLeft()
    {
        if(currentPos.x == 1)
        {
            return false;
        } else
        {

            GameObject upblock = Manager.reference.blockArray[currentPos.x, currentPos.y - 1];
            GameObject downblock = Manager.reference.blockArray[currentPos.x, currentPos.y + 1];
            GameObject rightblock = Manager.reference.blockArray[currentPos.x + 1, currentPos.y];
            GameObject leftblock = Manager.reference.blockArray[currentPos.x - 1, currentPos.y];

                if(leftblock == null)
                {
                   if (rightblock == null || rightblock.CompareTag("clingy") || rightblock.CompareTag("wall") || rightblock.CompareTag("sticky"))
                   {
                            if(upblock == null)
                            {
                                        if (downblock == null)
                                        {
                                            return false;
                                        }  
                                        if(downblock.CompareTag("player"))
                                        {
                                            return downblock.GetComponent<Player>().CheckLeft();
                                        }
                                        if (downblock.CompareTag("smooth"))
                                        {
                                            return downblock.GetComponent<Smooth>().CheckLeft();
                                        }
                                        else if (downblock.CompareTag("sticky"))
                                        {
                                            return downblock.GetComponent<Sticky>().CheckLeft();
                                        }
                                        else if (downblock.CompareTag("clingy"))
                                        {
                                            return downblock.GetComponent<Clingy>().CheckLeft();
                                        }
                                        else
                                        {
                                            return false;
                                        }
                            }
                            if(upblock.CompareTag("clingy"))
                            {
                                bool temp = upblock.GetComponent<Clingy>().CheckLeft();
                                if(downblock == null)
                                {
                                    return temp;
                                }
                                if(downblock.CompareTag("smooth"))
                                {
                                   return temp || downblock.GetComponent<Smooth>().CheckLeft();
                                } else if(downblock.CompareTag("sticky"))
                                {
                                    return temp || downblock.GetComponent<Sticky>().CheckLeft();
                                } else if(downblock.CompareTag("clingy"))
                                {
                                    return temp || downblock.GetComponent<Clingy>().CheckLeft();
                                } else
                                {
                                    return temp;
                                }
                            }
                            else if(upblock.CompareTag("player"))
                            {
                                return upblock.GetComponent<Player>().CheckLeft();
                            }
                            else if (downblock.CompareTag("player"))
                            {
                                return downblock.GetComponent<Player>().CheckLeft();
                            }
                            else if (upblock.CompareTag("smooth"))
                            {
                                bool temp = upblock.GetComponent<Smooth>().CheckLeft();

                                if(downblock == null)
                                 {
                                     return temp;
                                 }
                                if (downblock.CompareTag("smooth"))
                                {
                                    return temp || downblock.GetComponent<Smooth>().CheckLeft();
                                }
                                else if (downblock.CompareTag("sticky"))
                                {
                                    return temp || downblock.GetComponent<Sticky>().CheckLeft();
                                }
                                else if (downblock.CompareTag("clingy"))
                                {
                                    return temp || downblock.GetComponent<Clingy>().CheckLeft();
                                }
                                else
                                {
                                    return temp;
                                }
                            }
                            else
                            {
                                return false;
                            }
                   }
                   else if (rightblock.CompareTag("player"))
                   {
                      return rightblock.GetComponent<Player>().CheckLeft();
                   }
                   else if (rightblock.CompareTag("smooth"))
                   {
                      return rightblock.GetComponent<Smooth>().CheckLeft();
                   }
                   else
                   {
                      return false;
                   }
                    
                }
            else if(leftblock.CompareTag("smooth"))
            {
                return leftblock.GetComponent<Smooth>().CheckLeft();    
            }
            else if (leftblock.CompareTag("player"))
            {
                return leftblock.GetComponent<Player>().CheckLeft();
            }
            else if(leftblock.CompareTag("clingy"))
                {
                    return false;
                } else if(leftblock.CompareTag("wall"))
                {
                    return false;
                } else //sticky
                {
                    return leftblock.GetComponent<Sticky>().CheckLeft();
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

            GameObject upblock = Manager.reference.blockArray[currentPos.x, currentPos.y - 1];
            GameObject downblock = Manager.reference.blockArray[currentPos.x, currentPos.y + 1];
            GameObject rightblock = Manager.reference.blockArray[currentPos.x + 1, currentPos.y];
            GameObject leftblock = Manager.reference.blockArray[currentPos.x - 1, currentPos.y];

            if (rightblock == null)
            {
                if (leftblock == null || leftblock.CompareTag("clingy") || leftblock.CompareTag("wall") || leftblock.CompareTag("sticky"))
                {
                    if (upblock == null)
                    {
                        if (downblock == null)
                        {
                            return false;
                        }
                        if (downblock.CompareTag("player"))
                        {
                            return downblock.GetComponent<Player>().CheckLeft();
                        }
                        if (downblock.CompareTag("smooth"))
                        {
                            return downblock.GetComponent<Smooth>().CheckLeft();
                        }
                        else if (downblock.CompareTag("sticky"))
                        {
                            return downblock.GetComponent<Sticky>().CheckLeft();
                        }
                        else if (downblock.CompareTag("clingy"))
                        {
                            return downblock.GetComponent<Clingy>().CheckLeft();
                        }
                        else
                        {
                            return false;
                        }
                    }
                    if (upblock.CompareTag("clingy"))
                    {
                        bool temp = upblock.GetComponent<Clingy>().CheckLeft();
                        if (downblock == null)
                        {
                            return temp;
                        }
                        if (downblock.CompareTag("smooth"))
                        {
                            return temp || downblock.GetComponent<Smooth>().CheckLeft();
                        }
                        else if (downblock.CompareTag("sticky"))
                        {
                            return temp || downblock.GetComponent<Sticky>().CheckLeft();
                        }
                        else if (downblock.CompareTag("clingy"))
                        {
                            return temp || downblock.GetComponent<Clingy>().CheckLeft();
                        }
                        else
                        {
                            return temp;
                        }
                    }
                    else if (upblock.CompareTag("player"))
                    {
                        return upblock.GetComponent<Player>().CheckLeft();
                    }
                    else if (downblock.CompareTag("player"))
                    {
                        return downblock.GetComponent<Player>().CheckLeft();
                    }
                    else if (upblock.CompareTag("smooth"))
                    {
                        bool temp = upblock.GetComponent<Smooth>().CheckLeft();

                        if (downblock == null)
                        {
                            return temp;
                        }
                        if (downblock.CompareTag("smooth"))
                        {
                            return temp || downblock.GetComponent<Smooth>().CheckLeft();
                        }
                        else if (downblock.CompareTag("sticky"))
                        {
                            return temp || downblock.GetComponent<Sticky>().CheckLeft();
                        }
                        else if (downblock.CompareTag("clingy"))
                        {
                            return temp || downblock.GetComponent<Clingy>().CheckLeft();
                        }
                        else
                        {
                            return temp;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (leftblock.CompareTag("player"))
                {
                    return leftblock.GetComponent<Player>().CheckLeft();
                }
                else if (leftblock.CompareTag("smooth"))
                {
                    return leftblock.GetComponent<Smooth>().CheckLeft();
                }
                else
                {
                    return false;
                }

            }
            else if (rightblock.CompareTag("smooth"))
            {
                return rightblock.GetComponent<Smooth>().CheckLeft();
            }
            else if (rightblock.CompareTag("player"))
            {
                return rightblock.GetComponent<Player>().CheckLeft();
            }
            else if (rightblock.CompareTag("clingy"))
            {
                return false;
            }
            else if (rightblock.CompareTag("wall"))
            {
                return false;
            }
            else //sticky
            {
                return rightblock.GetComponent<Sticky>().CheckLeft();
            }


        }
    }

    private bool CheckUp()
    {
        return false;
    }

    private bool CheckDown()
    {
        return false;
    }





    private void CheckIfMovable()
    {
        int count = 0;
        for (int i = 0; i < 5; i++)
        {
            if (((Manager.reference.pos[i].x == base.currentPos.x + 1 && Manager.reference.pos[i].y == base.currentPos.y)
            || (Manager.reference.pos[i].x == base.currentPos.x && Manager.reference.pos[i].y == base.currentPos.y + 1)
            || (Manager.reference.pos[i].x == base.currentPos.x - 1 && Manager.reference.pos[i].y == base.currentPos.y)
            || (Manager.reference.pos[i].x == base.currentPos.x && Manager.reference.pos[i].y == base.currentPos.y - 1))
            && Manager.reference.touched[i])
            {
                base.touchedByPlayer = true;
                count++;
                Debug.Log("touched!");
            }
        }

        if (count == 0)
        {
            base.touchedByPlayer = false;
        }

    }

    private void CheckIfTouched()
    {
        if (((playerPos.x == base.currentPos.x + 1 && playerPos.y == base.currentPos.y)
           || (playerPos.x == base.currentPos.x && playerPos.y == base.currentPos.y + 1)
           || (playerPos.x == base.currentPos.x - 1 && playerPos.y == base.currentPos.y)
           || (playerPos.x == base.currentPos.x && playerPos.y == base.currentPos.y - 1)))
        {

            touchedByPlayer = true;

        } else
        {
            touchedByPlayer = false;
        }
    }


}
