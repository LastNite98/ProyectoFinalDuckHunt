using UnityEngine;

public class Destroy : MonoBehaviour
{
    private void OnEnable()
    {
        Timer.OnTimesUp += DestroyObject;
    }

    private void OnDisable()
    {
        Timer.OnTimesUp -= DestroyObject;
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}//Class
