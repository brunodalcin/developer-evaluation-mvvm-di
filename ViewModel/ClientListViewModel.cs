using developer_evaluation_btg.Model;
using developer_evaluation_btg.Services;
using developer_evaluation_btg.View;
using System.Collections.ObjectModel;

namespace developer_evaluation_btg.ViewModel
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
        public Command EditClientCommand { get; }
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

            EditClientCommand = new Command<Client>(async client =>
            {
                var vm = new ClientDetailViewModel(clientService, Clients, client); // have 'client' = edit
                await Shell.Current.Navigation.PushModalAsync(new ClientDetailPage(vm));
            });
        }

    }
}
