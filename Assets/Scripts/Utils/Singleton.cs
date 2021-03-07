using UnityEngine;

namespace Joserbala.Utils
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {

        private static T instance;

        protected static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = (T)FindObjectOfType(typeof(T));
                }

                return instance;
            }
        }
    }
}