using developer_evaluation_btg.ViewModel;

namespace developer_evaluation_btg.View;

public partial class ClientDetailPage : ContentPage
{
    public ClientDetailPage(ClientDetailViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
