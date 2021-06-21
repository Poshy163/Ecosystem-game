using UnityEngine;
using UnityEngine.EventSystems;

public class DragObject : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Canvas _canvas;
#pragma warning disable 414
    private bool _dragging = false, _canDrag = true;
#pragma warning restore 414
    private Vector3 _originalPos;
    private RectTransform _rectTransform;

    private void Start()
    {
        _canDrag = true;
        _rectTransform = GetComponent<RectTransform>();
        _originalPos = transform.position;
        _canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!_canDrag) return;
        var locBut = Instantiate(gameObject, _canvas.transform);
        locBut.transform.position = _originalPos;
        locBut.name = "Lion";
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!_canDrag) return;
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        _canDrag = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    { }
}