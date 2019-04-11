using UnityEngine;

namespace ColorSwitch
{
    public class FollowPlayer : MonoBehaviour
    {

        public Transform player;
        public Camera cam;
        public GameManager gm;
        public UIManager ui;

        void Update()
        {
            if (player)
            {
                Vector3 camPos = transform.position;
                Vector3 playerPos = player.position;
                if (playerPos.y > camPos.y)
                {
                    transform.position = new Vector3(camPos.x, playerPos.y, camPos.z);
                }
            }

            if (player)
            {
                if (player.transform.position.y <= cam.transform.position.y - 5)
                {
                    ui.GameOver();
                }
            }

        }
    }
}