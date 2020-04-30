using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{

    private float _horizontalInput, _verticalInput;

    private Vector3 _movementInput;
    [SerializeField]
    private float _movementSpeed = 5.0f;

    private bool _isJumping = false;
    private float _jumpHeight = 0.4f;
    private float _gravity = 0.981f;  //0.981

    private Vector3 _heightMovement, _verticalMovement, _horizontalMovement;

    private CharacterController _characterController;
    private Animator _animator;

    private GameObject _camera;
    private CameraLogic _cameraLogic;
    [SerializeField]
    private int _health = 3;
    [SerializeField]
    private int _numOfHearts = 3;

    public Image[] Hearts;
    public Sprite Fullheart;
    public Sprite EmptyHeart;


    [SerializeField]
    private int _rupeeCount = 0;
    [SerializeField]
    private int _bombCount = 20;
    private int _maxBombs = 20;

    // attacking
    public bool _isAttacking = false;

    private GameObject _sword;
    private BoxCollider _swordCollider;

    private SoundManager _soundManager;


    private bool _hasChicken = false;

    public GameObject Boomerang;
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        _sword = GameObject.Find("Sword");
        _swordCollider = _sword.GetComponent<BoxCollider>();
        _swordCollider.enabled = false;

        _camera = Camera.main.gameObject;
        if (_camera)
        {
            _cameraLogic = _camera.GetComponent<CameraLogic>();
            
        }
        GameObject Soundmanager = GameObject.Find("SoundManager");
        _soundManager = Soundmanager.GetComponent<SoundManager>();
    }

    void Update()
    {
        ManageHealth();

        InputPlayer();
        if (Input.GetButtonDown("Fire1"))
        {
            setAttack();
        }
        if (Input.GetButton("Fire2"))
        {
            _animator.SetBool("IsShielding", true);
        }
        else
        {
            _animator.SetBool("IsShielding", false);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            
            Instantiate(Boomerang, GameObject.Find("Destination").transform.position, transform.rotation);
        }

    }

    private void InputPlayer()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");

        _movementInput = new Vector3(_horizontalInput, 0, _verticalInput);

        if (Input.GetButton("Jump") && _characterController.isGrounded)
        {
            _isJumping = true;
        }

        if (_animator)
        {
            _animator.SetFloat("HorizontalInput", _horizontalInput);
            _animator.SetFloat("VerticalInput", _verticalInput);
        }
    }

    private void FixedUpdate()
    {
        FaceForward();
        PlayerMovement();
    }

    private void FaceForward()
    {
        // face the player towards the direction of the camera
        if (_cameraLogic && (Mathf.Abs(_horizontalInput) > 0.1f || Mathf.Abs(_verticalInput) > 0.1f))
        {
            transform.forward = _cameraLogic.GetForwardVector();
        }

    }
    private void ChickenGravity()
    {
        _gravity = 0.2f;
    }
    private void RegularGravity()
    {
        _gravity = 0.981f;
    }
    private void PlayerMovement()
    {
        // let player jump and make sure its only once
        if (_isJumping)
        {
            _animator.SetBool("IsJumping", true);
            _heightMovement.y = _jumpHeight;
            // chicken is a WIP
            if (_hasChicken == true)
            {
                Invoke("ChickenGravity", 0.25f);
            }
            _isJumping = false;
        }

        _heightMovement.y -= _gravity * Time.deltaTime;
        // this moves the player
        _verticalMovement = transform.forward * _verticalInput * _movementSpeed * Time.deltaTime;
        _horizontalMovement = transform.right * _horizontalInput * _movementSpeed * Time.deltaTime;

        _characterController.Move(_horizontalMovement + _verticalMovement + _heightMovement);
        if (_characterController.isGrounded)
        {
            // this function is a wip w/ chickens
            RegularGravity();

            _heightMovement.y = 0.0f;
            _animator.SetBool("IsJumping",false);

        }
    }
    // player attacks
    private void setAttack()
    {
        _isAttacking = true;
         _animator.SetBool("IsAttacking", true);
        _swordCollider.enabled = true;
        Invoke("setAttackFalse", 1f);
        _soundManager.PlayAttack();
    }
    // attack ends
    private void setAttackFalse()
    {
        _swordCollider.enabled = false;
        _isAttacking = false;
        _animator.SetBool("IsAttacking", false);
    }


    


    // TO DO LIST: MANAGE HEALTH/RUPEE/BOMB/ARROW... in one function with a switch

    // regulate health
    private void ManageHealth()
    {
        if (_health > _numOfHearts) _health = _numOfHearts; //Cap health so it doesnt go above heart 

        for (int i = 0; i < Hearts.Length; i++)
        {
            //display correct sprite
            if (i < _health) Hearts[i].sprite = Fullheart; // if you have the correct amount of health, the Fullheart will show
            else Hearts[i].sprite = EmptyHeart; // if you have the correct amount of health, the EmptyHeart will show

            //display hearts
            if (i < _numOfHearts) Hearts[i].enabled = true;
            else Hearts[i].enabled = false;
        }
    }
    // gain 1 heart of health back
    public void GainHealth()
    {
        _health++;
    }
    // lose 1 heart of health
    public void ApplyDamage()
    {
        _health--;
    }
    // gain 1 extra heart slot (More total HP)
    public void GainHeart()
    {
        _numOfHearts++;
    }

    public void GainRupee()
    {
        _rupeeCount++;
    }
    public int ReturnRupeeCount()
    {
        return _rupeeCount; 
    }
    public int ReturnBombCount()
    {
        return _bombCount;
    }
    public void UseBomb()
    {
        _bombCount--;
    }
    public void GainBomb()
    {
        _bombCount+=5;
        if (_bombCount > _maxBombs)
        {
            // cap it at maxbombs
            _bombCount = _maxBombs;
        }
    }

    public void CuccooSwitch()
    {
        _hasChicken = true;
    }  
    public void CuccooSwitchOff()
    {
        _hasChicken = false;
    }
}
