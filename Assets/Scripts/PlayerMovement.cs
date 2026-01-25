using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float controlSpeed;
    [SerializeField] float xClampPos;
    [SerializeField] float yClampPos;
    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        ProcessTranlation();
    }   

    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }
    private void ProcessTranlation()
    {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float xRawPos = transform.localPosition.x + xOffset;
        float xClamped = Mathf.Clamp(xRawPos, -xClampPos, xClampPos);

        float yOffset = movement.y * controlSpeed * Time.deltaTime;
        float yRawPos = transform.localPosition.y + yOffset;
        float yClamped = Mathf.Clamp(yRawPos, -yClampPos, yClampPos);

        transform.localPosition = new Vector3(xClamped,yClamped,0f);
    }
    // added comment
}
