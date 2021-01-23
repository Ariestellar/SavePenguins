using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{  
    [SerializeField] private CameraRotateAround CameraRotateAround;

    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        CameraRotateAround.RotateCameraPosition(eventData.delta);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
    }
}
