using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Chef : MonoBehaviour
{
    [SerializeField] private Transform targetCamara; // Referencia al objeto (cama) hacia el que quieres rotar
                                                     // Referencia al componente AudioSource que quieres controlar
    [SerializeField] private Animator anim;

    [SerializeField] private AudioSource audio1_Saludo;
    [SerializeField] private AudioSource menu;
    [SerializeField] private AudioSource atras;
    [SerializeField] private AudioSource Informacion;
    [SerializeField] private AudioSource Promociones;
    [SerializeField] private AudioSource Locales;
    [SerializeField] private AudioSource catalogoTacoBell;
    [SerializeField] private AudioSource catalogo_SubWay;
    [SerializeField] private AudioSource catalogo_Popeyes;
    [SerializeField] private AudioSource catalogo_PandaE;
    [SerializeField] private AudioSource catalogo_Qbano;
    [SerializeField] private AudioSource Promo_TacoBell;
    [SerializeField] private AudioSource Promo_Subway;
    [SerializeField] private AudioSource Promo_Popeyes;
    [SerializeField] private AudioSource Promo_Panda;
    [SerializeField] private AudioSource Promo_Qbano;
    [SerializeField] private AudioSource Guardar;

    // Referencia a los componentes AudioSource que quieres controlar
    private List<AudioSource> audios = new List<AudioSource>();

    private AudioSource audioEnReproduccion;

    void Start()
    {
        // Añadir todos los AudioSource a la lista de audios
        audios.Add(audio1_Saludo);
        audios.Add(menu);
        audios.Add(atras);
        audios.Add(Informacion);
        audios.Add(Promociones);
        audios.Add(Locales);
        audios.Add(catalogoTacoBell);
        audios.Add(catalogo_SubWay);
        audios.Add(catalogo_Popeyes);
        audios.Add(catalogo_PandaE);
        audios.Add(catalogo_Qbano);
        audios.Add(Promo_TacoBell);
        audios.Add(Promo_Subway);
        audios.Add(Promo_Popeyes);
        audios.Add(Promo_Panda);
        audios.Add(Promo_Qbano);
        audios.Add(Guardar);
    }

    // Método público para detener todos los audios
    private void DetenerTodosLosAudios()
    {
        
        foreach (AudioSource audio in audios)
        {
            if (audio != null && audio.isPlaying)
            {
                audio.Stop();
                Debug.Log("Audio detenido");
            }
        }

        audioEnReproduccion = null; // Restablecer la referencia al audio en reproducción
    }

    // Métodos públicos para reproducir audios específicos

    public void ReproducirSaludo()
    {
        DetenerTodosLosAudios();
        audio1_Saludo.Play();
        Activate_Animator_Saludo();
    }

    public void ReproducirMenu()
    {
        Activate_Hablar_Promo_Animator();
        DetenerTodosLosAudios();
        menu.Play();

        Debug.Log("ReproducirMenu");
    }

    public void ReproducirAtras()
    {
        Activate_Adios();
        DetenerTodosLosAudios();
        atras.Play();
    }

    public void ReproducirInformacion()
    {
        Activate_Hablar_2();
        DetenerTodosLosAudios();
        Informacion.Play(); 
    }

    public void ReproducirPromocion()
    {
        Activate_Hablar_Promo_Animator();
        DetenerTodosLosAudios();
        Promociones.Play();
    }

    public void ReproducirLocales()
    {
        Activate_Hablar_5();
        DetenerTodosLosAudios();
        Locales.Play();
    }

    public void ReproducirCatalogoTacoBell()
    {
        Activate_Hablar_2(); 
        DetenerTodosLosAudios();
        catalogoTacoBell.Play();    
    }

    public void ReproducirCatalogoSubway()
    {
        Activate_Hablar_3();
        DetenerTodosLosAudios();
        catalogo_SubWay.Play();
    }

    public void ReproducirCatalogoPopeyes()
    {
        Activate_Hablar_5();
        DetenerTodosLosAudios();
        catalogo_Popeyes.Play();
        
    }

    public void ReproducirCatalogoPandaExpress()
    {
        Activate_Hablar_Promo_Animator();
        DetenerTodosLosAudios();
        catalogo_PandaE.Play();
        
    }

    public void ReproducirCatalogoQbano()
    {
        Activate_Hablar_2();
        DetenerTodosLosAudios();
        catalogo_Qbano.Play();
    }

    public void ReproducirPromoTacoBell()
    {
        Activate_Hablar_3();
        DetenerTodosLosAudios();
        Promo_TacoBell.Play();  
    }

    public void ReproducirPromoSubway()
    {
        Activate_Hablar_Promo_Animator();
        DetenerTodosLosAudios();
        Promo_Subway.Play();    
    }

    public void ReproducirPromoPopeyes()
    {
        Activate_Hablar_5();
        DetenerTodosLosAudios();
        Promo_Popeyes.Play();
    }

    public void ReproducirPromoPandaExpress()
    {
        Activate_Hablar_Promo_Animator();
        DetenerTodosLosAudios();
        Promo_Panda.Play();
    }

    public void ReproducirPromoQbano()
    {
        Activate_Hablar_2();
        DetenerTodosLosAudios();
        Promo_Qbano.Play();
    }

    public void ReproducirGuardar()
    {
        Activate_Feliz();
        DetenerTodosLosAudios();
        Guardar.Play();
 
    }

    //Animaciones
    public void Activate_Hablar_Promo_Animator()
    {
        // Activa el parámetro "Entrada" en el animador
        anim.SetTrigger("Hablar");
    }

    public void Activate_Hablar_2()
    {
        // Activa el parámetro "Entrada" en el animador
        anim.SetTrigger("Hablando 2");
    }

    public void Activate_Hablar_3()
    {
        // Activa el parámetro "Entrada" en el animador
        anim.SetTrigger("Hablando 3");
    }

    public void Activate_Hablar_5()
    {
        // Activa el parámetro "Entrada" en el animador
        anim.SetTrigger("Hablando 5");
    }

    public void Activate_Feliz()
    {
        // Activa el parámetro "Entrada" en el animador
        anim.SetTrigger("Feliz");
    }

    public void Activate_Adios()
    {
        // Activa el parámetro "Entrada" en el animador
        anim.SetTrigger("Adios");
    }


    public void Activate_Animator_Saludo()
    {
        // Activa el parámetro "Entrada" en el animador
        anim.SetTrigger("Saludo");
    }



    void Update()
    {
        if (targetCamara != null)
        {
            // Calcula la dirección hacia el objetivo
            Vector3 targetDirection = targetCamara.position - transform.position;
            targetDirection.y = 0f; // Asegura que la rotación sea en el plano horizontal (y = 0)

            // Rotación suave hacia el objetivo
            if (targetDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * 180f);
            }
        }
    }
}
