using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers {
	public class SoundManager : Singleton<SoundManager> {

<<<<<<< HEAD
		void Start(){
			
		}

		void Update(){
		
=======
		[SerializeField]
		AudioSource deathSound;
		[SerializeField]
		AudioSource coltSound;
		[SerializeField]
		AudioSource backgroundMusic;

		public void PlayDeathSound(){
			deathSound.Play();
		}

		public void PlayColtSound(){
			coltSound.Play();
>>>>>>> a4e04b1c5ccf3fec7e21069d0837a035e5217077
		}
	}
}
