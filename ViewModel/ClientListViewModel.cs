using developer_evaluation_mvvm_di.Model;
using developer_evaluation_mvvm_di.Services;
using developer_evaluation_mvvm_di.View;
using System.Collections.ObjectModel;

namespace developer_evaluation_mvvm_di.ViewModel
{
    public partial class ClientListViewModel : BaseViewModel
    {
        private readonly IClientService clientService;
        public ObservableCollection<Client> Clients { get; } = new();
        public Client SelectedClient { get; set; }
        public bool IsEditMode { get; set; }
        public bool IsClientFormVisible { get; set; }
        public Command GetClientsCommand { get; }
        public Command AddClientCommand { get; }
        public Command UpdateClientCommand { get; }
        public Command DeleteClientCommand { get; }
        public ClientListViewModel(IClientService clientService)
        {
            Title = "Client List";
            this.clientService = clientService;           

            GetClientsCommand = new Command(async () =>
            {
                Clients.Clear();
                var result = await clientService.GetAllAsync();
                foreach (var client in result)
                    Clients.Add(client);
            });

            AddClientCommand = new Command(async () =>
            {
                var vm = new ClientDetailViewModel(clientService, Clients); // DO NOT have 'client' = create
                await Shell.Current.Navigation.PushModalAsync(new ClientDetailPage(vm));
            });

            UpdateClientCommand = new Command<Client>(async client =>
            {
                var vm = new ClientDetailViewModel(clientService, Clients, client); // have 'client' = edit
                await Shell.Current.Navigation.PushModalAsync(new ClientDetailPage(vm));
            });

            DeleteClientCommand = new Command<Client>(async client =>
            {
                if (client == null) return;

                bool isDeleting = await Application.Current.MainPage.DisplayAlert("Delete",
                    $"Are you sure you want to delete {client.Name}?", "OK", "Cancel");

                if (!isDeleting)
                    return;

                await clientService.Delete(client.ID);
                Clients.Remove(client);
                //need to refresh data ?
            });
        }

    }
}
