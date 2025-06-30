namespace LoginAndLogoutTemplate;

public partial class Protegida : ContentPage
{
	public Protegida()
	{
		InitializeComponent();

		string? usuario_logado = null;

		Task.Run(async () =>
		{
            // obtém usuari logado do SecureStorage
            usuario_logado = await SecureStorage.Default.GetAsync("usuario_logado");
			lbl_welcome.Text = $"Bem-vindo(a) {usuario_logado}!";

        });
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		 bool Confirmed = await DisplayAlert("Tem certeza?","Sair do App","Sim", "Não");
		if (Confirmed) 
		{
			SecureStorage.Default.Remove("usuario_logado"); // Remove o usuário logado
			App.Current.MainPage = new Login(); // Redireciona para a página de login
        }
	}
} 