using AC;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

public class RoadPool : MonoBehaviour
{
    public float CharactersSpeed;
    public int PoolingIndex;
    public List<RoadInfo> RoadInfos;

    private Queue<RoadInfo> pool;
    private Player player;
    private List<NPC> npcs;

    public void Awake()
    {
        pool = new Queue<RoadInfo>(RoadInfos);
    }

    public void Start()
    {
        player = FindObjectOfType<Player>();
        npcs = FindObjectsOfType<NPC>().ToList();
    }

    public void Update()
    {
        MovePlayer();
        MoveNPCs();
        Pool();
    }

    private void MoveNPCs()
    {
        npcs.ForEach(hNPC =>
        {
            hNPC.transform.forward = GetDirection(0, 1);
            hNPC.transform.position += hNPC.transform.forward * CharactersSpeed * Time.deltaTime;
        });
    }

    private void Pool()
    {
        if (player.transform.position.z < pool.ElementAt(PoolingIndex).Road.transform.position.z)
        {
            RoadInfo info = pool.Dequeue();
            info.Road.transform.position = pool.Last().Locator.transform.position;
            pool.Enqueue(info);
        }
    }

    private void MovePlayer()
    {
        player.transform.forward = GetDirection(0, 1);
        player.transform.position += player.transform.forward * CharactersSpeed * Time.deltaTime;
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