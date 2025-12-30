using developer_evaluation_btg.Model;
using developer_evaluation_btg.Services;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace developer_evaluation_btg.ViewModel
{
    [QueryProperty(nameof(Client), "Client")]
    public class ClientDetailViewModel : BaseViewModel
    {
        private Client client;
        public Client Client
        {
            get => client;
            set
            {
                if (client == value)
                    return;
                client = value;
                OnPropertyChanged();
            }
        }
        public bool IsEditMode => Client.ID != 0;
        public ICommand SaveClientCommand { get; }
        public ICommand CancelCommand { get; }

        public ClientDetailViewModel(IClientService clientService, ObservableCollection<Client> clients, Client client = null)
        {
            Client = client ?? new Client(); // cria novo se null

            SaveClientCommand = new Command(async () =>
            {
                if (IsEditMode)
                {
                    await clientService.Update(Client);

                    // Atualiza a coleção para refletir a UI
                    var index = clients.IndexOf(clients.First(c => c.ID == Client.ID));
                    if (index >= 0)
                        clients[index] = Client;
                }
                else
                {
                    await clientService.Create(Client);
                    clients.Add(Client); // adiciona na UI
                }

                await Shell.Current.Navigation.PopModalAsync();
            });

            CancelCommand = new Command(async () =>
            {
                await Shell.Current.Navigation.PopModalAsync();
            });
        }
    }
}
