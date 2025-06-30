namespace LoginAndLogoutTemplate
{
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
                List<UserDatas> user_list = new List<UserDatas>()
                {
                    new UserDatas()
                    {
                        User = "jose",
                        Password = "123"
                    }
                };

                UserDatas datas = new UserDatas()
                {
                    User = txt_user.Text,
                    Password = txt_password.Text
                };

                if (user_list.Any(i => datas.User == i.User &&
                    datas.Password == i.Password
                    ))
                {
                    await SecureStorage.Default.SetAsync("usuario_logado", datas.User);

                    App.Current.MainPage = new Protegida();
                }
                else 
                {
                   throw new Exception("Usuário e/ou senha incorreta");
                }

            }
            catch (Exception ex) 
            {

               await DisplayAlert("Ops", ex.Message, "Fechar");
            
            }
        }
    }

}