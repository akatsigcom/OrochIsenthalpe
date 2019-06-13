using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class clickmouse : MonoBehaviour
{
    Vector3 mouspos;
    public Tilemap grid;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouspos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
            mouspos = Camera.main.ScreenToWorldPoint(mouspos);
            GridLayout gridLayout = grid.GetComponentInParent<GridLayout>();
            Vector3Int cellPosition = gridLayout.WorldToCell(mouspos);

            if (!grid.HasTile(cellPosition))
            {
               
                this.transform.position = mouspos;
            }
        }
    }
}
