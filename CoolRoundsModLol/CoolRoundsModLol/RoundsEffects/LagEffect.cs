using System;
using System.Threading.Tasks;
using UnityEngine;

namespace CoolRoundsModLol.RoundsEffects
{
    class LagEffect : MonoBehaviour
    {
        public Block block;
        public Player player;
        public CharacterData data;
        private Action<BlockTrigger.BlockTriggerType> rewindAction;
        private Vector3 playerPosition = new Vector3(0,0,0);
        private bool teleportQueueing = false;
        float remaining = 5f;
        private void Start()
        {
            if (block)
            {
                rewindAction = new Action<BlockTrigger.BlockTriggerType>(this.GetDoBlockAction(player, block, data));
                block.BlockAction = (Action<BlockTrigger.BlockTriggerType>)Delegate.Combine(block.BlockAction, rewindAction);
            }
        }
        private void Update()
        {
            if (remaining >= 0)
            {
                // Check if phase is card pick (round has ended) and stop lag back
                if (!GameManager.instance.battleOngoing)
                {
                    remaining = -1;
                    teleportQueueing = false;
                    UnityEngine.Debug.Log("Cancel lag back");
                }
                else {
                    remaining -= Time.deltaTime;
                    teleportQueueing = true;
                }
            }
            else if (teleportQueueing)
            {
                teleportQueueing = false;
                player.GetComponentInParent<PlayerCollision>().IgnoreWallForFrames(2);
                player.transform.position = playerPosition;
            }
        }
        public Action<BlockTrigger.BlockTriggerType> GetDoBlockAction(Player player, Block block, CharacterData data)
        {
            return delegate (BlockTrigger.BlockTriggerType trigger)
            {
                playerPosition = player.transform.position;
                remaining = 5f;
            };
        }
        private void OnDestroy()
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
