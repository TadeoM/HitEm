using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    public float xPos;
    public float yPos;
    public int powerups;
    public Vector3 currentPos;
    public Vector3 green;
    public Vector3 purple;
    public Vector3 blue;
    public Color currentColor;
    // runs right before start
    private void Awake()
    {
        //ValueSet();
    }

    public void ValueSet()
    {
        green = new Vector3(0, 133, 23);
        purple = new Vector3(63, 0, 107);
        blue = new Vector3(27, 0, 166);

        powerups = Random.Range(1, 4);

        currentPos = new Vector3(xPos, yPos, 0);
        transform.position = currentPos;
        UpdateColor();
    }

    public void UpdateColor()
    {
        switch (powerups)
        {
            case -3:
            case -2:
            case -1:
            case 0:
                Destroy(this.gameObject);
                break;
            case 1:
                currentColor = new Color(green.x / 255f, green.y / 255f, green.z / 255f);
                break;
            case 2:
                currentColor = new Color(blue.x / 255f, blue.y / 255f, blue.z / 255f);
                break;
            case 3:
                currentColor = new Color(purple.x / 255f, purple.y / 255f, purple.z / 255f);
                break;
            default:
                break;
        }

        gameObject.GetComponent<SpriteRenderer>().color = currentColor;
    }
    
    public void DeleteThis(GameObject player)
    {
        switch (powerups)
        {
            case 1:
                player.transform.localScale = new Vector3(player.transform.localScale.x, player.transform.localScale.y * 1.2f, player.transform.localScale.z);
                break;
            case 2:
                player.GetComponent<Player>().speed *= 1.1f;
                break;
            case 3:
                GameObject playerTwo = GameObject.FindGameObjectWithTag("player2");
                playerTwo.GetComponent<Player>().speed *= 0.9f;
                break;
            case 4:
                break;
            default:
                break;
        }
        Destroy(gameObject);
    }
}
