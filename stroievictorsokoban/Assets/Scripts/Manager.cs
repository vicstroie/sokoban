using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject player;
    public GameObject sticky;
    public GameObject smooth;
    public GameObject clingy;
    public GameObject wall;

    public GameObject[] blocks;
    public GameObject[,] blockArray;

    public Vector2Int[] pos;
    public bool[] touched;

    public static Manager reference;




    // Start is called before the first frame update
    void Start()
    {
        reference = this;

        blocks = new GameObject[5];
        blocks[0] = player;
        blocks[1] = sticky;
        blocks[2] = smooth;
        blocks[3] = clingy;
        blocks[4] = wall;

        pos = new Vector2Int[5];
        touched = new bool[5];
        blockArray = new GameObject[12,7];


        for(int i = 0; i < 12; i++)
        {
            for(int j = 0; j < 7; j++)
            {
                blockArray[i, j] = null;
            }
        }




        /*
        GameObject.Instantiate(player);
        player.GetComponent<GridObject>().gridPosition = new Vector2Int(1, 1);

        GameObject.Instantiate(wall);
        wall.GetComponent<GridObject>().gridPosition = new Vector2Int(2, 1);

        GameObject.Instantiate(sticky);
        sticky.GetComponent<GridObject>().gridPosition = new Vector2Int(3, 1);

        GameObject.Instantiate(smooth);
        smooth.GetComponent<GridObject>().gridPosition = new Vector2Int(4, 1);

        GameObject.Instantiate(clingy);
        clingy.GetComponent<GridObject>().gridPosition = new Vector2Int(5, 1);
        */
    }

    // Update is called once per frame
    void Update()
    {
        


        for(int i = 0; i < blocks.Length; i++)
        {
            //pos[i] = new Vector2Int(blocks[i].GetComponent<GridObject>().gridPosition.x, blocks[i].GetComponent<GridObject>().gridPosition.y);
            blockArray[blocks[i].GetComponent<GridObject>().gridPosition.x, blocks[i].GetComponent<GridObject>().gridPosition.y] = blocks[i];
            //touched[i] = blocks[i].GetComponent<Block>().touchedByPlayer;

        }

        /*
        pos[0] = new Vector2Int(blocks[0].GetComponent<Block>().currentPos.x, blocks[0].GetComponent<Block>().currentPos.y);
        pos[1] = new Vector2Int(blocks[1].GetComponent<Block>().currentPos.x, blocks[1].GetComponent<Block>().currentPos.y);
        pos[2] = new Vector2Int(blocks[2].GetComponent<Block>().currentPos.x, blocks[2].GetComponent<Block>().currentPos.y);
        pos[3] = new Vector2Int(blocks[3].GetComponent<Block>().currentPos.x, blocks[3].GetComponent<Block>().currentPos.y);
        
        
        
        touched[1] = blocks[1].GetComponent<Block>().touchedByPlayer;
        touched[2] = blocks[2].GetComponent<Block>().touchedByPlayer;
        touched[3] = blocks[3].GetComponent<Block>().touchedByPlayer;
        */
    }






}
