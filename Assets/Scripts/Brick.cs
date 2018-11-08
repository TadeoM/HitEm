using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public float xPos;
    public float yPos;
    public int lifePoints;
    public Vector3 currentPos;
    public Vector3 red;
    public Vector3 green;
    public Vector3 yellow;
    public Vector3 blue;
    public Color currentColor;

    public void ValueSet() {
        red = new Vector3(210, 32, 66);
        green = new Vector3(163, 184, 8);
        yellow = new Vector3(243, 219, 44);
        blue = new Vector3(48, 196, 201);

        lifePoints = Random.Range(-2, 12);
        if (lifePoints < 4 && lifePoints > 0)
        {
            lifePoints = 4;
        }
        
        currentPos = new Vector3(xPos, yPos, 0);
        transform.position = currentPos;
        UpdateColor();
    }

    public void UpdateColor()
    {
        // from a smaller number to a larger number, add the number to the color you're starting at, and vice versa for a larger to smaller number
        if(lifePoints <= 0)
        {
            Destroy(gameObject);
        }
        else if (lifePoints > 0 && lifePoints <= 4)
        {
            // go to rbg 210, 32, 66
            currentColor = new Color((blue.x - 54f * (lifePoints - 4)) / 255f, (blue.y + 54.67f * (lifePoints - 4f)) / 255f, (blue.z + 45f * (lifePoints - 4)) / 255f);
        }
        else if (lifePoints > 4 && lifePoints <= 8)
        {
            // go to rbg 48, 196, 201
            currentColor = new Color((yellow.x + 65f * (lifePoints - 8f))/ 255f, (yellow.y + 7.67f * (lifePoints - 8f)) / 255f, (yellow.z - 52.33f * (lifePoints - 8f))/ 255f);
        }
        else if (lifePoints > 8 && lifePoints <= 12)
        {
            // start at rbg 163, 184, 8
            // go to rbg 243, 219, 44
            currentColor = new Color((green.x + 26.67f * (lifePoints - 12)) / 255f, (green.y + 11.67f * (lifePoints - 12)) / 255f, (green.z + 12 * (lifePoints - 12)) / 255f);
        }
        else
        {
            Debug.Log("What happened");
        }
        
        gameObject.GetComponent<SpriteRenderer>().color = currentColor;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Brick got into a collision with something");
        if (collision.gameObject.tag == "ball")
        {
            //Debug.Log("That object was a ball");
            UpdateLife();
        }
    }

    void UpdateLife()
    {
        lifePoints--;
        UpdateColor();
    }
}
