using OptixTechTest.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace OptixTechTest.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly Services.IDealerService _dealerService;
        private readonly Services.IDialogService _dialogService;
        private readonly Random _random;

        public ObservableCollection<Card> Deck { get; private set; } = new ObservableCollection<Card>();
        public ObservableCollection<Card> DrawnCards { get; private set; } = new ObservableCollection<Card>();

        private Card _currentCard;
        public Card CurrentCard
        {
            get { return _currentCard; }
            set
            {
                if (value == _currentCard)
                    return;

                _currentCard = value;
                RaisePropertyChanged(nameof(CurrentCard));
            }

        }

        private DelegateCommand _commandDraw = null;
        public DelegateCommand CommandDraw => _commandDraw ?? (_commandDraw = new DelegateCommand(DrawCard));

        private DelegateCommand _commandReset = null;
        public DelegateCommand CommandReset => _commandReset ?? (_commandReset = new DelegateCommand(ResetDeck));

        private DelegateCommand _commandShuffle = null;
        public DelegateCommand CommandShuffle => _commandShuffle ?? (_commandShuffle = new DelegateCommand(ShuffleDeck));

        public MainWindowViewModel(Services.IDealerService dealerService, Services.IDialogService dialogService)
        {
            _dealerService = dealerService;
            _dialogService = dialogService;
            _random = new Random();
            InitialiseDeck();
        }
        private void InitialiseDeck()
        {
            Deck = new ObservableCollection<Card>(_dealerService.NewDeck().Cards);
        }

        private void DrawCard()
        {
            var card = Deck.FirstOrDefault();
            if (card == null)
            {
                CurrentCard = null;
                _dialogService.ShowDialog("Cannot draw from an empty deck.", "Message");
                return;
            }

            DrawnCards.Add(card);
            Deck.Remove(card);
            CurrentCard = card;
        }

        private void ResetDeck()
        {
            DrawnCards.Clear();
            Deck.Clear();

            CurrentCard = null;

            foreach (var card in _dealerService.NewDeck().Cards)
            {
                Deck.Add(card);
            }
        }

        private void ShuffleDeck()
        {
            if (Deck.Count < 52)
            {
                _dialogService.ShowDialog("Cannot shuffle a partial deck.", "Message");
                return;
            }

            var cleanDeck = new List<Card>(Deck.OrderBy(i => _random.Next(Deck.Count())));
            Deck.Clear();

            foreach (var card in cleanDeck)
            {
                Deck.Add(card);
            }
        }
    }
}
