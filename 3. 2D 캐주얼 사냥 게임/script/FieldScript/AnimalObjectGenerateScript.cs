using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class AnimalObjectGenerateScript : MonoBehaviour
{
    TagManager.BaseCamp TMBC = new TagManager.BaseCamp();
    TagManager.Bird TMB = new TagManager.Bird();
    TagManager.Gazella TMGZ = new TagManager.Gazella();

    public GameObject bird01;
    public GameObject bird02;
    public GameObject gazella;
    public GameObject hyena;
    public GameObject lion;
    public GameObject zebra;
    public GameObject buffalo;

    public GameObject PlayerPos;
    private string PrevPos;

    public GameObject AnimalObject;
    public GameObject tempObject;

    public GameObject[] BackGround;

    private GameObject tempObj;
    private float height;
    private Renderer render;

    private float minX, maxX, minY, maxY;
    private bool isEnterCollision = false;
    public GameObject Object;

    private int[] Animal = new int[3];

    public float spawnTime;
    public float curTime;

    private void Start()
    {
        spawnTime = Random.Range(1f, 1f);
        PrevPos = "BaseCamp";
    }

    public void AnimalObjectMove(Vector3 MovePos)
    {
        int AOchildCount = AnimalObject.transform.childCount;

        for (int j = 0; j < AOchildCount; j++)
        {
            AnimalObject.transform.GetChild(j).transform.Translate(MovePos);
        }
    }

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

    public void DeleteAnimalObject(GameObject Obj)
    {
        Obj.transform.parent = tempObject.transform;
        Destroy(Obj);
    }

    void CheckAnimalObject()
    {
        minX = BackGround[0].transform.position.x;
        maxX = BackGround[0].transform.position.x;

        Animal[0] = 0;
        Animal[1] = 0;
        Animal[2] = 0;

        for (int i = 1; i < 3; i++)
        {
            if (maxX < BackGround[i].transform.position.x)
            {
                maxX = BackGround[i].transform.position.x;
            }
            else if (minX > BackGround[i].transform.position.x)
            {
                minX = BackGround[i].transform.position.x;
            }
        }

        minX += 15f;
        maxX -= 15f;

        int AOchildCount = AnimalObject.transform.childCount;

        for (int i = 0; i < AOchildCount; i++)
        {
            if (AnimalObject.transform.GetChild(i).position.x < minX)
            {
                Animal[0]++;
            }
            else if (AnimalObject.transform.GetChild(i).position.x < maxX)
            {
                Animal[1]++;
            }
            else
            {
                Animal[2]++;
            }
        }
    }

    void ChangeAnimal(string Tag)
    {
        int AOchildCount = AnimalObject.transform.childCount;

        GameObject tempAnimalObject;

        switch (Tag)
        {
            case "BaseCamp":
                for (int i = 0; i < AOchildCount; i++)
                {
                    tempAnimalObject = AnimalObject.transform.GetChild(i).gameObject;

                    if (GameObject.Find("UIManager").GetComponent<ObjectControl>().isAnimalEnterCameraZone(tempAnimalObject) == false)
                    {
                        DeleteAnimalObject(tempAnimalObject);
                    }
                }
                break;

            case "Bird":
                for (int i = 0; i < AOchildCount; i++)
                {
                    tempAnimalObject = AnimalObject.transform.GetChild(i).gameObject;

                    if (GameObject.Find("UIManager").GetComponent<ObjectControl>().isAnimalEnterCameraZone(tempAnimalObject) == false)
                    {
                        if (tempAnimalObject.CompareTag("bird01") == false || tempAnimalObject.CompareTag("bird02") == false)
                        {
                            DeleteAnimalObject(tempAnimalObject);
                            int temp = Random.Range(0, 1);

                            if (temp == 0)
                            {
                                CreateAnimalObject(bird01, tempAnimalObject.transform.position.x, tempAnimalObject.transform.position.x, tempAnimalObject.transform.position.y, tempAnimalObject.transform.position.y);
                            }
                            else
                            {
                                CreateAnimalObject(bird02, tempAnimalObject.transform.position.x, tempAnimalObject.transform.position.x, tempAnimalObject.transform.position.y, tempAnimalObject.transform.position.y);
                            }
                        }
                    }
                }
                break;

            case "Buffalo":
                break;

                //각 동물의 case 추가
        }
    }

    void CreateAnimalObject(GameObject gameObj, float minY, float maxY, float minX, float maxX)
    {
        tempObj = Instantiate(gameObj) as GameObject;

        tempObj.transform.parent = AnimalObject.transform;

        float tempX = Random.Range(minX, maxX);
        float tempY = Random.Range(minY, maxY);
        float posY = 0f;
        if (gameObj.CompareTag("Gazella"))
        {
            posY = TMGZ.GetGazellaResponePosY(tempY);
            Debug.Log(posY);
        }
        tempObj.transform.localScale = new Vector3(tempY, tempY, 0);

        height = tempObj.GetComponent<SpriteRenderer>().bounds.extents.y;

        tempObj.transform.position = new Vector3(tempX, posY + Object.transform.position.y, (-height + 0.05f));

        //밝기 조절
        render = tempObj.transform.GetComponent<Renderer>();
        if (tempObj.transform.localScale.x <= 0.11f)
        {
            render.material.color = new Color(1, 1, 1, 0);
        }
        else if (tempObj.transform.localScale.x >= 2.3f)
        {
            
        }
    }

    void TagCompare()         //어떤 동물을 생성 하는가?
    {
        if (PlayerPos.transform.position.x > 20 && PlayerPos.transform.position.x < 60 && PlayerPos.transform.position.y > -120 && PlayerPos.transform.position.y < -80) //BaseCamp 주변 **값 수정 필요**
        {
            if (!PrevPos.Equals("BaseCamp"))
            {
                ChangeAnimal("BaseCamp");

                int count = TMBC.GetCount();

                PrevPos = "BaseCamp";
            }
        }
        else            //새 지역의 경우 return 새
        {
            if (!PrevPos.Equals("Brid"))
            {
                ChangeAnimal("Brid");

                float Pos = TMB.GetPosY();
                int Count = TMB.GetCount();

                maxY = Pos;
                minY = Pos;

                PrevPos = "Brid";
            }
        }
    }

    int AnimalGenerateObject(GameObject Obj)
    {
        CheckAnimalObject();
        float creat_Min_PosY = 0.1f;
        float creat_Max_PosY = 0.1f;


        int[] AO = new int[3];
        //랜덤생성
        //생성될 x위치 설정       3    |     3    |     3
        int random = Random.Range(0, 3);

        //해당 위치에 동물수 비교 후 생성 결정 
        for (int i = 0; i < 3; i++)
        {
            int index = (random + i) % 3;
            if (Animal[index] >= 3)
            {
                if (i == 2)
                    return 0;
                continue;
            }

            if (index == 0)
            {
                int rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    CreateAnimalObject(bird01, creat_Min_PosY, creat_Max_PosY + 0.2f, minX - 30f, minX);
                }
                else
                {
                    CreateAnimalObject(bird02, creat_Min_PosY, creat_Max_PosY + 0.2f, minX - 30f, minX);
                }
            }
            //중앙
            else if (index == 1)
            {
                int rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    CreateAnimalObject(bird01, creat_Min_PosY, creat_Max_PosY, minX, maxX);
                }
                else
                {
                    CreateAnimalObject(bird02, creat_Min_PosY, creat_Max_PosY, minX, maxX);
                }
            }
            else if (index == 2)
            {
                int rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    CreateAnimalObject(bird01, creat_Min_PosY, creat_Max_PosY + 0.2f, maxX, maxX + 30f);
                }
                else
                {
                    CreateAnimalObject(bird02, creat_Min_PosY, creat_Max_PosY + 0.2f, maxX, maxX + 30f);
                }
            }

            break;
        }
        return 0;
    }

    private void Update()
    {
        TagCompare();

        if (curTime >= spawnTime)
        {
            AnimalGenerateObject(null);
            curTime = 0;

            spawnTime = Random.Range(1f, 1f);
        }

        curTime += Time.deltaTime;
    }
}
