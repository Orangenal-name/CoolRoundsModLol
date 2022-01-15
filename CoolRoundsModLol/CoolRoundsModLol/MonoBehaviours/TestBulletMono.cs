using Sonigon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CoolRoundsModLol.MonoBehaviours
{
	class TestBulletMono : RayHitEffect
	{
		private void Start()
		{
			if (this.GetComponentInParent<ProjectileHit>() != null)
			{
				this.GetComponentInParent<ProjectileHit>().bulletCanDealDeamage = false;
			}
		}
		public override HasToReturn DoHitEffect(HitInfo hit)
		{
			if (!hit.transform)
			{
				return HasToReturn.canContinue;
			}
			TestBulletMono[] componentsInChildren = this.transform.root.GetComponentsInChildren<TestBulletMono>();
			ProjectileHit componentInParent = this.GetComponentInParent<ProjectileHit>();
			DamageOverTime component = hit.transform.GetComponent<DamageOverTime>();
			if (component)
			{
				crit = hit.transform.gameObject.AddComponent<TestBulletMono>();
				component.TakeDamageOverTime(componentInParent.damage * 2f * base.transform.forward, base.transform.position, this.time, this.interval, this.color, this.soundEventDamageOverTime, base.GetComponentInParent<ProjectileHit>().ownWeapon, base.GetComponentInParent<ProjectileHit>().ownPlayer, true);
			}
			return HasToReturn.canContinue;
		}
		public void Destroy()
		{
			UnityEngine.Object.Destroy(this);
		}

		[Header("Sounds")]
		public SoundEvent soundEventDamageOverTime;

		[Header("Settings")]
		public float time = 0.1f;

		public float interval = 0.1f;

		public TestBulletMono crit;

        private Color color = new Color(255, 255, 0);
    }
}
