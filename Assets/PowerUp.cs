using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    public float xPos;
    public float yPos;
    public int powerUps;
    public Vector3 currentPos;
    public Vector3 red;
    public Vector3 green;
    public Vector3 yellow;
    public Vector3 blue;
    public Color currentColor;

    public void ValueSet()
    {
        red = new Vector3(210, 32, 66);
        green = new Vector3(163, 184, 8);
        yellow = new Vector3(243, 219, 44);
        blue = new Vector3(48, 196, 201);

        Random.Range(0, 4);

        currentPos = new Vector3(xPos, yPos, 0);
        transform.position = currentPos;
        UpdateColor();
    }

    public void UpdateColor()
    {
        switch (powerUps)
        {
            case 1:
                currentColor = new Color(0,0,0);
                break;
            case 2:
                currentColor = new Color(0, 0, 0);
                break;
            case 3:
                currentColor = new Color(0, 0, 0);
                break;
            default:
                break;
        }

        gameObject.GetComponent<SpriteRenderer>().color = currentColor;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Brick got into a collision with something");
        if (collision.gameObject.tag == "ball")
        {
            //Debug.Log("That object was a ball");
            collision.gameObject.GetComponent<Ball>()
        }
    }
}
