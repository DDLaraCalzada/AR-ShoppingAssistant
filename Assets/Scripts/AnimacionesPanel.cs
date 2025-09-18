using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionesPanel : MonoBehaviour
{
    [SerializeField] private Animator anim;

    private bool isPlayingEntrada = false; // Estado de la animaci�n "Entrada"
    private bool isPlayingSalida = false;  // Estado de la animaci�n "Salida"

    private void Awake()
    {
        // Inicialmente, ninguna animaci�n est� en curso
        isPlayingEntrada = false;
        isPlayingSalida = false;
    }

    // Funci�n para activar la animaci�n "Entrada"
    public void ActivateEntrada()
    {
        if (!isPlayingEntrada)
        {
            // Activa el par�metro "Entrada" en el animador
            anim.SetTrigger("Entrada");
            isPlayingEntrada = true;
            isPlayingSalida = false;
        }
    }

    // Funci�n para activar la animaci�n "Salida"
    public void ActivateSalida()
    {
        if (!isPlayingSalida)
        {
            // Activa el par�metro "Salida" en el animador
            anim.SetTrigger("Salida");
            isPlayingSalida = true;
            isPlayingEntrada = false;
        }
    }

}
