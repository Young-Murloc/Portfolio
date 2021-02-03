using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeObjectGenerateScript : MonoBehaviour
{
    public GameObject Tree01;
    public GameObject Tree02;

    public GameObject BackGroundObject;
    public GameObject AnimalObject;
    public GameObject TempObject;

    public GameObject PlayerPos;

    public GameObject[] BackGround;

    private GameObject tempObj;
    public GameObject Object;

    private float minX, maxX, minY, maxY;

    private int[] Tree = new int[3];

    float height;
    private Renderer render;

    int rand;

    private bool isEnterCollision = false;

    public void EnterCollision()
    {
        if (isEnterCollision == false)
        {
            isEnterCollision = true;
        }
        else
        {
            isEnterCollision = false;
        }
    }

    public void DeleteObject(GameObject Obj)     //오브젝트 삭제
    {
        Obj.transform.parent = TempObject.transform;
        Destroy(Obj);
        TreeObjectGenerate(Obj);
    }

    public void CheckObjectPosition()
    {
        minX = BackGround[0].transform.position.x;
        maxX = BackGround[0].transform.position.x;

        Tree[0] = 0;
        Tree[1] = 0;
        Tree[2] = 0;

        for (int i = 1; i < 3; i++)
        {
            if (maxX < BackGround[i].transform.position.x)
            {
                maxX = BackGround[i].transform.position.x;
            }
            else

            if (minX > BackGround[i].transform.position.x)
            {
                minX = BackGround[i].transform.position.x;
            }
        }

        minX += 15f;
        maxX -= 15f;

        int BGOchildCount = BackGroundObject.transform.childCount;
        int AOchildCount = AnimalObject.transform.childCount;

        for (int i = 0; i < BGOchildCount; i++)
        {
            if (BackGroundObject.transform.GetChild(i).position.x < minX)
            {
                Tree[0]++;
            }
            else if (BackGroundObject.transform.GetChild(i).position.x < maxX)
            {
                Tree[1]++;
            }
            else
            {
                Tree[2]++;
            }
        }
    }

    public void CreateObject(GameObject gameObj, float minY, float maxY, float minX, float maxX)     //오브젝트 생성
    {
        tempObj = Instantiate(gameObj) as GameObject;

        if (tempObj.CompareTag("Tree01") || tempObj.CompareTag("Tree02"))             //수정 필요
        {
            tempObj.transform.parent = BackGroundObject.transform;
        }
        else
        {
            tempObj.transform.parent = AnimalObject.transform;
        }


        float tempX = Random.Range(minX, maxX);
        float tempY = Random.Range(minY, maxY);

        /*
        int a = (int)(tempY * 2685) * -1;
        float size = 0.2f;
        if (tempY > 0f)
        {
            size = 0.099f;
        }
        else
        {
            for (int i = 0; i < a / 2; i++)
            {
                float sizeGap = size * size * 0.003f;
                size += sizeGap;
            }
        }*/

        tempObj.transform.localScale = new Vector3(tempY, tempY, 0);

        height = tempObj.GetComponent<SpriteRenderer>().bounds.extents.y;

        tempObj.transform.position = new Vector3(tempX, 0.17f+ Object.transform.position.y, (-height + 0.17f));

        //밝기 조절
        render = tempObj.transform.GetComponent<Renderer>();
        if (tempObj.transform.localScale.x <= 0.13f)
        {
            render.material.color = new Color(1, 1, 1, 0);
        }
        else if (tempObj.transform.localScale.x >= 2.3f)
        {
            render.material.color = new Color(1, 1, 1, 0);
        }
        //Debug.Log("y 좌표 : "+tempObj.transform.position.y + "  ///   사이즈  : " + tempObj.transform.localScale.x);
    }

    public void ObjectMove(Vector2 MovePos)
    {
        int BGOchildCount = BackGroundObject.transform.childCount;

        for (int i = 0; i < BGOchildCount; i++)
        {
            BackGroundObject.transform.GetChild(i).transform.Translate(MovePos);
        }
    }

    private void TreeObjectGenerate(GameObject Obj)
    {
        int BGOchildCount = BackGroundObject.transform.childCount;

        //필드에 필요한 오브젝트 수 저장하는 변수
        int[] BGO = new int[3];

        if (BGOchildCount == 0) //베이스 캠프에서 떠나고 첫 필드 조우시 생성되는 오브젝트들, 동물 제외하고 나무들만 재생성
        {
            rand = 0;
            float creat_Min_PosY = 0.2f;
            float creat_Max_PosY = 1.4f;

            //float creat_Min_PosY = 2.4f;
            //float creat_Max_PosY = 2.4f;

            for (int i = 0; i < 3; i++)
            {
                rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    CreateObject(Tree01, creat_Min_PosY, creat_Max_PosY, -45f, -15f);
                }
                else
                {
                    CreateObject(Tree02, creat_Min_PosY, creat_Max_PosY, -45f, -15f);
                }
            }

            for (int i = 0; i < 3; i++)
            {
                rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    CreateObject(Tree01, creat_Min_PosY, creat_Max_PosY, -15f, 15f);
                }
                else
                {
                    CreateObject(Tree02, creat_Min_PosY, creat_Max_PosY, -15f, 15f);
                }
            }

            for (int i = 0; i < 3; i++)
            {
                rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    CreateObject(Tree01, creat_Min_PosY, creat_Max_PosY, 15f, 45f);
                }
                else
                {
                    CreateObject(Tree02, creat_Min_PosY, creat_Max_PosY, 15f, 45f);
                }
            }

            return;
        }

        //맵, 주인공 위치 비교후 필드뷰에 들어가야할 오브젝트 개수 재설정
        if (true) //BaseCamp 주변 **값 수정 필요**
        {
            //나무 총 15개
            BGO[0] = 3;
            BGO[1] = 3;
            BGO[2] = 3;
        }

        CheckObjectPosition();

        float asd = 2.4f;
        float sdd = 2.4f;
        float asd1 = 0.12f;
        float sdd1 = 0.12f;
        //생성될 오브젝트 정하기

        if ((tempObj.CompareTag("Tree01") || tempObj.CompareTag("Tree02")) && Obj.transform.position.x > 45f && isEnterCollision == true)         //오른쪽
        {
            minY = -0.3f;
            maxY = 0f;
            minX = -15f;
            maxX = -5f;

            rand = Random.Range(0, 2);

            if (rand == 0)
            {
                CreateObject(Tree01, minY, maxY, minX, maxX);
            }
            else
            {
                CreateObject(Tree02, minY, maxY, minX, maxX);
            }

            isEnterCollision = false;
        }
        else if ((tempObj.CompareTag("Tree01") || tempObj.CompareTag("Tree02")) && Obj.transform.position.x < -45f && isEnterCollision == true)        //왼쪽
        {
            minY = -0.3f;
            maxY = 0f;
            minX = 5f;
            maxX = 15f;

            rand = Random.Range(0, 2);

            if (rand == 0)
            {
                CreateObject(Tree01, minY, maxY, minX, maxX);
            }
            else
            {
                CreateObject(Tree02, minY, maxY, minX, maxX);
            }

            isEnterCollision = false;
        }

        else if ((tempObj.CompareTag("Tree01") || tempObj.CompareTag("Tree02")) && Obj.transform.localScale.x > 1.2f)            //위
        {
            if (BGO[0] > Tree[0])
            {
                for (int i = 0; i < BGO[0] - Tree[0]; i++)
                {
                    rand = Random.Range(0, 2);

                    if (rand == 0)
                    {
                        CreateObject(Tree01, asd1, sdd1, minX - 30f, minX);
                    }
                    else
                    {
                        CreateObject(Tree02, asd1, sdd1, minX - 30f, minX);
                    }
                }
            }
            if (BGO[1] > Tree[1])
            {
                for (int i = 0; i < BGO[1] - Tree[1]; i++)
                {
                    rand = Random.Range(0, 2);

                    if (rand == 0)
                    {
                        CreateObject(Tree01, asd1, sdd1, minX, maxX);
                    }
                    else
                    {
                        CreateObject(Tree02, asd1, sdd1, minX, maxX);
                    }
                }
            }
            if (BGO[2] > Tree[2])
            {
                for (int i = 0; i < BGO[2] - Tree[2]; i++)
                {
                    rand = Random.Range(0, 2);

                    if (rand == 0)
                    {
                        CreateObject(Tree01, asd1, sdd1, maxX, maxX + 30f);
                    }
                    else
                    {
                        CreateObject(Tree02, asd1, sdd1, maxX, maxX + 30f);
                    }
                }
            }
        }
        else if ((tempObj.CompareTag("Tree01") || tempObj.CompareTag("Tree02")) && Obj.transform.localScale.x < 0.2f)        //아래
        {
            if (BGO[0] > Tree[0])
            {
                for (int i = 0; i < BGO[0] - Tree[0]; i++)
                {
                    rand = Random.Range(0, 2);

                    if (rand == 0)
                    {
                        CreateObject(Tree01, asd, sdd, minX - 30f, minX);
                    }
                    else
                    {
                        CreateObject(Tree02, asd, sdd, minX - 30f, minX);
                    }
                }
            }
            if (BGO[1] > Tree[1])
            {
                for (int i = 0; i < BGO[1] - Tree[1]; i++)
                {
                    rand = Random.Range(0, 2);

                    if (rand == 0)
                    {
                        CreateObject(Tree01, asd, sdd, minX, maxX);
                    }
                    else
                    {
                        CreateObject(Tree02, asd, sdd, minX, maxX);
                    }
                }
            }
            if (BGO[2] > Tree[2])
            {
                for (int i = 0; i < BGO[2] - Tree[2]; i++)
                {
                    rand = Random.Range(0, 2);

                    if (rand == 0)
                    {
                        CreateObject(Tree01, asd, sdd, maxX, maxX + 30f);
                    }
                    else
                    {
                        CreateObject(Tree02, asd, sdd, maxX, maxX + 30f);
                    }
                }
            }
        }
    }


    private void Start()
    {
        TreeObjectGenerate(Tree01);
    }
}