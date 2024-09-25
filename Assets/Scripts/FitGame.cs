using UnityEngine;
using Screen = UnityEngine.Device.Screen;

public class FitGame : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        print(Screen.currentResolution);
        // Switch to 800 x 600 windowed
        Screen.SetResolution(450, 800, false);
    }
}
