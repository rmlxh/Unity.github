using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RequestData 
{
    public string model;
    public List<Message> messages;
}

[System.Serializable]
public class Message
{
    public string role;
    public string content;
}