using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{
    public GameObject q;

    public void LoadGame()
    {
        Jump.SwitchAndLoadScene(1);
    }

    public void ExitGame()
    {
        Jump.EndApp();
    }

    public void FailGame()
    {
        Jump.SwitchAndLoadScene(3);
    }

    public void VictoryGame()
    {
        Jump.SwitchAndLoadScene(2);
    }

    public void qup()
    {
        q.SetActive(true);
    }
    public void qdown()
    {
        q.SetActive(false);
    }
}