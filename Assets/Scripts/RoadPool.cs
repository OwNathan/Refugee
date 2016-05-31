using AC;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

public class RoadPool : MonoBehaviour
{
    public List<RoadInfo> RoadInfos;
    public float PlayerSpeed;

    private Queue<RoadInfo> pool;
    private Player player;

    public void Awake()
    {
        pool = new Queue<RoadInfo>(RoadInfos);
    }

    public void Start()
    {
        player = FindObjectOfType<Player>();
        //player.transform.forward = GetDirection(0, 1);
    }

    public void Update()
    {
        MovePlayer();
        Pool();
    }

    private void Pool()
    {
        if (player.transform.position.z < pool.ElementAt(1).Road.transform.position.z)
        {
            RoadInfo info = pool.Dequeue();
            info.Road.transform.position = pool.Last().Locator.transform.position;
            pool.Enqueue(info);
        }
    }

    private void MovePlayer()
    {
        player.transform.forward = GetDirection(0, 1);
        player.transform.position += player.transform.forward * PlayerSpeed * Time.deltaTime;
    }

    private Vector3 GetDirection(int from, int to)
    {
        return pool.ElementAt(to).Locator.position - pool.ElementAt(from).Locator.position;
    }

    [System.Serializable]
    public class RoadInfo
    {
        public GameObject Road;
        public Transform Locator;
    }
}