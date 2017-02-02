using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
	public GameObject vanguard;
	public GameObject melee;
	public GameObject ranged;
	public GameObject support;
	public int EP;
	public int IP;
	public int AP;
	public int RP;
	int MAX_RESOURCES = 4;
	public List<GameObject> deck;
	public List<GameObject> discard;
	public List<GameObject> hand;

	// starting game procedure - shuffle deck, draw starting hand
	void Start () {
		shuffle ();
		drawCards (5);
		EP = IP = AP = RP = MAX_RESOURCES;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// randomize the player's deck
	void shuffle() {
		int end = deck.Count;
		while (end > 1) {
			--end;
			int i = Random.Range (0, end + 1);
			GameObject c = deck [i];
			deck [i] = deck[end];
			deck [end] = c;
		}
	}

	// draw an amount of cards from the deck
	public void drawCards (int num) {
		// if num is more than all the cards in deck and discard, draw only that many
		if (num > deck.Count + discard.Count)
			drawCards (deck.Count + discard.Count);
		else {
			for (int i = 0; i < num; ++i) {
				// reshuffle discard into deck once deck is empty
				if (deck.Count == 0) {
					deck = discard;
					discard.Clear ();
					shuffle ();
				}
				hand.Add (deck [0]);
				// TODO: move to hand location
				GameObject newCard = Instantiate (deck [0]);
				deck.RemoveAt (0);
			}
		}
	}

	// public access functions to modify resource values
	public void addEIARP(int numEP = 0, int numIP = 0, int numAP = 0, int numRP = 0) {
		EP += numEP;
		IP += numIP;
		AP += numAP;
		RP += numRP;
	}
	// subtraction function returns whether or not player can pay that cost, and only removes the points if so
	public bool subEIARP(int numEP = 0, int numIP = 0, int numAP = 0, int numRP = 0) {
		if (numEP > EP || numIP > IP || numAP > AP || numRP > RP)
			return false;
		EP -= numEP;
		IP -= numIP;
		AP -= numAP;
		RP -= numRP;
		return true;
	}
}
