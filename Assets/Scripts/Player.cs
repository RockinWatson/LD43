using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private List<GameObject> _trapPrefabs = null;

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
        }
    }

    private void PlaceTrap()
    {
        if(_trapPlacement)
        {
            //@TODO: Place trap.
            _trapPlacement.Place();

            _trapPlacement = null;
        }
    }
}
