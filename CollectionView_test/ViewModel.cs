using MvvmHelpers;
using System.Windows.Input;

namespace CollectionView_test;

public class ViewModel : ObservableObject
{
    private ObservableRangeCollection<Item> _items;

    public ObservableRangeCollection<Item> Items
    {
        get => _items;
        set => SetProperty(ref _items, value, nameof(Items));
    }


    bool busy = false;

    public ICommand LoadMoreItemsCommand => new Command(async () =>
    {
        if (busy)
        {
            return;
        }

        busy = true;
        await Task.Delay(1000);
        ObservableRangeCollection<Item> temp = new();
        for (int i = 0; i < 20; ++i)
        {
            temp.Add(new Item { Name = i.ToString() });
        }
        _items.AddRange(temp);
        busy = false;
    });

    public ViewModel()
    {
        _items = new ObservableRangeCollection<Item>();
        for(int i = 0; i < 20; ++i ) 
        { 
            _items.Add(new Item { Name= i.ToString() });
        }
    }
} 


public class Item
{
    public string Name { get; set; }
}