using PrimeTween;
using UnityEngine;

namespace Game.Scripts.Core.Panel
{
    [CreateAssetMenu]
    public class PanelAnimationData : ScriptableObject
    {
        public TweenSettings<float> alphaSettings;
        public TweenSettings<Vector3> scaleSettings;
    }
}