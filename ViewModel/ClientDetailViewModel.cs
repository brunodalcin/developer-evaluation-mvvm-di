using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using developer_evaluation_mvvm_di.Model;
using developer_evaluation_mvvm_di.Services;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Windows.Input;
    
namespace developer_evaluation_mvvm_di.ViewModel
{
    [QueryProperty(nameof(Client), "Client")]
    public partial class ClientDetailViewModel : ObservableValidator
    {        
        [Required(ErrorMessage = "Name is mandatory")]
        [RegularExpression(@"^[A-Za-zÀ-ÿ\s]+$", ErrorMessage = "Name cannot contain numbers or special characters")]
        [ObservableProperty]
        private string name;
        
        [Required(ErrorMessage = "LastName is mandatory")]
        [RegularExpression(@"^[A-Za-zÀ-ÿ\s]+$", ErrorMessage = "LastName cannot contain numbers or special characters")]
        [ObservableProperty]
        private string lastName;

        [Required(ErrorMessage = "Age is mandatory")]
        [Range(1, 100, ErrorMessage = "Age must be between 1 and 100")]
        [ObservableProperty]
        private int age;

        [Required(ErrorMessage = "Address is mandatory")]
        [ObservableProperty]
        private string address;

        public string ValidationMessage =>
            HasErrors
                ? string.Join("\n", GetErrors(null)?.OfType<ValidationResult>().Select(v => v.ErrorMessage))
                : null;

        public Client Client { get; set; }

        public bool IsEditMode => Client.ID != 0;
        public ICommand SaveClientCommand { get; }
        public ICommand CancelCommand { get; }

        public ClientDetailViewModel(IClientService clientService, ObservableCollection<Client> clients, Client client = null)
        {
            Client = client ?? new Client();
            Name = Client.Name ?? string.Empty;
            LastName = Client.LastName ?? string.Empty;
            Age = Client.Age;
            Address = Client.Address ?? string.Empty;


            ErrorsChanged += (s, e) =>
            {
                OnPropertyChanged(nameof(ValidationMessage));
            };

            SaveClientCommand = new Command(async () =>
            {
                ValidateAllProperties();
                if (HasErrors)
                    return;

                Client.Name = Name;                
                Client.LastName = LastName;
                Client.Age = Age;
                Client.Address = Address;

                if (IsEditMode)
                {
                    await clientService.Update(Client);
                    await Application.Current.MainPage.DisplayAlert("Update", $"Client successfully updated!", "OK");
                }
                else
                {
                    await clientService.Create(Client);
                    await Application.Current.MainPage.DisplayAlert("Create", $"Client successfully created!", "OK");
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