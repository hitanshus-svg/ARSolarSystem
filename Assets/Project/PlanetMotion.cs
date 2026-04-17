using UnityEngine;

public class PlanetMotion : MonoBehaviour
{
    public Transform planet;
    public float orbitSpeed = 10f;
    public float rotationSpeed = 50f;

    void Update()
    {
        // Orbit around parent (Sun)
        transform.Rotate(Vector3.up * orbitSpeed * Time.deltaTime);

        // Self rotation
        if (planet != null)
            planet.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
