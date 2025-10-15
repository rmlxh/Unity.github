using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InteractableObject : MonoBehaviour
{
    //private bool haveInteracted = false; //判断是否交互过

    //点击的交互
    public void OnClick()
    {
        //haveInteracted = true;
        Interact();
    }

    private void Update()
    {

    }

    protected virtual void Interact()
    {
        print("无语，Interacting with Interactable Object.");
    }
}
