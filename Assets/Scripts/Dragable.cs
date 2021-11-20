using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragable : MonoBehaviour
{
    bool isClicked = false;

    Vector3 mouseOffset;

    Vector3 prevMousePos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (isClicked)
        {
            mouseOffset = mousePos - prevMousePos;

            transform.position += mouseOffset;
        }

        prevMousePos = mousePos;
    }

    private void OnMouseDown()
    {
        isClicked = true;
    }

    private void OnMouseUp()
    {
        isClicked = false;
    }
}
