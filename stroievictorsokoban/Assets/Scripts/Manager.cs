using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject player;
    GameObject[] stickys;
    GameObject[] smooths;
    GameObject[] clingys;
    GameObject[] walls;

    public static Manager reference;




    // Start is called before the first frame update
    void Start()
    {
        reference = this;

        player = GameObject.FindGameObjectWithTag("player");
        stickys = GameObject.FindGameObjectsWithTag("sticky");
        smooths = GameObject.FindGameObjectsWithTag("smooth");
        clingys = GameObject.FindGameObjectsWithTag("clingy");
        walls = GameObject.FindGameObjectsWithTag("wall");






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
        
    }






}
