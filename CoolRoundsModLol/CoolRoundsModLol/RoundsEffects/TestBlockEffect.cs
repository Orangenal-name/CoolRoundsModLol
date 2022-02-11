using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CoolRoundsModLol.RoundsEffects
{
    class TestBlockEffect : MonoBehaviour
    {
        public Block block;
        public Player player;
        public CharacterData data;
        private Action<BlockTrigger.BlockTriggerType> reverseAction;
        private int random = 1;
        private void Start()
        {
            if (block)
            {
                reverseAction = new Action<BlockTrigger.BlockTriggerType>(this.GetDoBlockAction(player, block, data));
                block.BlockAction = (Action<BlockTrigger.BlockTriggerType>)Delegate.Combine(block.BlockAction, reverseAction);
                random = UnityEngine.Random.Range(-10,10);
            }
        }
        public Action<BlockTrigger.BlockTriggerType> GetDoBlockAction(Player player, Block block, CharacterData data)
        {
            return delegate (BlockTrigger.BlockTriggerType trigger)
            {
                if (random != 0)
                {
                    player.data.stats.sizeMultiplier = random;
                }
                Debug.Log("HJASGDKAJHDK");
            };
        }
        private void OnDestroy()
        {
            block.BlockAction = (Action<BlockTrigger.BlockTriggerType>)Delegate.Remove(block.BlockAction, reverseAction);
        }
        public void Destroy()
        {
            UnityEngine.Object.Destroy(this);
            block.BlockAction = (Action<BlockTrigger.BlockTriggerType>)Delegate.Remove(block.BlockAction, reverseAction);
        }

    }
}
