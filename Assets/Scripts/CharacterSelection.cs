
using UnityEngine;



    public class CharacterSelection : MonoBehaviour
    {

        #region Serialized.
        /// <summary>
        /// 
        /// </summary>
        [Tooltip("Character this object represents.")]
        [SerializeField]
        private CharacterTypes _characterType;
        /// <summary>
        /// Character this object represents.
        /// </summary>
        public CharacterTypes CharacterType { get { return _characterType; } }
        #endregion

        #region Private.
        /// <summary>
        /// SpawningCanvas to report actions to.
        /// </summary>
        private SpawningCanvas _spawningCanvas;
        #endregion

        /// <summary>
        /// Initializes this script for use. Should only be completed once.
        /// </summary>
        /// <param name="sc"></param>
        public void FirstInitialize(SpawningCanvas sc)
        {
            _spawningCanvas = sc;
        }

        /// <summary>
        /// Called when this button is clicked.
        /// </summary>
        public void OnClick_Button()
        {
            _spawningCanvas.SelectCharacter(this);
        }
    }


