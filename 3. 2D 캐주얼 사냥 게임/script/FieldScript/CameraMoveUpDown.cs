using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMoveUpDown : MonoBehaviour
{
    public float Speed = 0f;
    private Vector2 prePos;
    private Vector2 nowPos;
	private Vector2 movePos;
    private Vector3 shakePos;

    private bool canMove = true;

    private int SwipeFingerID = 100;

    private int StartTouch = 0;

    public GameObject BackGround;
    public GameObject Object;


    void MoveLimit()
	{
		Vector3 temp;   
		temp.x = transform.position.x;
		temp.y = Mathf.Clamp(transform.position.y, -2.2f, 0.9f);
		temp.z = transform.position.z;
		transform.position = temp;
	}

    public IEnumerator MoveShake()
    {
        if (canMove)
        {
            canMove = false;
            shakePos.Set(BackGround.transform.position.x, 1, BackGround.transform.position.z);

            //상하 이동시 흔들거림(위치는 그대로)
            if (shakePos.y != 0)
            {
                Vector3 initcamerPos = BackGround.transform.position;

                Vector3 camerPos = BackGround.transform.position;

                Vector3 initobjectPos = Object.transform.position;

                Vector3 objectPos = Object.transform.position;

                for (int i = 0; i < 10; i++)
                {
                    camerPos.y += 0.005f;
                    objectPos.y += 0.005f;
                    yield return new WaitForSeconds(0.02f);
                    BackGround.transform.position = camerPos;
                    Object.transform.position = objectPos;
                }
                for (int i = 0; i < 10; i++)
                {
                    camerPos.y -= 0.005f;
                    objectPos.y -= 0.005f;
                    yield return new WaitForSeconds(0.02f);
                    BackGround.transform.position = camerPos;
                    Object.transform.position = objectPos;
                }
                BackGround.transform.position = initcamerPos;
                Object.transform.position = initobjectPos;

            }
            canMove = true;
        }
    }


    void CheckSwipeFingerID()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (!EventSystem.current.IsPointerOverGameObject(i))
            {
                SwipeFingerID = Input.GetTouch(i).fingerId;
            }
        }
    }

    void MoveCamera(int TouchIndex)
    {
        Touch touch = Input.GetTouch(TouchIndex);

        if (touch.fingerId == SwipeFingerID)
        {
            if (touch.phase == TouchPhase.Began)
            {
                prePos.y = touch.position.y - touch.deltaPosition.y;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                nowPos.y = touch.position.y - touch.deltaPosition.y;

                movePos.y = (prePos.y - nowPos.y) * Speed * Time.deltaTime;

                transform.Translate(movePos);

                MoveLimit();

                prePos.y = touch.position.y - touch.deltaPosition.y;
            }
        }
    }

    void Update()
    {
        if (StartTouch != Input.touchCount)         //터치 
        {
            if (StartTouch < Input.touchCount)      //터치 발생함
            {
                CheckSwipeFingerID();
            }
            StartTouch = Input.touchCount;

            if (Input.touchCount == 0)
            {
                SwipeFingerID = 100;
            }
        }


        for (int i = 0; i < Input.touchCount; i++)
        {
            MoveCamera(i);
        }
    }
}
