using UnityEngine;
using UnityEngine.Events;

namespace ColorSwitch
{
    public class Player : MonoBehaviour
    {
        public float jumpForce = 10f;

        public Rigidbody2D rigid;
        public SpriteRenderer rend;
        public bool alive = true;
        public Color[] colors = new Color[4];
        public Color tempColor;
        public UnityEvent onGameOver;

        private Color currentColor;

        public GameManager gm;
        public UIManager ui;

        void Start()
        {
            RandomizeColor();
        }

        // Update is called once per frame
        void Update()
        {
            if (!ui.gameOverScreen.activeSelf)
            {
                if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
                {
                    rigid.velocity = Vector2.up * jumpForce;
                }
            }
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.name == "ColorChanger")
            {
                RandomizeColor();
                Destroy(col.gameObject);
                return;
            }

            if (col.name == "Star")
            {
                // Add score
                gm.score++;
                //Update score text
                ui.scoreText.text = "Score: " + gm.score;
                //Destroy the star
                Destroy(col.gameObject);
                return;
            }

            if (col.name == "FinishLine")
            {
                ui.WinGame();
            }

            SpriteRenderer spriteRend = col.GetComponent<SpriteRenderer>();
            if (spriteRend != null &&
               spriteRend.color != rend.color)
            {
                alive = false;
                Debug.Log("GAME OVER!");
                //onGameOver.Invoke();

            }
        }

        void RandomizeColor()
        {
            tempColor = rend.color;

            for (int i = 0; i < 5; i++)
            {
                int index = Random.Range(0, 4);
                rend.color = colors[index];
                if (rend.color != tempColor)
                {
                    break;
                }
            }

        }
    }
}