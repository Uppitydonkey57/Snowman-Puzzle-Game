using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Threading.Tasks;
using System;

public class Moveable : MonoBehaviour
{
    protected Sequence sequence;

    protected bool canMove = true;

    protected GameMaster gm;

    private void Awake()
    {
        gm = FindObjectOfType<GameMaster>();
    }
    
    public GameObject IsBlocked(Vector2 direction, LayerMask layerMask)
    {
        Collider2D obstacleCheck = Physics2D.OverlapPoint((Vector2)transform.position + (direction * gm.TileSize), layerMask);

        if (obstacleCheck != null)
        {
            return obstacleCheck.gameObject;
        }

        return null;
    }

    public async void Move(Vector2 direction)
    {
        canMove = false;

        sequence.Append(transform.DOMove(transform.position + (Vector3)direction * gm.TileSize, gm.TurnSpeed));

        await Task.Delay(TimeSpan.FromSeconds(gm.TurnSpeed));
        
        canMove = true;
    }
}
