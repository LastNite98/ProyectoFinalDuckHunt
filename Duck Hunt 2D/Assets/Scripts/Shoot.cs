using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shoot : MonoBehaviour, IPointerDownHandler
{
    #region Variables 
    #region Events
    public static Action OnScore;
    public static Action OnSound;
    #endregion
    #region Lifes and Clips
    [SerializeField] int lifes;
    [SerializeField] AudioClip shootClip;
    [SerializeField] AudioClip deadClip;
    #endregion
    #region collider animator 
    private Collider2D collider2d;
    private Animator animator;
    #endregion
    #endregion

    private void Awake()
    {
        collider2d = GetComponent<Collider2D>();
        animator = GetComponentInChildren<Animator>();
    }

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
                    OnSound?.Invoke();
                    AudioManager.Instance.PlayAudioClip(shootClip);
                }
                else
                {
                    animator.SetTrigger("isDead");
                    collider2d.enabled = false;
                    OnSound?.Invoke();
                    AudioManager.Instance.PlayAudioClip(deadClip);
                    Destroy(gameObject, 1.1f);
                }
            }
        }
    }

}//Class