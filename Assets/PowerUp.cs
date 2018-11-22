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
    // runs right before start
    private void Awake()
    {
        ValueSet();
    }

    public void ValueSet()
    {
        red = new Vector3(210, 32, 66);
        green = new Vector3(163, 184, 8);
        yellow = new Vector3(243, 219, 44);
        blue = new Vector3(48, 196, 201);

        Random.Range(-3, 4);

        currentPos = new Vector3(xPos, yPos, 0);
        transform.position = currentPos;
        UpdateColor();
    }

    public void UpdateColor()
    {
        switch (powerUps)
        {
            case -3:
            case -2:
            case -1:
            case 0:
                Destroy(this.gameObject);
                break;
            case 1:
                currentColor = new Color(red.x, red.y, red.z);
                break;
            case 2:
                currentColor = new Color(green.x, green.y, green.z);
                break;
            case 3:
                currentColor = new Color(yellow.x, yellow.y, yellow.z);
                break;
            case 4:
                currentColor = new Color(blue.x, blue.y, blue.z);
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
            collision.gameObject.GetComponent<Ball>();
        }
    }
}
