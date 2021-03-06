using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public delegate void Won();
    public static event Won OnWin;

    public int sizeCap;
    public int sizeMin;

    [SerializeField] private GameObject head;

    public void WinCheck(Snowball snowball)
    {
        if (snowball.increases < sizeCap && snowball.increases > sizeMin)
        {
            snowball.gameObject.SetActive(false);

            head.SetActive(true);

            OnWin();
        }
    }
}
