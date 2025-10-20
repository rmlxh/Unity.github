using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingScene : MonoBehaviour
{
    public void LoadGame()
    {
        Jump.SwitchAndLoadScene(1);
    }
    public void Quit()
    {
        Jump.EndApp();
    }
}