using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCObject : InteractableObject
{
    public string npcName; //npc����
    public string[] contentList; //�Ի�����

    public DialogueUI dialogueUI;
    protected override void Interact()
    {
        dialogueUI.Show(npcName, contentList);
        print("md");
    }
}
