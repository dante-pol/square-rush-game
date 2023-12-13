using UnityEngine;

namespace Root.Assets._Scripts.Tools
{
    public class ScreenCuster : MonoBehaviour
    {
        [SerializeField] private KeyCode _keyForCust;

        private int _count;

        private void Update()
        {
            if (Input.GetKeyDown(_keyForCust)) Cust();
        }

        private void Cust()
            => ScreenCapture.CaptureScreenshot($"img_{_count++}.png");
    }
}
