using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    bool isLaunched = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isLaunched && collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rocket>().ContactGround(isLaunched);
            isLaunched = true;
        }

        else if (isLaunched && collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rocket>().ContactGround(isLaunched);
        }
    }
}
