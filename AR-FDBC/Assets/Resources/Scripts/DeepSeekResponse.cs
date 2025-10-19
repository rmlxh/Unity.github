using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DeepSeekResponse 
{
    public string id;
    public string object_name;
    public long creatd;
    public Choice[] choices;
}

[System.Serializable]
public class Choice
{
    public Message message;
    public int index;
}