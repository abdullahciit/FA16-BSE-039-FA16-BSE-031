using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {
	Animator animator;

	[SerializeField] private float health = 100.0f;

	public bool isPlayer = false;
	public bool removeColliderOnDeath = false;
	public HealthManager referer;	// Special prorperty for create multiple hit system, if it sets on GameObject that has same HealthManager, Apply Damage to it.
	public float damageFactor = 1.0f;
    public Slider healthBar;
    public GameObject barrier;

    void Start() {
        animator = GetComponent<Animator>();

        if (isPlayer) {
            healthBar = GameObject.Find("UI/InGameUI/CharacterStatus/HealthSlider").GetComponent<Slider>();
            healthBar.maxValue = health;
            healthBar.minValue = 0;
        }
    }

	void Update() {
        if (isPlayer) {
            healthBar.value = health;
        }
    }
	
	public void ApplyDamage(float damage) {
		if(IsDead) return;

		damage *= damageFactor;

		if(referer) {
			referer.ApplyDamage(damage);
		}
		else {
			health -= damage;

			if(health <= 0) {
				health = 0;
				
				if(animator) {
					animator.SetTrigger("Dead");
				}
				
				if(removeColliderOnDeath) {
					RemoveColliders(GetComponents<Collider>());
					RemoveColliders(GetComponentsInChildren<Collider>());

                    if(barrier != null) {
                        barrier.SetActive(false);
                    }
				}
			}
		}
	}

	public void SetHealth(float newHealth) {
		health = newHealth;
	}

	public bool IsDead {
		get {
			if(!referer) {
				return health <= 0;
			}
			else {
				return referer.IsDead;
			}
		}
	}

	void RemoveColliders(Collider[] colliders) {
		foreach(Collider collider in colliders) {
			collider.enabled = false;
		}
	}
}
