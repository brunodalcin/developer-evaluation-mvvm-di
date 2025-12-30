using developer_evaluation_btg.ViewModel;

namespace developer_evaluation_btg.View;

public partial class ClientListPage : ContentPage
{
	public ClientListPage(ClientListViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is ClientListViewModel vm)
        {
            vm.GetClientsCommand.Execute(null);
        }
    }

}