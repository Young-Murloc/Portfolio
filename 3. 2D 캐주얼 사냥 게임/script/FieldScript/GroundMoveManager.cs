using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GroundMoveManager : MonoBehaviour
{
	public GameObject[] GList1;
	public GameObject[] GList2;
	public GameObject[] GList3;
	public GameObject[] GList4;
	public GameObject[] GList5;
	public GameObject[] GList6;

	public float[] Speed;

	private Vector2 prePos;
	private Vector2 nowPos;
	private Vector2 movePos;

	private int SwipeFingerID = 100;

	private int StartTouch = 0;

	public float Vector;
	public GameObject[] cardinalPoint = new GameObject[4];

	void CheckSwipeFingerID()
	{
		for(int i=0; i<Input.touchCount; i++)
        {
            if (!EventSystem.current.IsPointerOverGameObject(i))
            {
				SwipeFingerID = Input.GetTouch(i).fingerId;
            }
        }
	}

	void MoveTouch(int touchIndex)
	{
		Touch touch = Input.GetTouch(touchIndex);

		if (touch.fingerId == SwipeFingerID)
		{
			if (touch.phase == TouchPhase.Began)
			{
				prePos.x = touch.position.x - touch.deltaPosition.x;
			}
			else if (touch.phase == TouchPhase.Moved)
			{
				nowPos.x = touch.position.x - touch.deltaPosition.x;

				movePos.x = -(prePos.x - nowPos.x) * Time.deltaTime;

				prePos.x = touch.position.x - touch.deltaPosition.x;

				for (int i = 0; i < GList1.Length; i++)
				{
					GList1[i].transform.Translate(movePos * Speed[0]);
				}

				for (int i = 0; i < GList2.Length; i++)
				{
					GList2[i].transform.Translate(movePos * Speed[1]);
				}

				for (int i = 0; i < GList3.Length; i++)
				{
					GList3[i].transform.Translate(movePos * Speed[2]);
				}

				for (int i = 0; i < GList4.Length; i++)
				{
					GList4[i].transform.Translate(movePos * Speed[3]);
				}

				for (int i = 0; i < GList5.Length; i++)
				{
					GList5[i].transform.Translate(movePos * Speed[4]);
				}

				for (int i = 0; i < GList6.Length; i++)
				{
					GList6[i].transform.Translate(movePos * Speed[5]);
				}

				GameObject.Find("TreeObjectGenerator").GetComponent<TreeObjectGenerateScript>().ObjectMove(movePos * Speed[5]);
				GameObject.Find("AnimalObjectGenerator").GetComponent<AnimalObjectGenerateScript>().AnimalObjectMove(movePos * Speed[5]);


				ChangeCardinalPoint(movePos);
			}
		}
	}

	void ChangeCardinalPoint(Vector2 MovePos)
    {
		for(int i=0; i<4; i++)
        {
			cardinalPoint[i].transform.position += new Vector3(Vector * Time.deltaTime * MovePos.x, 0, 0);
        }

		for (int i = 0; i < 4; i++)
		{
			if (cardinalPoint[i].transform.position.x >= 740 && cardinalPoint[i].transform.position.x <= 1180)
				cardinalPoint[i].SetActive(true);
			else
				cardinalPoint[i].SetActive(false);
		}

		for (int i = 0; i < 4; i++)
		{
			if (cardinalPoint[i].transform.position.x > 2060)
				cardinalPoint[i].transform.position = new Vector3(300, 930, 0);
			if (cardinalPoint[i].transform.position.x < -140)
				cardinalPoint[i].transform.position = new Vector3(1620, 930, 0);
		}
	}

    private void Start()
    {
		Vector2 temp = new Vector2(0, 0);
		ChangeCardinalPoint(temp);
    }

    void Update()
	{
		if(StartTouch != Input.touchCount)			//터치 
        {
			if(StartTouch < Input.touchCount)		//터치 발생함
            {
				CheckSwipeFingerID();
            }
			StartTouch = Input.touchCount;

			if(Input.touchCount == 0)
            {
				SwipeFingerID = 100;
            }
        }


		for(int i=0; i<Input.touchCount; i++)
        {
			MoveTouch(i);

        }
	}
}