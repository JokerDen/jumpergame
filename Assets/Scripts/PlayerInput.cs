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
        if (Input.GetKeyDown(KeyCode.R))
            // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            GameManager.current.RestartGameplay();
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

    public Vector2 GetInputDirection()
    {
        keyInput.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        var sum = keyInput + dragInput;
        sum.x = Mathf.Clamp(sum.x, -1f, 1f);
        sum.y = Mathf.Clamp(sum.y, -1f, 1f);
        
        return sum;
    }
}