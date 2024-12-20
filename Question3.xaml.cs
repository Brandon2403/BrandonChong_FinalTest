namespace BrandonChong_FinalTest;
using BrandonChong_FinalTest.ViewModel;

public partial class Question3 : ContentPage
{
	public Question3()
	{
		InitializeComponent();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is PostViewModel viewModel)
        {
            viewModel.LoadPostsCommand.Execute(null);
        }
    }

    private async void OnAddClicked(object sender, EventArgs e)
    {
        var popupPage = new AddPostPage();
        await Navigation.PushModalAsync(popupPage);
    }

}