using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Color turnedColor;

    public bool isTurned;

    SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();

        if (isTurned)
        {
            Turn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Turn()
    {
        if (rend == null) rend = GetComponent<SpriteRenderer>();

        rend.color = turnedColor;
        isTurned = true;
    }

    public void TurnBack()
    {
        if (rend == null) rend = GetComponent<SpriteRenderer>();

        rend.color = Color.white;
        isTurned = false;
    }
}
