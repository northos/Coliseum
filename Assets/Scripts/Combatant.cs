using UnityEngine;
using System.Collections;

public class Combatant : MonoBehaviour {
	public GameObject weapon;
	public GameObject offhand;
	public GameObject head;
	public GameObject body;
	public int HP;
	public int maxHP;

	// initialize combatant parameters
	void Start () {
		HP = maxHP;
	}

	// public function allowing other scripts to assign damage to this combatant
	public void takeDamage(int dmg) {
		HP = Mathf.Max (0, HP - dmg);
	}
}
