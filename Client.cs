using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Enhackse
{
    public class Client : MonoBehaviour
    {
        public bool infiniteTimer = false;
        public bool noBreak = false;
        public bool instantCraft = false;
        public float previousTime = 0.0f;

        public GameManager gameManager;
        public ItemSpawner itemSpawner;

        private void Start()
        {
            this.gameManager = UnityEngine.Object.FindObjectOfType<GameManager>();
            this.itemSpawner = UnityEngine.Object.FindObjectOfType<ItemSpawner>();
        }

        private void Update()
        {
            if (this.gameManager == null)
            {
                this.gameManager = UnityEngine.Object.FindObjectOfType<GameManager>();
            }

            if (this.itemSpawner == null)
            {
                this.itemSpawner = UnityEngine.Object.FindObjectOfType<ItemSpawner>();
            }

            if (infiniteTimer)
            {
                gameManager.TimeRemaining = 9999.0f;
            }

            if (noBreak)
            {
                if (itemSpawner.currentObject != null)
                {
                    var item = itemSpawner.currentObject.GetComponent<Item>();
                    if (item.state == Item.State.Broken)
                    {
                        item.state = Item.State.Crafted;

                        // motherfucker
                        SpriteRenderer spriteRenderer = item.GetComponent<SpriteRenderer>();
                        spriteRenderer.sprite = item.craftedSprite;
;                    }
                }
            }

            if (instantCraft)
            {
                if (itemSpawner.currentObject != null)
                {

                    var item = itemSpawner.currentObject.GetComponent<Item>();
                    if (item.upgradeChance < 1.0f)
                    {
                        item.upgradeChance = 1.0f;
                    } 
                }
            }
        }

        void OnGUI()
        {
            UIHelper.Begin("Test", 50, 128, 128, 256, 5, 30, 20);

            // Basic Cheats
            if (UIHelper.Button("Infinite Time", infiniteTimer))
            {
                infiniteTimer = !infiniteTimer;

                if (infiniteTimer == true)
                {
                    previousTime = gameManager.TimeRemaining;
                } else
                {
                    gameManager.TimeRemaining = previousTime;
                }
            }

            if (UIHelper.Button("Anti-Break", noBreak))
            {
                noBreak = !noBreak;
            }

            if (UIHelper.Button("Instant Craft", instantCraft))
            {
                instantCraft = !instantCraft;
            }
        }
    }
}
