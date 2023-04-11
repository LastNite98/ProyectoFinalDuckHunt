using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shoot : MonoBehaviour, IPointerDownHandler
{
    public static Action OnScore;
    [SerializeField] int lifes;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnScore?.Invoke();
            if (CompareTag("Duck"))
            {
                if (lifes > 0)
                {
                    lifes--;
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
    }

}//Class