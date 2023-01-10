
using GoSibu.ViewModels;

namespace GoSibu.Views;

public partial class MainPage : ContentPage
{
    [Obsolete]
    public MainPage()
    {
        InitializeComponent();
       this.BindingContext = new PackageListPageViewModel();
    }

    public async void OnTapGestureRecognizerTapped(object sender, EventArgs eventArgs)
    {
        Image g = (Image)sender;
        await g.TranslateTo(-50, 0, 1000);

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (this.AnimationIsRunning("TransitionAnimation"))
            return;

        var parentAnimation = new Animation();

        //Planets Animation
        parentAnimation.Add(0.2, 0.4, new Animation(v => scroll.Opacity = v, 0, 1, Easing.CubicIn));
        parentAnimation.Add(0.1, 0.4, new Animation(v => Welcome.Opacity = v, 0, 1, Easing.CubicIn));
        parentAnimation.Add(0.1, 0.3, new Animation(v => ad.Opacity = v, 0, 1, Easing.CubicIn));
        parentAnimation.Add(0.1, 0.2, new Animation(v => purhcase.Opacity = v, 0, 1, Easing.CubicIn));

        //Commit the animation
        parentAnimation.Commit(this, "TransitionAnimation", 16, 3000, null, null);
    }
}

