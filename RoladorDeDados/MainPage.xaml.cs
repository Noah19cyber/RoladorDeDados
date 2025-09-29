using System;
using System.Collections.ObjectModel;

namespace RoladorDeDados;

public partial class MainPage : ContentPage
{
    private readonly Random _random = new Random();

    public ObservableCollection<string> History { get; } = new ObservableCollection<string>();

    public MainPage()
    {
        InitializeComponent();
        BindingContext = this;

        ResultLabel.Text = "6";
        History.Add("Primeiro valor: 6");
    }

    private async void OnRollClicked(object sender, EventArgs e)
    {
        int roll = _random.Next(1, 7);
        ResultLabel.Text = roll.ToString();

        // Animação de zoom
        await ResultLabel.ScaleTo(1.4, 100, Easing.CubicOut);
        await ResultLabel.ScaleTo(1.0, 100, Easing.CubicIn);

        // Adiciona histórico
        History.Insert(0, $"Dado rolado: {roll}");
    }
}
