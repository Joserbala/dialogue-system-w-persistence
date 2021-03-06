using UnityEngine;

namespace Joserbala.Serialization
{
    public class PreferencesManager : MonoBehaviour
    {
        public bool Muted = false;

        public float Size;
        public int Volume;
        public string ProfileName;

        public const string KEY_MUTED = "muted";
        public const string KEY_SIZE = "size";
        public const string KEY_PROFILE_NAME = "profileName";
        public const string KEY_VOLUME = "volume";

        public void SavePrefs()
        {
            PlayerPrefs.SetInt(KEY_VOLUME, Volume);
            PlayerPrefs.SetFloat(KEY_SIZE, Size);
            PlayerPrefs.SetString(KEY_PROFILE_NAME, ProfileName);
            PlayerPrefs.SetString(KEY_MUTED, Muted.ToString());

            PlayerPrefs.Save();
        }

        public void LoadPrefs()
        {
            Volume = PlayerPrefs.GetInt(KEY_VOLUME /*, valor por defecto*/);
            Size = PlayerPrefs.GetFloat(KEY_SIZE);
            ProfileName = PlayerPrefs.GetString(KEY_PROFILE_NAME);

            bool.TryParse(PlayerPrefs.GetString(KEY_MUTED), out Muted);
            // Muted = bool.Parse(PlayerPrefs.GetString(KEY_MUTED)); better use TryParse
        }

        public void ResetPrefs()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}