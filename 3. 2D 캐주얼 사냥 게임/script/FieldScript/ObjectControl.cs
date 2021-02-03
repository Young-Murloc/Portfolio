using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;
using TagManager;

public class ObjectControl : MonoBehaviour
{
    GameObject camera;
    GameObject BackgroundObj;
    GameObject AnimalObj;
    GameObject controlObject;
    private bool canMove = true;
    private float cnt = 0;

    TagManager.BaseCamp TMBC = new TagManager.BaseCamp();
    TagManager.Tree01 TMT01 = new TagManager.Tree01();
    TagManager.Tree02 TMT02 = new TagManager.Tree02();
    TagManager.Buffalo TMBF = new TagManager.Buffalo();
    TagManager.Gazella TMGZ = new TagManager.Gazella();

    private float DisSizeTop;
    private float DisSizeBot;

   
    public void SetObjectSize(string a, float sign)
    {
        if (a == "B")
        {
            float sizeGap = controlObject.transform.localScale.x * controlObject.transform.localScale.x * 0.015f;
            controlObject.transform.localScale += new Vector3((sign * sizeGap), (sign * sizeGap), 0);
        }
        else if (a == "A")
        {
            float sizeGap = controlObject.transform.localScale.x * controlObject.transform.localScale.x * 0.015f;
            controlObject.transform.localScale += new Vector3((sign * sizeGap), (sign * sizeGap), 0);

        }
    }
    public void SetObjectPosition(string a, float sign)
    {
        Vector3 cameraPos = camera.transform.position;
        Vector3 controlObjectPos = controlObject.transform.position;
        float bottom = controlObject.GetComponent<SpriteRenderer>().bounds.extents.y;
        float moving = cameraPos.x - controlObjectPos.x;

        if (moving > 5.5f)
            moving = 5.5f;
        else if (moving < -5.5f)
            moving = -5.5f;

        if (a == "B")
        {
            controlObject.transform.Translate(-sign * moving * 0.002f / 2, 0, -bottom - controlObjectPos.z + controlObjectPos.y);
        }
        else if (a == "A")
        {
            controlObject.transform.Translate(-sign * moving * 0.002f / 2, -0.0005f * sign, -bottom - controlObjectPos.z + controlObjectPos.y);
        }

    }
    public void SetObjectBrightness(string a, float sign)
    {
        if (a == "B")
        {
            Renderer renderer = controlObject.GetComponent<Renderer>();
            Vector3 controlObjectPos = controlObject.transform.position;
            float bottom = controlObject.GetComponent<SpriteRenderer>().bounds.extents.y;

            if (controlObject.transform.localScale.x <= DisSizeTop)     //투명화 되는 부분 
            {
                float transparency = (DisSizeTop - controlObject.transform.localScale.x) * 35f;
                renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b,
                    Mathf.Clamp(1 - transparency, 0f, 1f));
                Debug.Log("asd : "+ transparency + "// 밝기 : " + renderer.material.color.a);
            }
            else if (controlObject.transform.localScale.x >= DisSizeBot)     //투명화 되는 부분
            {
                float transparency = (controlObject.transform.localScale.x - 1.7f);
                renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b,
                     Mathf.Clamp(1- transparency, 0f, 1f));
                Debug.Log("// 밝기 : " + renderer.material.color.a);
            }
        }
        else if (a == "A")
        {
            Renderer renderer = controlObject.GetComponent<Renderer>();
            Vector3 controlObjectPos = controlObject.transform.position;
            float bottom = controlObject.GetComponent<SpriteRenderer>().bounds.extents.y;

            if (controlObject.transform.localScale.x <= DisSizeTop)     //투명화 되는 부분 
            {
                float transparency = (DisSizeTop - controlObject.transform.localScale.x) * 35f;
                renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b,
                    Mathf.Clamp(1 - transparency, 0f, 1f));
                Debug.Log("asd : " + transparency + "// 밝기 : " + renderer.material.color.a);
            }
        }
    }

    public void ObjectCheck(string a)
    {
        Vector3 controlObjectPos = controlObject.transform.position;
        float bottom = controlObject.GetComponent<SpriteRenderer>().bounds.extents.y;

        //Log
        Renderer renderer = controlObject.GetComponent<Renderer>();
        if (a == "B")
        {
            //삭제
            if (controlObject.transform.localScale.x < 0.12f || controlObject.transform.localScale.x > 2.4f)   //삭제 되는 부분
            {
                GameObject.Find("TreeObjectGenerator").GetComponent<TreeObjectGenerateScript>().DeleteObject(controlObject.gameObject);
                Debug.Log((cnt++) + "[[[삭제]]]] y 좌표 : " + controlObject.transform.position.y + "  ///   사이즈  : " + controlObject.transform.localScale.x
                     + "///    z 좌표" + (-bottom + controlObjectPos.y) + " /// 색깔" + renderer.material.color.a);
            }
        }
        else if (a == "A")
        {
            if (controlObject.transform.localScale.x < 0.1f )   //삭제 되는 부분
            {
                GameObject.Find("TreeObjectGenerator").GetComponent<TreeObjectGenerateScript>().DeleteObject(controlObject.gameObject);
                Debug.Log((cnt++) + "[[[삭제]]]] y 좌표 : " + controlObject.transform.position.y + "  ///   사이즈  : " + controlObject.transform.localScale.x
                     + "///    z 좌표" + (-bottom + controlObjectPos.y) + " /// 색깔" + renderer.material.color.a);
            }
        }
    }

    public bool isAnimalEnterCameraZone(GameObject Obj)
    {
        float posX = controlObject.transform.position.x;
        float posY = controlObject.transform.position.y;
        float HAD = controlObject.GetComponent<SpriteRenderer>().bounds.extents.x;
        float VAD = controlObject.GetComponent<SpriteRenderer>().bounds.extents.y;

        if (posX + HAD >= -4.09f && posX - HAD <= 4.09f && posY - VAD <= 1.7f && posY + VAD >= -2.9f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public IEnumerator ObjectSize(float value)
    {
        cnt++;
        if (canMove)
        {
            canMove = false;

            int BGOchildCount = BackgroundObj.transform.childCount;
            int AOchildCount = AnimalObj.transform.childCount;
            for (int i = 0; i < BGOchildCount; i++)
            {
                if (i >= BackgroundObj.transform.childCount)
                {
                    break;
                }

                controlObject = BackgroundObj.transform.GetChild(i).gameObject;

                if (controlObject.CompareTag("Tree01"))
                {
                    DisSizeTop = TMT01.GetTree01DisSizeTop();
                    DisSizeBot = TMT01.GetTree01DisSizeBot();
                }
                else if (controlObject.CompareTag("Tree02"))
                {
                    DisSizeTop = TMT02.GetTree02DisSizeTop();
                    DisSizeBot = TMT02.GetTree02DisSizeBot();

                }
                  
                SetObjectSize("B", value);

                SetObjectPosition("B", value);

                SetObjectBrightness("B", value);

                ObjectCheck("B");
            }

            for (int i = 0; i < AOchildCount; i++)
            {
                if (i >= AnimalObj.transform.childCount)
                {
                    break;
                }

                controlObject = AnimalObj.transform.GetChild(i).gameObject;

                if (controlObject.CompareTag("Buffalo"))
                {
                    DisSizeTop = TMBF.GetBuffaloDisSizeTopDisSizeTop();
                    DisSizeBot = TMBF.GetBuffaloDisSizeTopDisSizeBot();

                }
                else if (controlObject.CompareTag("Gazella"))
                {
                    DisSizeTop = TMGZ.GetGazellaDisSizeTopDisSizeTop();
                    DisSizeBot = TMGZ.GetGazellaDisSizeTopDisSizeBot();

                }
                Debug.Log(DisSizeTop);
                if (isAnimalEnterCameraZone(controlObject))
                {
                    SetObjectSize("A", value);

                    SetObjectPosition("A", value);

                    SetObjectBrightness("A", value);

                    ObjectCheck("A");
                }
            }
            yield return new WaitForSeconds(0.01f);

            canMove = true;
        }
    }

    void Start()
    {
        BackgroundObj = GameObject.Find("BackGroundObject");
        AnimalObj = GameObject.Find("AnimalObject");
        camera = GameObject.Find("Main Camera");
    }
}