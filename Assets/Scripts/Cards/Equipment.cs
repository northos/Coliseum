using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class Equipment : Card {
	public int durability;
	public enum EquipType {Head, Weapon, Offhand, Body};
	public EquipType equipmentType;
	public CardType cardType = CardType.Equipment;

	// coroutine performing steps to play this card from hand
	// first get target(s) for card effect (individual cards may need to override this default)
	// then use helper function to execute card effects, which ALL cards will need to override
	protected virtual IEnumerator playCard() {
		GameObject[] targets = new GameObject[1];
		// if costs are payable, pay them and do effect
		if (payCosts ())
			doCardEffect (targets);
		yield return null;
	}

	// functino to perform card's effect on the chosen targets
	// TODO: equipment functionality
	protected virtual void doCardEffect (GameObject[] targets) {

	}
}
