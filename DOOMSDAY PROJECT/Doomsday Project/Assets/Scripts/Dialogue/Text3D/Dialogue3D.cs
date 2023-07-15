using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Player;
using States.Interfaces;
using Dialogue;
using States.ConcreteStates;
using TMPro;

namespace Dialogue.Text3D
{
    public class Dialogue3D : MonoBehaviour
    {
        private ManageMemory memoryManager;
        private TextMeshPro textComponent;
        private String originalText;
		private bool showingText = false;

		public float slowness;

		public EventHandler<bool> isTextFinishedHandler;

        private void Awake()
        {
            textComponent = GetComponent<TextMeshPro>();
        }

        public void RecieveDialogueText(object sender, String newText)
        {
			originalText = newText;
			StartCoroutine(RevealText());
		}

		public void SetSlowness(float newSlowness)
		{
			this.slowness = newSlowness;
		}

		public void ConnectDialogue(ManageMemory controlingState)
        {
            this.memoryManager = controlingState;
            memoryManager.dialogueHandler += RecieveDialogueText;
        }

		IEnumerator RevealText()
		{
			showingText = true;
			textComponent.text = "";

			yield return new WaitForSeconds(1.5f);

			var numCharsRevealed = 0;
			while (numCharsRevealed < originalText.Length)
			{
				while (originalText[numCharsRevealed] == ' ')
					++numCharsRevealed;

				++numCharsRevealed;

				textComponent.text = originalText.Substring(0, numCharsRevealed);

				yield return new WaitForSeconds(0.025f * slowness);

				switch (originalText[numCharsRevealed - 1])
				{
					case ',':
						yield return new WaitForSeconds(0.08f * slowness);
						break;
					case '.':
						yield return new WaitForSeconds(0.2f * slowness);
						break;
					case '?':
						if (originalText.Length > numCharsRevealed)
						{
							if (originalText[numCharsRevealed] != '!') yield return new WaitForSeconds(0.2f * slowness);
						}
						break;
					case '!':
						yield return new WaitForSeconds(0.2f * slowness);
						break;
					default:
						break;
				}
			}
			showingText = false;
			isTextFinishedHandler?.Invoke(this, true);
			yield return null;
		}

		public bool EstaMostrandoTexto()
		{
			return showingText;
		}

		public void Interrumpir()
		{
			StopAllCoroutines();
			textComponent.text = originalText;
			showingText = false;
		}
	}
}