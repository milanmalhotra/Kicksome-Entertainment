using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Draggable.Slot typeOfItem = Draggable.Slot.INVENTORY;
    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       
    }
    public void OnDrop(PointerEventData eventData)
    {

        Draggable draggable = eventData.pointerDrag.GetComponent<Draggable>();
        if(draggable != null)
        {
            if(typeOfItem == draggable.typeOfItem || typeOfItem == Draggable.Slot.INVENTORY)
            {
                draggable.parentToReturnTo = this.transform;
            }
            
        }
    }
}
