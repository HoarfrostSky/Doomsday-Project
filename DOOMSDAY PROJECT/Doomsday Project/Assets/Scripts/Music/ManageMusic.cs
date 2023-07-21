using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Souls.Interfaces;
using Music.Interfaces;

namespace Music
{
    public class ManageMusic : AMusicManager
    {
        public AudioClip[] HarnLayers;
        public AudioClip[] StrangeLayers;
        public AudioClip[] NurLayers;
        public AudioClip[] BrettaLayers;
        public AudioClip[] HayureLayers;
        public AudioClip[] ColinLayers;
        public AudioClip[] LennaLayers;

        public override void StartMusic(int n)
        {
            switch(n)
            {
                case 0: //Aleatorio
                    Debug.Log("Se ha elegido musica para aleatorio");
                    
                    break;
                case 1: //Harn
                    Debug.Log("Se ha elegido musica para Harn");
                    RegisterLayers(HarnLayers);
                    

                    break;
                case 2: //Strange
                    Debug.Log("Se ha elegido musica para Strange");
                    RegisterLayers(StrangeLayers);

                    break;
                case 3: //Nur
                    Debug.Log("Se ha elegido musica para Nur");
                    RegisterLayers(NurLayers);

                    break;
                case 4: //Bretta
                    Debug.Log("Se ha elegido musica para Bretta");
                    RegisterLayers(BrettaLayers);

                    break;
                case 5: //Hayure
                    Debug.Log("Se ha elegido musica para Hayure");
                    RegisterLayers(HayureLayers);

                    break;
                case 6: //Colin
                    Debug.Log("Se ha elegido musica para Colin");
                    RegisterLayers(ColinLayers);

                    break;
                case 8: //Lenna
                    Debug.Log("Se ha elegido musica para Lenna");
                    RegisterLayers(LennaLayers);

                    break;

            }
        }        
    }
}
