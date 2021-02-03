using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveInDungeon : MonoBehaviour
{
    public GameObject player;
    public float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        //this.player = GameObject.Find("Character");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 curPosition = transform.position;
        Vector3 playerPos = this.player.transform.position;

        curPosition.x = Mathf.Lerp(curPosition.x, playerPos.x, Time.deltaTime * speed);
        transform.position = curPosition;

    }

}
