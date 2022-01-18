using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Characters
{
    [RequireComponent(typeof(Player))]
    public class PlayerStats : MonoBehaviour
    {

        // Start is called before the first frame update
        void Start()
        {
            GetComponent<Player>().On_Enemy_Death.AddListener(RegisterEnemyDeath);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void RegisterEnemyDeath(Enemy enemy)
        {
            // nothing yet
        }
    }

}
