using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{

    [SerializeField] GameObject[] lasers;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    bool isFiring = false;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        FiringSequence();
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
}
