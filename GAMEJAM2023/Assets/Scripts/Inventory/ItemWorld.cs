using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;

public class ItemWorld : MonoBehaviour
{
    public static ItemWorld SpawnItemWorld(Vector3 position, Item item)
    {
        Transform transform = Instantiate(ItemAssets.Instance.pfItemWorld, position, Quaternion.identity);

        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);

        return itemWorld;
    }

    public static ItemWorld DropItem(Vector3 dropPosition, Item item)
    {
        //Vector3 randomDir = UtilsClass.GetRandomDir();
        Vector3 upDir = new Vector3(0, 1, 0);
        ItemWorld itemWorld = SpawnItemWorld(dropPosition + upDir * 1.1f, item);
        //itemWorld.GetComponent<Rigidbody2D>().AddForce(randomDir * 5f, ForceMode2D.Impulse);
        return itemWorld;
    }

    private Item item;
    private SpriteRenderer spriteRenderer;
    //private Light light2D;
    private TextMeshPro textMeshPro;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //light2D = GetComponent<Light>();
        textMeshPro = transform.Find("AmountText").GetComponent<TextMeshPro>();
    }

    public void SetItem(Item item)
    {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();
        //light2D.color = item.GetColor();

        if(item.amount > 1)
        {
            textMeshPro.SetText(item.amount.ToString());
        }
        else
        {
            textMeshPro.SetText("");
        }
    }

    public Item GetItem()
    {
        return item;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
