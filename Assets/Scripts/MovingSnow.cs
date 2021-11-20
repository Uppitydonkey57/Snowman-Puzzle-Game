using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSnow : Moveable
{
    public Vector2 direction;

    GameMaster gm;

    public LayerMask snowLayer;
    public LayerMask obstacleLayer;

    // Start is called before the first frame update
    void Start()
    {
        PlayerController.OnTurn += Turn;

        gm = FindObjectOfType<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject tileObject = IsBlocked(Vector2.zero, snowLayer);

        Tile tile = null;

        if (tileObject != null)
        {
            tile = tileObject.GetComponent<Tile>();
        }

        if (tile != null)
        {
            if (tile.isTurned)
                tile.TurnBack();
        }
    }

    void Turn()
    {
        Move(direction);

        if (IsBlocked(direction, obstacleLayer) != null)
        {
            Destroy(gameObject);
        }
    }
}
