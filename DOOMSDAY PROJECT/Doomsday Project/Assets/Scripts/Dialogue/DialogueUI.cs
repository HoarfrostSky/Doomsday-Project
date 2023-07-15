using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Dialogue;
using TMPro;

namespace Dialogue
{
    public class DialogueUI : MonoBehaviour
    {
        private DialogueManager dialogueManager;
        private TextMeshProUGUI textComponent;
        private String originalText;
		private bool showingText = false;

		public float slowness;

        private void Awake()
        {
            textComponent = GetComponent<TextMeshProUGUI>();
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

		public void ConnectDialogue(DialogueManager d)
        {
            this.dialogueManager = d;
            dialogueManager.dialogueHandler += RecieveDialogueText;
        }

		IEnumerator RevealText()
		{
			showingText = true;
			textComponent.text = "";

			yield return new WaitForSeconds(0.5f);

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