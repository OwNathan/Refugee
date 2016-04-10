using UnityEngine;

namespace PixelCrushers.DialogueSystem.AdventureCreator {
	
	/// <summary>
	/// Fits a fullscreen Unity UI panel into AC's aspect ratio.
	/// </summary>
	[AddComponentMenu("Dialogue System/Third Party/Adventure Creator/Fit UI To Aspect Ratio")]
	public class FitUIToAspectRatio : MonoBehaviour {

		[Tooltip("The fullscreen panel containing your UI elements")]
		public RectTransform mainPanel;
		
		private bool m_started = false;

		void Start() {
			m_started = true;
			Fit();
		}
		
		void OnEnable() {
			if (m_started) Fit();
		}

		void Fit() {
			if (mainPanel == null)
			{
				Debug.LogError("Assign Main Panel", this);
				return;
			}
			var rect = AC.KickStarter.mainCamera.LimitMenuToAspect(new Rect(0, 0, Screen.width, Screen.height));
			mainPanel.sizeDelta = new Vector2(-2 * rect.x, -2 * rect.y);
		}
	}

}
