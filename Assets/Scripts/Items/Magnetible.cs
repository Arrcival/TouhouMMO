using UnityEngine;

namespace Assets.Scripts.Items
{
    [RequireComponent(typeof(Collectible))]
    public class Magnetible : MonoBehaviour
    {
        CollectibleMagnet magnet;
        Collectible collectible;
        float magnetSpeed = 1f;

        public float SpeedGainedWithTime = 2f;
        public float TimeForMaxSpeed = 1f;

        public float SpeedGain = 0f;
        bool magneted = false;
        void Start()
        {
            magnet = FindObjectOfType(typeof(CollectibleMagnet)) as CollectibleMagnet;
            collectible = GetComponent<Collectible>();
            magnetSpeed = magnet.PickupSpeed;
        }

        void Update()
        {
            float distance = Vector2.Distance(magnet.transform.position, transform.position);

            if (distance <= magnet.MagneticFieldDistance)
            {
                magneted = true;
                transform.position = Vector3.MoveTowards(transform.position, magnet.transform.position, (magnetSpeed + SpeedGain) * Time.deltaTime);
                if (distance <= magnet.PickupDistance)
                {
                    magnet.Pick(collectible);
                }
            }

            if (magneted)
            {
                if (SpeedGain < SpeedGainedWithTime)
                    SpeedGain += Time.deltaTime * SpeedGainedWithTime / TimeForMaxSpeed;
            }
        }
    }
}
