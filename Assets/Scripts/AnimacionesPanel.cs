using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionesPanel : MonoBehaviour
{
    [SerializeField] private Animator anim;

    private bool isPlayingEntrada = false; // Estado de la animación "Entrada"
    private bool isPlayingSalida = false;  // Estado de la animación "Salida"

    private void Awake()
    {
        // Inicialmente, ninguna animación está en curso
        isPlayingEntrada = false;
        isPlayingSalida = false;
    }

    // Función para activar la animación "Entrada"
    public void ActivateEntrada()
    {
        if (!isPlayingEntrada)
        {
            // Activa el parámetro "Entrada" en el animador
            anim.SetTrigger("Entrada");
            isPlayingEntrada = true;
            isPlayingSalida = false;
        }
    }

    // Función para activar la animación "Salida"
    public void ActivateSalida()
    {
        if (!isPlayingSalida)
        {
            // Activa el parámetro "Salida" en el animador
            anim.SetTrigger("Salida");
            isPlayingSalida = true;
            isPlayingEntrada = false;
        }
    }

}
