using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Threading.Tasks;
using System;

public class PlayerController : Moveable
{
    public LayerMask obstacleLayer;

    public LayerMask pushLayer;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameMaster>();

        sequence = DOTween.Sequence();
    }

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (canMove)
        {
            if (horizontal != 0 || vertical != 0)
            {
                if (Input.GetButtonDown("Horizontal"))
                {
                    MoveDirection(new Vector2(horizontal, 0));
                }

                if (Input.GetButtonDown("Vertical"))
                {
                    MoveDirection(new Vector2(0, vertical));
                }
            }
        }
    }

    void MoveDirection(Vector2 direction)
    {
        GameObject collisionCheck = IsBlocked(direction, obstacleLayer);

        GameObject pushCheck = IsBlocked(direction, pushLayer);

        if (collisionCheck == null)
        {
            if (pushCheck == null)
            {
                Move(direction);
            }
            else
            {
                Snowball pushObject = pushCheck.GetComponent<Snowball>();

                if (pushObject != null)
                {
                    if (pushObject.IsBlocked(direction, obstacleLayer) == null)
                    {
                        Move(direction);
                        pushObject.Push(direction);
                    }
                }
            }
        }
    }
}
