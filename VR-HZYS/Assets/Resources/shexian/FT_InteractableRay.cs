using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class FT_InteractableRay : MonoBehaviour
{
    public bool isActive = true;

    public UnityEvent OnRayEnter;
    public UnityEvent OnRayExit;
    public UnityEvent OnRayClick;

    public virtual void RayEnter()
    {
        OnRayEnter?.Invoke();
        Debug.Log("���߽���:" + name);
    }

    public virtual void RayExit()
    {
        OnRayExit?.Invoke();
        Debug.Log("�����뿪:" + name);
    }

    public virtual void RayClick()
    {
        OnRayClick?.Invoke();
        Debug.Log("���ߵ��:" + name);
    }
}