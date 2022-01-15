using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CoolRoundsModLol
{
    class SwapEffect : MonoBehaviour
    {
        public Block block;
        public Player player;
        public CharacterData data;
        private Action<BlockTrigger.BlockTriggerType> reverseAction;
        private void Start()
        {
            if (block)
            {
                reverseAction = new Action<BlockTrigger.BlockTriggerType>(this.GetDoBlockAction(player, block, data));
                block.BlockAction = (Action<BlockTrigger.BlockTriggerType>)Delegate.Combine(block.BlockAction, reverseAction);
            }
        }
        public Action<BlockTrigger.BlockTriggerType> GetDoBlockAction(Player player, Block block, CharacterData data)
        {
            return delegate (BlockTrigger.BlockTriggerType trigger)
            {
                List<Player> players = PlayerManager.instance.players;
                List<Player> enemies = new List<Player>();

                for (int i = players.Count() - 1; i >= 0; i--)
                {
                    if (!(players[i].teamID == player.teamID))
                    {
                        enemies.Add(players[i]);
                    }
                }

                
                if (enemies.Count < 1)
                {
                    return;
                }

                Player enemy = enemies[0];
                Vector3 enemyPosition = enemy.transform.position;
                Vector3 playerPosition = player.transform.position;

                Vector3 storedEnemyPosition = enemyPosition;
                Vector3 storedPlayerPosition = playerPosition;
                

                enemyPosition = storedPlayerPosition;
                playerPosition = storedEnemyPosition;


                player.GetComponentInParent<PlayerCollision>().IgnoreWallForFrames(2);
                enemy.GetComponentInParent<PlayerCollision>().IgnoreWallForFrames(2);
                enemy.transform.position = enemyPosition;
                player.transform.position = playerPosition;
                


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
