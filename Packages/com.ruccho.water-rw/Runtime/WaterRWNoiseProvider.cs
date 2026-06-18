using UnityEngine;

namespace Ruccho
{
    public class WaterRWInteractionProvider : MonoBehaviour, IWaterRWInteractionProvider
    {
        [SerializeField] private float noiseFrequency;
        [SerializeField] private float noiseAmplitude;

        public Vector2 Velocity
        {
            get
            {
#if UNITY_6000_4_OR_NEWER
                var id = EntityId.ToULong(GetEntityId());
                Random.InitState(unchecked((int)((uint)(id >> 32) ^ (uint)id)));
#endif
                return new Vector2(0f, (Mathf.PerlinNoise1D(noiseFrequency * Time.fixedTime +
#if UNITY_6000_4_OR_NEWER
                                                            Random.value * 100f
#else
                                                            GetInstanceID()
#endif
                                                            * 0.13f) * 2f - 1f) * noiseAmplitude);
            }
        }
    }
}