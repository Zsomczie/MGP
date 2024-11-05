using System.Collections;
using UnityEngine;

// This is a device camera demo which attempts to display device camera output to the screen.
public class CameraDemo : MonoBehaviour
{
    [SerializeField] private MeshRenderer cameraFeed;
    [SerializeField] private float cameraSize = 10f;

    private static WebCamTexture deviceCameraTexture = null;
    private WebCamDevice[] cameraDevices;
    private bool sizeInfoRetrieved = false;
    private bool isCameraAvailable = false;

    private readonly float initialDelay = 5f;

    private void Start()
    {
        // Enable camera feed renderer object.
        cameraFeed.gameObject.SetActive(true);

        // Initialize device camera coroutine.
        StartCoroutine(InitializeDeviceCamera());
    }

    private IEnumerator InitializeDeviceCamera()
    {
        // Start the camera device check after a small delay.
        yield return new WaitForSeconds(initialDelay);

        // Wait until any camera device can be found.
        while (WebCamTexture.devices.Length == 0)
        {
            yield return new WaitForSeconds(1f);
        }

        // Try to favor front facing camera, otherwise use camera at first index.
        int selectedCameraIndex = 0;
        cameraDevices = WebCamTexture.devices;
        for (int i = 0; i < cameraDevices.Length; i++)
        {
            if (cameraDevices[i].isFrontFacing)
            {
                selectedCameraIndex = i;
            }
        }

        // Create a new web cam texture from the selected camera feed.
        deviceCameraTexture = new WebCamTexture(WebCamTexture.devices[selectedCameraIndex].name);
        cameraFeed.material.mainTexture = deviceCameraTexture;
        
        // Start playing camera feed when ready.
        if (cameraDevices.Length != 0)
        {
            deviceCameraTexture.Play();
            isCameraAvailable = true;
        }
    }
    
    private void Update()
    {
        // WebCamTexture height and width does not return correct values at start.
        // This method keeps checking until correct values can be retrieved.
        if (!sizeInfoRetrieved)
        {
            if (isCameraAvailable && cameraDevices.Length != 0)
            {
                if (deviceCameraTexture.width < 100)
                {
                    Debug.Log("Waiting for correct camera feed size info...");
                    return;
                }

                Debug.Log("Correct camera feed info found (" + deviceCameraTexture.width + " x " + deviceCameraTexture.height + ")");
                // Scale camera feed transform accordingly so that it won't look stretched.
                float aspectRatio = deviceCameraTexture.height / (float)deviceCameraTexture.width;
                cameraFeed.transform.localScale = new Vector3(-cameraSize * 2f, cameraSize * aspectRatio * 2f);
                sizeInfoRetrieved = true;
            }
        }
    }
}