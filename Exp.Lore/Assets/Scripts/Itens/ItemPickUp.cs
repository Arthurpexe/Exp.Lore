
using UnityEngine;

public class ItemPickUp : Interagivel
{
    public Item item;
    public Sprite ItemSprite;
    public override void Interact()
    {
        base.Interact();
        Debug.Log("Interagindo com " + item.name);
        PickUp();
    }

    public void PickUp()
    {
        Debug.Log("Pegando " + item.name);
        bool wasPickedUp = Inventario.instance.Add(item);

        if (wasPickedUp)
            Destroy(gameObject);
    }
    void Start()
    {
        this.item = new Item();
        item.name = "blalal";
        item.icon = ItemSprite;
    }
}
