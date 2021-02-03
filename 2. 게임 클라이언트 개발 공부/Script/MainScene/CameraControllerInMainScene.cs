using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerInMainScene : MonoBehaviour
{
    GameObject player;
    public float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 curPosition = transform.position;
        Vector3 playerPos = player.transform.position;
        
        curPosition.x = Mathf.Lerp(curPosition.x, playerPos.x, Time.deltaTime * speed);
        transform.position = curPosition;
        
    }
}
