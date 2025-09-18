using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Screenshot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator ScreenShot()
    {
        yield return new WaitForEndOfFrame();
        Texture2D texture = new Texture2D(Screen.width / 2,Screen.height, TextureFormat.RGB24,false);

        texture.ReadPixels(new Rect(Screen.width / 4, 0, Screen.width / 2, Screen.height), 0, 0);
        texture.Apply();

        string name = "Screenshot_EpicApp" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png";

        Destroy(texture );

        //NativeGallery.SaveImageTOGallery(texture, "Myapp Picture", name);

    }

    public void TakeScreenshot()
    {
        StartCoroutine( ScreenShot() );
    }
}
