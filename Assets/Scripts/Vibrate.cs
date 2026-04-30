using UnityEngine;

public class Vibrate : MonoBehaviour
{
    public void ShakeIt()
    {
        // CAUTION : put this in comment if you need to build on PC
        Handheld.Vibrate();
    }
}
