using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightAndLeftCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        //오브젝트가 가까이 다가와서 사라지는 부분은 ObjectControl.cs

        if (other.gameObject.CompareTag("Fog") || other.gameObject.CompareTag("BackGround"))
        {
            if (other.transform.position.x >= 15)
            {
                other.transform.Translate(-90f, 0, 0);
            }
            else
            {
                other.transform.Translate(90f, 0, 0);
            }
        }
        else
        {
            GameObject.Find("TreeObjectGenerator").GetComponent<TreeObjectGenerateScript>().EnterCollision();
            GameObject.Find("TreeObjectGenerator").GetComponent<TreeObjectGenerateScript>().DeleteObject(other.gameObject);
        }
    }
}
