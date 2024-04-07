using UnityEngine;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        private GameObject manager;

        void Awake()
        {
            manager = gameObject;
            DontDestroyOnLoad(manager);
        }

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}