using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class Whetstone : Card {
	// coroutine performing steps to play this card from hand
	// first get target(s) for card effect (individual cards may need to override this default)
	// then use helper function to execute card effects, which ALL cards will need to override
	protected override IEnumerator playCard() {
		GameObject[] targets = new GameObject[1];
		targets[0] = GameObject.FindGameObjectWithTag ("Active Player");
		// if costs are payable, pay them and do effect
		if (payCosts ())
			doCardEffect (targets);
		yield return null;
	}

	// functino to perform card's effect on the chosen targets
	// base class provides no functionality; individual cards must override to create their own effects
	protected override void doCardEffect (GameObject[] targets) {
		targets [0].GetComponent<Player> ().addEIARP (1);
	}
}
