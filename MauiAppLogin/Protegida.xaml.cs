namespace MauiAppLogin;

public partial class Protegida : ContentPage
{
	public Protegida()
	{
		InitializeComponent();

		string? usuarioLogado = null;
		Task.Run(async () => {

			usuarioLogado = await SecureStorage.Default.GetAsync("usuarioLogado");
			lbl_boasvindas.Text = $"Bem-vindo(a) {usuarioLogado}";
		
		});
	
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
	  	bool confirmacao = await DisplayAlertAsync("Tem certeza?", "Sair do App?", "Sim", "Não");
		if (confirmacao)
		{
			SecureStorage.Default.Remove("usuarioLogado");			
			App.Current.MainPage = new Login();
        }
	}
}