using System;
using System.Collections.ObjectModel;

namespace RoladorDeDados
{
    public partial class MainPage : ContentPage
    {
        private readonly Random _random = new Random();

        public ObservableCollection<string> History { get; } = new ObservableCollection<string>();

        private int _diceSides = 6; // valor padrão D6

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;

            ResultLabel.Text = "6";
            History.Add("Primeiro valor: 6");

            // Configura o picker para iniciar no D6
            DicePicker.SelectedIndex = 1;
            DicePicker.SelectedIndexChanged += OnDiceChanged;
        }

        private void OnDiceChanged(object sender, EventArgs e)
        {
            string selected = DicePicker.SelectedItem?.ToString() ?? "D6";
            _diceSides = int.Parse(selected.Substring(1)); // remove o "D" e pega número
        }

        private async void OnRollClicked(object sender, EventArgs e)
        {
            int roll = _random.Next(1, _diceSides + 1);
            ResultLabel.Text = roll.ToString();

            // Animação de zoom (escala)
            await ResultLabel.ScaleTo(1.4, 100, Easing.CubicOut);
            await ResultLabel.ScaleTo(1.0, 100, Easing.CubicIn);

            // Adiciona histórico
            History.Insert(0, $"D{_diceSides} rolado: {roll}");
        }
    }
}

