using UnityEngine;

public class ARScale : MonoBehaviour
{
    public float speed = 0.01f;

    void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch t1 = Input.GetTouch(0);
            Touch t2 = Input.GetTouch(1);

            float prev = (t1.position - t1.deltaPosition - (t2.position - t2.deltaPosition)).magnitude;
            float curr = (t1.position - t2.position).magnitude;

            float diff = curr - prev;

            transform.localScale += Vector3.one * diff * speed * Time.deltaTime;
        }
    }
}