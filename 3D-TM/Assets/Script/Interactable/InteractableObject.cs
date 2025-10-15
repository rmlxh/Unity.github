using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InteractableObject : MonoBehaviour
{
    //private bool haveInteracted = false; //�ж��Ƿ񽻻���

    //����Ľ���
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
        print("���Interacting with Interactable Object.");
    }
}
