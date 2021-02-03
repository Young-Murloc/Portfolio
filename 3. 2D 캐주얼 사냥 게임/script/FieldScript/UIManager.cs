using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private bool ButtonDown = false;
    private bool BackButtonDown = false;

    public void PointerDown()
    {
        ButtonDown = true;
    }

    public void PointerUp()
    {
        ButtonDown = false;
    }
    public void BackPointerDown()
    {
        BackButtonDown = true;
    }

    public void BackPointerUp()
    {
        BackButtonDown = false;
    }

    private void Update()
    {
        if (ButtonDown)
        {
            StartCoroutine(GameObject.Find("Main Camera").GetComponent<CameraMoveUpDown>().MoveShake());
            StartCoroutine(GameObject.Find("UIManager").GetComponent<ObjectControl>().ObjectSize(1f));
        }
        if (BackButtonDown)
        {
            StartCoroutine(GameObject.Find("Main Camera").GetComponent<CameraMoveUpDown>().MoveShake());
            StartCoroutine(GameObject.Find("UIManager").GetComponent<ObjectControl>().ObjectSize(-1f));
        }
    }
}
