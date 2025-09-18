using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionCatalogo : MonoBehaviour
{
    private Animator animator;
    private bool isPlayingEntrada = false; // Estado de la animaci�n "Entrada"
    private bool isPlayingSalida = false;  // Estado de la animaci�n "Salida"

    private void Awake()
    {
        // Obtener el componente Animator adjunto a este GameObject
        animator = GetComponent<Animator>();

        // Verificar si se encontr� el componente Animator
        if (animator == null)
        {
            Debug.LogError("El componente Animator no se encontr� en este GameObject.");
        }

        // Inicialmente, ninguna animaci�n est� en curso
        isPlayingEntrada = true;
        isPlayingSalida = false;
    }

    // Funci�n para activar la animaci�n "Entrada"
    public void ActivateEntrada()
    {
        // Verificar si no se est� reproduciendo la animaci�n "Entrada"
        if (!isPlayingEntrada)
        {
            // Activa el par�metro "Entrada" en el animador
            animator.SetTrigger("Entrada");
            isPlayingEntrada = true;
            isPlayingSalida = false; // Asegura que la otra animaci�n no est� en curso
        }
        else
        {
            Debug.LogWarning("La animaci�n 'Entrada' ya est� en curso o se est� reproduciendo 'Salida'.");
        }
    }

    // Funci�n para activar la animaci�n "Salida"
    public void ActivateSalida()
    {
        // Verificar si no se est� reproduciendo la animaci�n "Salida"
        if (!isPlayingSalida)
        {
            // Activa el par�metro "Salida" en el animador
            animator.SetTrigger("Salida");
            isPlayingSalida = true;
            isPlayingEntrada = false; // Asegura que la otra animaci�n no est� en curso
        }
        else
        {
            Debug.LogWarning("La animaci�n 'Salida' ya est� en curso o se est� reproduciendo 'Entrada'.");
        }
    }
}
