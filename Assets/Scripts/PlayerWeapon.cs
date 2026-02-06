using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{

    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crossHair;
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistancePoint = 250f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    bool isFiring = false;
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        FiringSequence();
        MoveCrossHair();
        MoveTargetPoint();
    }

    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }

    private void FiringSequence()
    {
        PlayLaser();
    }

    private void PlayLaser()
    {
        foreach (GameObject laser in lasers)
        {
            var emission = laser.GetComponent<ParticleSystem>().emission;
            emission.enabled = isFiring;
        }

    }

    void MoveCrossHair()
    {
        crossHair.position = Input.mousePosition;
    }

    void MoveTargetPoint()
    {
        Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistancePoint);
        targetPoint.position = Camera.main.ScreenToWorldPoint(position);
    }
}
