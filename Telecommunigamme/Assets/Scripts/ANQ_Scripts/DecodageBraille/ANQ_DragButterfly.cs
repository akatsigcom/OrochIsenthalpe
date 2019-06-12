using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANQ_DragButterfly : MonoBehaviour
{
    private float startPosX;
    private float startPosY;
    private bool isBeingHeld = false;

    int maxDist = ANQ_GenerateBigButterfly.bigButterflyNumber; 

    void Update()
    {   if (isBeingHeld)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            if (mousePos.x - startPosX >= -maxDist & mousePos.x - startPosX <= maxDist)
            {
                this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, 0, 0);
            }
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

        }


        isBeingHeld = true;
    }

    private void OnMouseUp()
    {
        isBeingHeld = false;
    }
}
