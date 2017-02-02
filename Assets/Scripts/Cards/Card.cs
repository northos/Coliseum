using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class Card : MonoBehaviour {
	public string cardName;
	public enum CardType {Equipment, Action, Item, Reaction};
	public CardType cardType;
	public int EPCost;
	public int IPCost;
	public int APCost;
	public int RPCost;

	// coroutine performing steps to play this card from hand
	// first get target(s) for card effect (individual cards may need to override this default)
	// then use helper function to execute card effects, which ALL cards will need to override
	protected virtual IEnumerator playCard() {
		GameObject[] targets = new GameObject[1];
		bool done = false;
		while (!done) {
			if (CrossPlatformInputManager.GetAxis ("Fire1") == 1) {
				RaycastHit hit;
				Physics.Raycast (Camera.main.ScreenPointToRay(Input.mousePosition), out hit);
				if (hit.transform != null && hit.transform != gameObject.transform) {
					done = true;
					targets [0] = hit.transform.gameObject;
				}
			}
			yield return null;
		}
		// if costs are payable, pay them and do effect
		if (payCosts ())
			doCardEffect (targets);
	}

	// function to make player pay for the card's cost; should be used by all cards
	// returns whether or not player can pay costs
	// TODO: check all costs first
	protected bool payCosts () {
		Player player = GameObject.FindGameObjectWithTag ("Active Player").GetComponent<Player> ();
		return player.subEIARP(EPCost, IPCost, APCost, RPCost);
	}

	// functino to perform card's effect on the chosen targets
	// base class provides no functionality; individual cards must override to create their own effects
	protected virtual void doCardEffect (GameObject[] targets) {print(targets[0].name);}

	// when clicked, go through the process of playing the card
	protected void OnMouseDown() {
		StartCoroutine (playCard());
	}

	// when moused over, highlight card
	// TODO
	protected void OnMouseEnter() {

	}

	// de-highlight when no longer moused over
	// TODO
	protected void OnMouseExit() {

	}
}
