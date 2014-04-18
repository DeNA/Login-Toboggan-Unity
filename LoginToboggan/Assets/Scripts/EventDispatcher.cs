using UnityEngine;
using System.Collections;
using Faceblaster.Helper;

namespace Faceblaster
{
	/**
	 * Faceblaster's main MonoBehaviour. Does little other than notify FaceblasterApp
	 * about Unity lifecycle events (separation of concerns).
	 */
	public class EventDispatcher : MonoBehaviour
	{
		void Start ()
		{
			MobageHelper.Instance.Start();

			// we always attempt to do this first; it will restore a Mobage session, if possible
			MobageHelper.Instance.ReestablishSession();

			Debug.Log("Started");
		}
	}
}
