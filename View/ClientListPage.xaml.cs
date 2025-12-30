using developer_evaluation_mvvm_di.ViewModel;

namespace developer_evaluation_mvvm_di.View;

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