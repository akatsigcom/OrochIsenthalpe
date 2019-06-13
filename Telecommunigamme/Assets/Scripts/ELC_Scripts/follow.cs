using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public GameObject player;
    private bool rotate = true;
 
    // Update is called once per frame
    void Update()

    {
        if (player.transform.position.x< this.transform.position.x && rotate)
        {
            this.transform.Rotate(0, -180, 0, Space.Self);
            rotate = false;
        }
        if (player.transform.position.x > this.transform.position.x && !rotate)
        {
            this.transform.Rotate(0, -180, 0, Space.Self);
            rotate = true;
        }

        this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1.58f, -1);
    }
}
