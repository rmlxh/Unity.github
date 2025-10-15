using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCObject : InteractableObject
{
    public string npcName; //npc名字
    public string[] contentList; //对话内容

    public DialogueUI dialogueUI;
    protected override void Interact()
    {
        dialogueUI.Show(npcName, contentList);
        print("md");
    }
}
