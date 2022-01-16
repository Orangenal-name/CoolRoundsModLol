using Sonigon;
using System;
using UnityEngine;

// Token: 0x020000E8 RID: 232
public class TestBulletMono : RayHitEffect
{
	private void Start()
	{
		if (this.GetComponentInParent<ProjectileHit>() != null)
		{
			this.GetComponentInParent<ProjectileHit>().bulletCanDealDeamage = false;
		}
	}

	// Token: 0x06000048 RID: 72 RVA: 0x00002D1C File Offset: 0x00000F1C
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

	public Color color = new Color(1f, 1f, 0f, 1f);

	public TestBulletMono crit;
}