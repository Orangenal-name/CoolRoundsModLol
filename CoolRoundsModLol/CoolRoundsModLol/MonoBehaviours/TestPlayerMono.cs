using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CoolRoundsModLol.MonoBehaviours
{
    class TestPlayerMono : MonoBehaviour
	{
		private Player player;
		private Gun gun;

		private void Awake()
		{
			this.player = this.GetComponent<Player>();
			this.gun = this.player.GetComponent<Holding>().holdable.GetComponent<Gun>();
		}
		private void FixedUpdate()
		{
			gun.bulletDamageMultiplier = (player.data.maxHealth - player.data.health);
		}
	}
}
