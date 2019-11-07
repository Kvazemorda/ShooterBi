using UnityEngine;
using UnityEngine.EventSystems;

public class button_script : MonoBehaviour, IPointerDownHandler
{
    Transform thisTransform;
    private MeshRenderer mr;
        
    // Start is called before the first frame update
    void Start()
    {
        thisTransform = transform;
        mr = thisTransform.GetComponent<MeshRenderer>();
    }

    private void OnMouseDown()
    {
       
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
