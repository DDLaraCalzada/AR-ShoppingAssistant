using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionCatalogo : MonoBehaviour
{
    private Animator animator;
    private bool isPlayingEntrada = false; // Estado de la animación "Entrada"
    private bool isPlayingSalida = false;  // Estado de la animación "Salida"

    private void Awake()
    {
        // Obtener el componente Animator adjunto a este GameObject
        animator = GetComponent<Animator>();

        // Verificar si se encontró el componente Animator
        if (animator == null)
        {
            Debug.LogError("El componente Animator no se encontró en este GameObject.");
        }

        // Inicialmente, ninguna animación está en curso
        isPlayingEntrada = true;
        isPlayingSalida = false;
    }

    // Función para activar la animación "Entrada"
    public void ActivateEntrada()
    {
        // Verificar si no se está reproduciendo la animación "Entrada"
        if (!isPlayingEntrada)
        {
            // Activa el parámetro "Entrada" en el animador
            animator.SetTrigger("Entrada");
            isPlayingEntrada = true;
            isPlayingSalida = false; // Asegura que la otra animación no esté en curso
        }
        else
        {
            Debug.LogWarning("La animación 'Entrada' ya está en curso o se está reproduciendo 'Salida'.");
        }
    }

    // Función para activar la animación "Salida"
    public void ActivateSalida()
    {
        // Verificar si no se está reproduciendo la animación "Salida"
        if (!isPlayingSalida)
        {
            // Activa el parámetro "Salida" en el animador
            animator.SetTrigger("Salida");
            isPlayingSalida = true;
            isPlayingEntrada = false; // Asegura que la otra animación no esté en curso
        }
        else
        {
            Debug.LogWarning("La animación 'Salida' ya está en curso o se está reproduciendo 'Entrada'.");
        }
    }
}
