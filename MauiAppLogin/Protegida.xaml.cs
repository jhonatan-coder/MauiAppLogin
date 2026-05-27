namespace MauiAppLogin;

public partial class Protegida : ContentPage
{
	public Protegida()
	{
		InitializeComponent();
        string? usuarioLogado = null;
        Task.Run(async () =>
        {
            usuarioLogado = await SecureStorage.Default.GetAsync("usuarioLogado");
            lbl_boasvindas.Text = $"Bem-vindo (a) {usuarioLogado}";
        });
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        bool confirmacao = await DisplayAlertAsync("Tem Certeza?", "Sair do App?", "Sim", "Não");
        if (confirmacao)
        {
            SecureStorage.Default.Remove("usuarioLogado"); // Removendo a chave usuáriologado do armazenamento seguro
            App.Current.MainPage = new Login(); // Define a página de login como página principal (root)
            lbl_boasvindas.Text = string.Empty; // Limpa o texto de boas-vindas
        }
    }
}