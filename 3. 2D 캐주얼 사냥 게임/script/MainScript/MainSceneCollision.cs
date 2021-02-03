using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.position.x >= 4500)
        {
            other.transform.Translate(-5760f, 0, 0);
        }
        else if(other.transform.position.x <= -2500)
        {
            other.transform.Translate(5760f, 0, 0);
        }
    }
}
