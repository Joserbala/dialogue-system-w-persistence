using UnityEngine;

namespace Joserbala.Utils
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {

        public static T Instance
        {
            get
            {
                if (Instance == null)
                {
                    Instance = (T)FindObjectOfType(typeof(T));
                }

                return Instance;
            }

            private set => Instance = value;
        }
    }
}