using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackKey : MonoBehaviour
{
    private GameObject quitMenu;
    private bool isTurnOnQuitMenu = false;

    void Start()
    {
        //quitMenu = GameObject.Find("QuitMenu");

        //quitMenu.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!isTurnOnQuitMenu)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                if (Input.GetKey(KeyCode.Escape))
                {
                    quitMenu.gameObject.SetActive(true);
                    isTurnOnQuitMenu = true;
                }
            }
        }
    }

    public void yesBtn()
    {
        Application.Quit();
    }

    public void noBtn()
    {
        quitMenu.gameObject.SetActive(false);
        isTurnOnQuitMenu = false;
    }
}
