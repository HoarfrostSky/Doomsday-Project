using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
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

		public AudioClip[] voiceSFX;
		public AudioClip[] altVoiceSFX;
		private AudioSource voice;
		private int voiceN = 0;
		public int maxVoice;

		int a = 1;

        private void Awake()
        {
            textComponent = GetComponent<TextMeshProUGUI>();
			voice = GetComponent<AudioSource>();
        }

		public void RecieveDialogueText(object sender, String newText)
		{
			Debug.Log("se llama a recieve dialogue");
			originalText = newText;
			StartCoroutine(RevealText());
		}

		public void SetSlowness(float newSlowness)
        {
			this.slowness = newSlowness;
        }

		public void ConnectDialogue(DialogueManager d)
        {
			Debug.Log($"se llama a connect dialogue por {a} vez");
			a++;
			this.dialogueManager = d;
            dialogueManager.dialogueHandler += RecieveDialogueText;
        }

		public void DisconnectDialogue()
        {
			dialogueManager.dialogueHandler -= RecieveDialogueText;
		}

		IEnumerator RevealText()
		{
			Debug.Log("se llama a reveal text");

			showingText = true;
			textComponent.text = "";

			yield return new WaitForSeconds(0.5f);

			var numCharsRevealed = 0;
			while (numCharsRevealed < originalText.Length)
			{
				while (originalText[numCharsRevealed] == ' ')
					++numCharsRevealed;

				++numCharsRevealed;

				voiceN++;
				Debug.Log($"n: {voiceN}; maxN: {maxVoice}");
				if(voiceN >= maxVoice)
                {
					Debug.Log($"SONIDO: {originalText.Substring(0, numCharsRevealed)}");
					if(FindObjectOfType<IconUI>().currentName == "***" || FindObjectOfType<IconUI>().currentName == "******")
						voice.PlayOneShot(voiceSFX[(int)UnityEngine.Random.Range(0, voiceSFX.Length)]);
					else
						voice.PlayOneShot(altVoiceSFX[(int)UnityEngine.Random.Range(0, altVoiceSFX.Length)]);
					voiceN = 0;
				}

				textComponent.text = originalText.Substring(0, numCharsRevealed);

				yield return new WaitForSeconds(0.025f * slowness);

				switch (originalText[numCharsRevealed - 1])
				{
					case ',':
						yield return new WaitForSeconds(0.08f * slowness);
						break;
					case '.':
						voiceN = -1;
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