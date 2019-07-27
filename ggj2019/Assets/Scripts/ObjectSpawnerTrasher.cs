using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSpawnerTrasher : MonoBehaviour
{
    [SerializeField] float m_spawnSec;
    float m_currentTime = 0;
    Sprite[] m_itemSprites;
    public event System.Action<string> m_onItemDragEnded; 

    public void SetTimeSpawn(float second)
    {
        m_spawnSec = second;
    }

    private void Start()
    {
        m_itemSprites = Resources.LoadAll<Sprite>("Items");
    }

    private void Update()
    {
        m_currentTime += Time.deltaTime;
        if (m_currentTime > m_spawnSec)
        {
            SpawnObj();
            CheckAndDeleteItem();
            m_currentTime = 0;
        }
    }

    void SpawnObj()
    {
        GameObject instance = Instantiate(Resources.Load("ListItem", typeof(GameObject))) as GameObject;
        instance.transform.SetParent(transform,false);
        instance.transform.SetAsFirstSibling();
        DraggableItem draggableItemComponent = instance.GetComponent<DraggableItem>();
        if (draggableItemComponent != null)
        {
            draggableItemComponent.m_onEndDragItem += onListItemDragEnded;
            draggableItemComponent.SetImage(m_itemSprites[Random.Range(0, m_itemSprites.Length)]);
        }
    }

    void CheckAndDeleteItem()
    {
        if (transform.childCount > 7)
        {
            GameObject.Destroy(transform.GetChild(transform.childCount-1).gameObject);
        }
    }

    void onListItemDragEnded(Vector3 position, Sprite sprite)
    {
        GameObject instance = Instantiate(Resources.Load("InGameItem", typeof(GameObject)), null) as GameObject;
        instance.transform.position = position;
        SpriteRenderer spriteRenderer = instance.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = sprite;
        }
        Rigidbody2D instanceRigidbody = instance.GetComponent<Rigidbody2D>();
        if (instanceRigidbody != null && sprite.name.Contains("Under"))
        {
            ConstantForce2D antiGravity = instanceRigidbody.gameObject.AddComponent<ConstantForce2D>();
            antiGravity.force = new Vector3(0.0f, 9.81f, 0.0f);
            instanceRigidbody.gravityScale = 0;
        }
        Vector2 S = instance.GetComponent<SpriteRenderer>().sprite.bounds.size;
        instance.GetComponent<BoxCollider2D>().size = S;
        instance.GetComponent<BoxCollider2D>().offset = Vector2.zero;// ((S.x / 2), 0);
        if (m_onItemDragEnded != null)
            m_onItemDragEnded(sprite.name);
    }
}
