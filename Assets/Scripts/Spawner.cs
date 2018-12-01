using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] Objects;
    public int ObjectPoolSize;
    public float WaitForNextMax;
    public float WaitForNextMin;
    public float CountDown;

    public GameObject ElfExit;

    private List<GameObject> _objectsPool;
    private Transform _spawnerTrans;

	// Use this for initialization
	void Start () {
        _spawnerTrans = GetComponent<Transform>();
        _objectsPool = new List<GameObject>();
        foreach (var obj in Objects)
        {
            for (int i = 0; i < ObjectPoolSize; i++)
            {
                GameObject o = Instantiate(obj);
                o.SetActive(false);
                Elf elfScript = o.GetComponent<Elf>();
                elfScript.ElfExit = ElfExit;
                _objectsPool.Add(o);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        CountDown -= Time.deltaTime;
        if (CountDown <= 0)
        {
            SpawnRandObj(_objectsPool, _spawnerTrans);
            CountDown = Random.Range(WaitForNextMin, WaitForNextMax);
        }
	}

    private void SpawnRandObj(List<GameObject> objPool, Transform transform) {
        if (objPool != null)
        {
            GameObject gameObj = objPool[Random.Range(0, objPool.Count)];
            if (!gameObj.activeInHierarchy)
            {
                InstantiateObject(gameObj, transform);
            }
        }
    }

    private void InstantiateObject(GameObject gameObj, Transform transform){
        Vector2 pos;
        pos = new Vector2(transform.position.x, transform.position.y);
        gameObj.transform.position = pos;
        gameObj.SetActive(true);
    }
}
