using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Mirror;


    public class SpawningCanvas : MonoBehaviour
    {
        #region Private.
        /// <summary>
        /// Current player instance.
        /// </summary>
        private PlayerInstance _playerInstance;
        /// <summary>
        /// CanvasGroup on this object.
        /// </summary>
        private CanvasGroup _canvasGroup;
        #endregion  


        private void Awake()
        {
            //Initialize character selections.
            CharacterSelection[] characterSelections = gameObject.GetComponentsInChildren<CharacterSelection>();
            foreach (CharacterSelection cs in characterSelections)
                cs.FirstInitialize(this);
            //Listen for when player instance spawns.
            PlayerInstance.OnPlayerInstance += PlayerInstance_OnPlayerInstance;

            _canvasGroup = GetComponent<CanvasGroup>();
            Hide();
        }

        /// <summary>
        /// Received when this player instance is set as the local player.
        /// </summary>
        /// <param name="obj"></param>
        private void PlayerInstance_OnPlayerInstance(PlayerInstance obj)
        {
            _playerInstance = obj;
        }

        /// <summary>
        /// Show this canvas.
        /// </summary>
        public void Show()
        {
            _canvasGroup.alpha = 1f;
            _canvasGroup.blocksRaycasts = true;
            _canvasGroup.interactable = true;
        }

        /// <summary>
        /// Hides this canvas.
        /// </summary>
        public void Hide()
        {
            _canvasGroup.alpha = 0f;
            _canvasGroup.blocksRaycasts = false;
            _canvasGroup.interactable = false;
        }

        /// <summary>
        /// Selects a character as set on CharacterSelection.
        /// </summary>
        /// <param name="selection"></param>
        public void SelectCharacter(CharacterSelection selection)
        {
            _playerInstance.PlayerSpawner.TrySpawn(selection.CharacterType);
        }

    }


