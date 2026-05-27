namespace MauiAppLogin;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		try
		{
            // Simulando um banco de dados de usuários
            List<DadosUsuario> lista_usuarios = new List<DadosUsuario>()
			{
				new DadosUsuario()
				{ 
					Usuario = "jose",
					Senha = "123"
				},
				new DadosUsuario()
				{ 
					Usuario = "maria",
					Senha = "321"
				},
				new DadosUsuario()
				{
					Usuario = "jhonatan",
					Senha = "159753"
				}

            };

            // Criando um objeto com os dados digitados pelo usuário
            DadosUsuario dados_digitados = new DadosUsuario()
            {
				Usuario = txt_usuario.Text,
				Senha = txt_senha.Text
            };

            // Verificando se os dados digitados correspondem a algum usuário na lista com Linq
            if (lista_usuarios.Any(u => (u.Usuario == dados_digitados.Usuario && u.Senha == dados_digitados.Senha)))// Para cada item da lista, será vewrificado se o que foi digitado como usuário e senha corresponde a algum item da lista,
																													// se sim, o resultado será true, caso contrário, false
            {
				await DisplayAlertAsync("Sucesso!","Login efetuado com sucesso!", "Fechar");
				await SecureStorage.Default.SetAsync("usuarioLogado", dados_digitados.Usuario);// Armazenando o nome do usuário logado de forma segura
				App.Current.Windows[0].Page = new Protegida(); // Redirecionando para a página protegida após o login bem-sucedido
            }
			else
			{
				await DisplayAlertAsync("Erro", "Usuário ou senha incorretos!", "Fechar");
            }


        }
        catch (Exception ex)
		{
			await DisplayAlertAsync("Error", ex.Message,"Fechar");
        }
    }
}