using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace CharlesProjects
{
    namespace MenuManagment
    {
        public class MenuManager : MonoBehaviour
        {

            public InputField playerNameInput;
            public InputField playerExperienceInput;
            public InputField playerHealthInput;

            // Use this for initialization
            void Start()
            {
                UpdateInputFields();
            }

            // Update is called once per frame
            void Update()
            {

            }

            public void SetPlayerInfo()
            {
                GameManager.instance.playerInfo.playerName = playerNameInput.text;

                int.TryParse(playerExperienceInput.text, out GameManager.instance.playerInfo.playerExperience);

                float.TryParse(playerHealthInput.text, out GameManager.instance.playerInfo.playerHealth);
            }

            public void UpdateInputFields()
            {
                playerNameInput.text = GameManager.instance.playerInfo.playerName;
                playerExperienceInput.text = GameManager.instance.playerInfo.playerExperience.ToString();
                playerHealthInput.text = GameManager.instance.playerInfo.playerHealth.ToString();
            }
        }
    }
}