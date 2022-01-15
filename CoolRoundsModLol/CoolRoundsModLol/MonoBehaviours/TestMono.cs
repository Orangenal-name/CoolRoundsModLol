using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CoolRoundsModLol.MonoBehaviours
{
    class TestMono : MonoBehaviour
	{
		private Player player;
		private readonly float maxDistance = 7.2f;

		private void Awake()
		{
			this.player = this.GetComponent<Player>();
		}
		private void FixedUpdate()
		{
			//yoinked this if statement from CR Fear Factor Mono
			if (UnityEngine.Object.FindObjectsOfType<MoveTransform>().Where(obj => obj.GetComponent<SpawnedAttack>() != null && obj.GetComponent<SpawnedAttack>().spawner != this.player && Vector3.Distance(this.player.transform.position, obj.transform.position) < this.maxDistance * (Mathf.Pow(this.player.data.maxHealth / 100f * 1.2f, 0.2f) * this.player.data.stats.sizeMultiplier) / 1.2f).Any())
			{
				this.player.data.weaponHandler.gun.Attack(2.5f, true, 0.35f, 1f, false);
			}

		}

	}
}
