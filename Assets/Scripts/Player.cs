using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private List<GameObject> _trapPrefabs = null;

    private float _bloodLevel = 50.0f;
    private float _bloodLevelTimer = 0.0f;
    public float GetBloodLevel()
    {
        return _bloodLevel;
    }
    public void AddBloodLevel(float pay)
    {
        _bloodLevel += pay;
    }
    public void SpendBloodLevel(float cost)
    {
        _bloodLevel -= cost;
        _bloodLevel = Mathf.Max(0.0f, _bloodLevel);
    }

    // Trap Placement
    private Trap _trapPlacement = null;
    private int _trapPlacementIndex = -1;

    private Camera _mainCamera = null;

    // Singleton
    static private Player _instance = null;
    static public Player Get()
    {
        return _instance;
    }

    private void Awake()
    {
        _instance = this;

        _mainCamera = Camera.main;
    }
	
	// Update is called once per frame
	void Update () {
        UpdatePlayerInput();

        _bloodLevelTimer += Time.deltaTime;
        if(_bloodLevelTimer >= 5.0f)
        {
            _bloodLevel += 10.0f;
            _bloodLevelTimer = 0.0f;
        }
    }

    private void UpdatePlayerInput() {
        //@TODO: Cycle through numbers for Trap selection.
        UpdatePlayerInputTrapSelection();

    }

    private void UpdatePlayerInputTrapSelection() {
        for(int i = 0; i < _trapPrefabs.Count; ++i)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                SelectTrap(i);
            }
        }

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            //@TODO: Place Trap.
            PlaceTrap();
        }

        UpdateTrapPlacementPos();
    }

    private void SelectTrap(int index)
    {
        if (index != _trapPlacementIndex)
        {
            _trapPlacementIndex = index;

            //@TODO: Clean up any previously selected Trap.
            if (_trapPlacement)
            {
                Destroy(_trapPlacement.gameObject);
            }

            //@TODO: Instantiate Trap as inactive.
            _trapPlacement = Instantiate(_trapPrefabs[index]).GetComponent<Trap>();
        }
    }

    private void UpdateTrapPlacementPos()
    {
        if(_trapPlacement)
        {
            //@TODO: Update trap placement based on mouse position.
            Vector3 pos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            pos.z = _trapPlacement.transform.position.z;
            _trapPlacement.transform.position = pos;

            Color trapColor;
            if(_trapPlacement.GetBloodCost() > _bloodLevel)
            {
                trapColor = Color.red;
                trapColor.a = 0.75f;
            }
            else
            {
                trapColor = Color.white;
                trapColor.a = 0.5f;
            }
            _trapPlacement.GetSpriteRenderer().color = trapColor;
        }
    }

    private void PlaceTrap()
    {
        if(_trapPlacement)
        {
            if (_trapPlacement.GetBloodCost() > _bloodLevel)
            {
                //@TODO: Error noise indicating not enough blood?
                LevelAudioController.noCash.Play();
                return;
            }

            //@TODO: Place trap.
            _trapPlacement.Place();

            switch (_trapPlacementIndex)
            {
                case 0: LevelAudioController.placeTrap.Play();
                    break;
                case 1: LevelAudioController.bubbly.Play();
                    break;
                case 2: LevelAudioController.bubbly.Play();
                    break;
                case 3: LevelAudioController.placeTrap.Play();
                    break;
                case 4: LevelAudioController.placeTrap.Play();
                    break;
                case 5: LevelAudioController.buzzsaw.Play();
                    break;
                case 6: LevelAudioController.placeTrap.Play();
                    break;
                default:
                    break;
            }


            _trapPlacement = null;
            _trapPlacementIndex = -1;
        }
    }

    //private void OnGUI()
    //{
    //    GUI.TextArea(new Rect(0, 0, 200, 200), "BLOOD LEVEL: " + _bloodLevel);
    //}
}
