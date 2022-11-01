namespace CollectionView_test;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage(ViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}
}

