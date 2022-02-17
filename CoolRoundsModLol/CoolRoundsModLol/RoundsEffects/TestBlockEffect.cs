using ModdingUtils.MonoBehaviours;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace CoolRoundsModLol.RoundsEffects
{
    class TestBlockEffect : MonoBehaviour
    {
        public Block block;
        public Player player;
        public CharacterData data;
        private Action<BlockTrigger.BlockTriggerType> rewindAction;

        public void Start()
        {
            if (block)
            {
                rewindAction = new Action<BlockTrigger.BlockTriggerType>(this.GetDoBlockAction(player, block, data));
                block.BlockAction = (Action<BlockTrigger.BlockTriggerType>)Delegate.Combine(block.BlockAction, rewindAction);
            }
        }
        public Action<BlockTrigger.BlockTriggerType> GetDoBlockAction(Player player, Block block, CharacterData data)
        {
            return async delegate (BlockTrigger.BlockTriggerType trigger)
            {
                Vector3 playerPosition = player.transform.position;

                await Task.Delay(5000);

                player.GetComponentInParent<PlayerCollision>().IgnoreWallForFrames(2);
                player.transform.position = playerPosition;
            };
        }
        public void OnDestroy()
        {
            block.BlockAction = (Action<BlockTrigger.BlockTriggerType>)Delegate.Remove(block.BlockAction, rewindAction);
        }
        public void Destroy()
        {
            UnityEngine.Object.Destroy(this);
            block.BlockAction = (Action<BlockTrigger.BlockTriggerType>)Delegate.Remove(block.BlockAction, rewindAction);
        }

    }
}
