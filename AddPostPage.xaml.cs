namespace MauiApp3;

public partial class AddPostPage : ContentPage
{
	public AddPostPage()
	{
		InitializeComponent();
	}

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync(); // Close the popup
    }

}