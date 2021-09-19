using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public Vector2 keyInput;
    public Vector2 dragInput;

    public float dragSensitivity;

    private void Update()
    {
        keyInput.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        dragInput = Vector2.zero;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        dragInput = Vector2.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        var delta = eventData.delta / Screen.height;
        dragInput += delta * dragSensitivity;
        dragInput.x = Mathf.Clamp(dragInput.x, -1f, 1f);
        dragInput.y = Mathf.Clamp(dragInput.y, -1f, 1f);
    }
}