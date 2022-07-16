using System;
using UnityEngine;

namespace General
{
    public class CharacterController : MonoBehaviour
    {
        //saves the animation sprites of the character
        [Serializable]private class CharacterSprites
		
        {
            public Sprite[] walkingSprites;
            public Sprite[] boostingSprites;
            public Sprite[] fallingSprites;
            //public string name;
        }


        public SpriteRenderer CharacterSprite => characterSprite;
        [SerializeField] private SpriteRenderer characterSprite;
        [SerializeField] private CharacterSprites[] Characters;
        [SerializeField] private Rigidbody2D characterRigidbody; 
        [SerializeField] private LifeTracker lifeTracker;
        private float  upForce = 0.5f;
        private float maxVelocityUp =5f;
        private Vector2 upSpeed; 
        private bool boost;

        private int characterSpriteIndex = 0;
        private int characterSpriteWalkingIndex = 0;
        private int characterSpriteBoostingIndex = 0;
        private int  characterSpriteFallingIndex= 0;
        
        // Start is called before the first frame update
        void Start()
        {
            characterRigidbody.freezeRotation = true;
        }
    
        // Update is called once per frame
        void Update()
        {

            //when Jump button (here space) is pressed: remember that
            if (Input.GetButton("Jump"))
            {
                boost = true;
            }
            else
            {
                boost = false;
            }   
        
            var indexer = (int) (Time.time / 0.100f);
       
            //selects the sprite when:
            //boosting
            if (boost)
            {
                characterSpriteBoostingIndex = (indexer) % (Characters[characterSpriteIndex].boostingSprites.Length);
                characterSprite.sprite = Characters[characterSpriteIndex].boostingSprites[characterSpriteBoostingIndex];
            }
            //walking
            else if (characterRigidbody.velocity.y==0)
            {
                characterSpriteWalkingIndex = (indexer) % (Characters[characterSpriteIndex].walkingSprites.Length);
                characterSprite.sprite = Characters[characterSpriteIndex].walkingSprites[characterSpriteWalkingIndex];
            }
            //falling
            else
            {
                characterSpriteFallingIndex = (indexer) % (Characters[characterSpriteIndex].fallingSprites.Length);
                characterSprite.sprite = Characters[characterSpriteIndex].fallingSprites[characterSpriteFallingIndex];
            }

        }

        void FixedUpdate()
        {
            flyUp();
        }

        // sets the character fly up when its time to boost
        private void flyUp()
        {
            if (boost)
            {
                characterRigidbody.AddForce(Vector2.up* upForce, ForceMode2D.Impulse);
                if (characterRigidbody.velocity.y > maxVelocityUp) characterRigidbody.velocity = new Vector2(characterRigidbody.velocity.x, maxVelocityUp);
                
            }
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            //when player touches an enemy, reduce lifePoints
            if (other.gameObject.CompareTag("Enemy"))
            {
                Destroy(other.gameObject);
                lifeTracker.changeLifePoints(-1);
            }
        }
    }
}
