using UnityEngine;
using System.IO;

public class ImageSaver : MonoBehaviour
{
    public string nombreCarpeta = "PROMOCIONES UAO MALL";
    public Texture2D imagen;
    public GameObject objetoActivo;

    // Método público para crear la carpeta y guardar la imagen
    public void CrearCarpetaYGuardarImagen()
    {
        string rutaCompletaCarpeta = Path.Combine(Application.persistentDataPath, nombreCarpeta);

        try
        {
            if (!Directory.Exists(rutaCompletaCarpeta))
            {
                Directory.CreateDirectory(rutaCompletaCarpeta);
                Debug.Log("Carpeta creada correctamente en: " + rutaCompletaCarpeta);
            }
            else
            {
                Debug.Log("La carpeta ya existe en: " + rutaCompletaCarpeta);
            }

            if (imagen != null && imagen.width > 0 && imagen.height > 0)
            {
                // Convertir la textura a un formato adecuado antes de guardarla como PNG
                Texture2D texturaConvertida = ConvertirTexturaAFormatoAdecuado(imagen);

                // Generar un nombre único para la imagen
                string nombreImagen = "imagen_" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
                string rutaCompletaImagen = Path.Combine(rutaCompletaCarpeta, nombreImagen);

                // Convertir la textura convertida a bytes PNG
                byte[] bytesImagen = texturaConvertida.EncodeToPNG();

                if (bytesImagen != null)
                {
                    File.WriteAllBytes(rutaCompletaImagen, bytesImagen);
                    Debug.Log("Imagen guardada correctamente en: " + rutaCompletaImagen);

                    // Destruir la textura convertida después de guardarla para liberar memoria
                    Destroy(texturaConvertida);
                }
                else
                {
                    Debug.LogError("Error al convertir la textura a bytes PNG.");
                }
            }
            else
            {
                Debug.LogError("La textura asignada no es válida o no contiene datos de imagen.");
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error al crear la carpeta o guardar la imagen: " + ex.Message);
        }
    }

    // Función para convertir una textura a un formato adecuado (RGBA32) para evitar problemas con texturas comprimidas
    private Texture2D ConvertirTexturaAFormatoAdecuado(Texture2D texturaOriginal)
    {
        // Crea una nueva textura con el mismo tamaño y formato no comprimido (RGBA32)
        Texture2D texturaConvertida = new Texture2D(texturaOriginal.width, texturaOriginal.height, TextureFormat.RGBA32, texturaOriginal.mipmapCount > 1);

        // Copia los datos de la textura original a la textura convertida
        Graphics.CopyTexture(texturaOriginal, texturaConvertida);

        // Si la textura original tiene múltiples niveles de mipmaps, asegúrate de copiar cada nivel de mipmap
        if (texturaOriginal.mipmapCount > 1)
        {
            for (int i = 1; i < texturaOriginal.mipmapCount; i++)
            {
                Graphics.CopyTexture(texturaOriginal, i, texturaConvertida, i);
            }
        }

        // Aplica los cambios para asegurarse de que la textura tenga los datos actualizados
        texturaConvertida.Apply();

        return texturaConvertida;
    }

    // Método para activar el GameObject y luego desactivarlo después de un tiempo
    public void ActivarYDesactivarDespuesDeTiempo()
    {
        if (objetoActivo != null)
        {
            // Activar el GameObject
            objetoActivo.SetActive(true);

            // Llamar al método para desactivar después de 2 segundos (se utiliza Invoke para programar la llamada)
            Invoke("DesactivarGameObject", 2f);
        }
        else
        {
            Debug.LogWarning("¡El GameObject a activar no está asignado!");
        }
    }

    // Método para desactivar el GameObject
    private void DesactivarGameObject()
    {
        if (objetoActivo != null)
        {
            // Desactivar el GameObject
            objetoActivo.SetActive(false);
        }
    }
}
