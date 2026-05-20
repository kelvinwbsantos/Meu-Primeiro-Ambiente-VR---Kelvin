using UnityEngine;
using Oculus.Interaction;

public class PlaySoundOnGrab : MonoBehaviour
{
    // Referência do componente de áudio
    public AudioSource audioSource;

    // Referência do componente grabável
    private Grabbable grabbable;

    void Start()
    {
        // Procura o componente Grabbable no objeto
        grabbable = GetComponent<Grabbable>();

        // Escuta os eventos de interação
        grabbable.WhenPointerEventRaised += HandlePointerEvent;
    }

    // Método chamado sempre que ocorre interação
    private void HandlePointerEvent(PointerEvent evt)
    {
        // Quando pegar o objeto
        if (evt.Type == PointerEventType.Select)
        {
            // Toca o áudio
            audioSource.Play();
        }

        // Quando soltar o objeto
        if (evt.Type == PointerEventType.Unselect)
        {
            // Para o áudio
            audioSource.Pause();
        }
    }

    void OnDestroy()
    {
        // Remove o evento para evitar erros
        if (grabbable != null)
        {
            grabbable.WhenPointerEventRaised -= HandlePointerEvent;
        }
    }
}