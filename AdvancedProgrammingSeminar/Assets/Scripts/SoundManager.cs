using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers {
	public class SoundManager : Singleton<SoundManager> {

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
		}
	}
}
