using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CoolRoundsModLol
{
    class ByeByeEffect : MonoBehaviour
    {
        public Block block;
        public Player player;
        public CharacterData data;
        private Action<BlockTrigger.BlockTriggerType> behindYouAction;
        private void Start()
        {
            if (block)
            {
                behindYouAction = new Action<BlockTrigger.BlockTriggerType>(this.GetDoBlockAction(player, block, data));
                block.BlockAction = (Action<BlockTrigger.BlockTriggerType>)Delegate.Combine(block.BlockAction, behindYouAction);
                //block.BlockAction += behindYouAction;
            }
        }
        public Action<BlockTrigger.BlockTriggerType> GetDoBlockAction(Player player, Block block, CharacterData data)
        {
            return delegate (BlockTrigger.BlockTriggerType trigger)
            {
                List<Player> players = PlayerManager.instance.players;
                List<Player> enemies = new List<Player>();

                for (int i = players.Count(); i >= 0; i--)
                {
                    if (!(players[i].teamID == player.teamID))
                    {
                        enemies.Add(players[i]);
                    }
                }

                Vector3 playerPosition = player.transform.position;
                if (enemies.Count < 1)
                {
                    UnityEngine.Debug.Log("No Enemies");
                    return;
                }

                Player enemy = enemies[0];
                Vector3 enemyPosition = enemy.transform.position;

                Vector3 storedPlayerPosition = playerPosition;
                Vector3 storedEnemyPosition = enemyPosition;

                enemyPosition = storedPlayerPosition;
                playerPosition = storedEnemyPosition;


                player.GetComponentInParent<PlayerCollision>().IgnoreWallForFrames(2);
                player.transform.position = playerPosition;


            };
        }
        private void OnDestroy()
        {
            block.BlockAction = (Action<BlockTrigger.BlockTriggerType>)Delegate.Remove(block.BlockAction, behindYouAction);
            //block.BlockAction -= behindYouAction;
        }
        public void Destroy()
        {
            UnityEngine.Object.Destroy(this);
            block.BlockAction = (Action<BlockTrigger.BlockTriggerType>)Delegate.Remove(block.BlockAction, behindYouAction);
        }

    }
}
