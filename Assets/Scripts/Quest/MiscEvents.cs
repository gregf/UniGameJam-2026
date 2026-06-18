using System;

public class MiscEvents
{
    public event Action onItemCollected;
    public void ItemCollected() 
    {
        if (onItemCollected != null) 
        {
            onItemCollected();
        }
    }
}