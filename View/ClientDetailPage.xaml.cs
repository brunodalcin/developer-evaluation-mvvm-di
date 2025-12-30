using developer_evaluation_mvvm_di.ViewModel;

namespace developer_evaluation_mvvm_di.View;

public partial class ClientDetailPage : ContentPage
{
    public ClientDetailPage(ClientDetailViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
