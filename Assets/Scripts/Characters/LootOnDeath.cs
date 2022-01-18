using Assets.Scripts.Items.Equipments;
using Assets.Scripts.Others;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Characters
{
    [System.Serializable]
    public class LootEquipment
    {
        public int Tier;
        [Range(0f, 1f)]
        public float Chances;
    }
    [System.Serializable]
    public class LootItem
    {
        public int ItemID;
        [Range(0f, 1f)]
        public float Chances;
    }
    [RequireComponent(typeof(Enemy))]
    public class LootOnDeath : MonoBehaviour
    {
        Enemy enemy;

        public LootEquipment[] equipments;
        public LootItem[] items;
        // Start is called before the first frame update
        void Start()
        {
            enemy = GetComponent<Enemy>();
            enemy.On_Death.AddListener(EnemyDeath);
        }

        List<AnyItem> GetItems()
        {
            Random.InitState((int)System.DateTime.Now.Ticks);
            List<AnyItem> looted = new List<AnyItem>();
            int seed = Random.Range(1, Statics.SEED_MAX);
            Random.InitState(seed);

            for (int i = 0; i < equipments.Length; i++)
            {
                float roll = Random.Range(0f, 1f);
                if (roll <= equipments[i].Chances)
                    looted.Add(EquipableStatics.GenerateEquipment(equipments[i].Tier, Random.Range(1, Statics.SEED_MAX)));
            }
            for (int i = 0; i < items.Length; i++)
            {

                float roll = Random.Range(0f, 1f);
                if (roll <= equipments[i].Chances)
                    looted.Add(EquipableStatics.GenerateItem(items[i].ItemID));
            }

            return looted;
        }

        public void EnemyDeath()
        {
            List<AnyItem> items = GetItems();

            if (items.Count > 0)
            {
                for (int i = 0; i < Statics.Containers.Count; i++)
                {
                    GameObject c = Statics.Containers[i];
                    if (Vector2.Distance(c.transform.position, transform.position) <= Statics.MAX_DISTANCE_FOR_CONTAINER)
                    {
                        // this and break;;
                        Container container = c.GetComponent<Container>();
                        container.AddItems(items);
                        return;
                    }
                }

                GameObject GO = Instantiate(Statics.ContainerObject);
                GO.transform.position = transform.position;
                Container cnt = GO.GetComponent<Container>();
                cnt.AddItems(items);
            }
        }
    }
}

