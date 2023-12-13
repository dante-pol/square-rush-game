using Root.Assets._Scripts.Core.Interfaces;
using UnityEngine;

namespace Root.Assets._Scripts.Gameplay.InputSystems
{
    public class MobileInputSystem : BaseInputSystem
    {
        public MobileInputSystem(IUpdaterLoop updaterLoop, IGameEventer gameEventer) : base(updaterLoop, gameEventer)
        {
        }

        public override void CheckTap()
        {
            if (Input.touchCount > 0)
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                    CheckTap();
        }
    }
}
