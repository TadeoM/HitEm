using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickGenerator : MonoBehaviour {

    public GameObject brick;
    public GameObject powerup;
    public GameObject[,] brickArray;
    public Vector2 mapSize;
    public Brick brickScript;

    // Use this for initialization
    public void Generate() {
        mapSize = new Vector2(5,6);
        brickArray = new GameObject[(int)mapSize.x, (int)mapSize.y];
		for (int x = 0; x < mapSize.x; x++)
        {
            for (int y = 0; y < mapSize.y; y++)
            {
                brickArray[x, y] = Instantiate(brick);
                brickScript = brickArray[x,y].GetComponent<Brick>();
                //Debug.Log(brickArray[x, y]);
                brickScript.xPos = 3.54f + (y * 3f);
                brickScript.yPos = 0.9f + (x * 3f);
                brickScript.ValueSet();

                if (brickScript.lifePoints < 0)
                {
                    //brickArray[x, y] = Instantiate(powerup);
                }
            }
        }
	}

}
