using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OptixTechTest.Models;
using OptixTechTest.Services;
using OptixTechTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OptixTechTestUnitTests.ViewModelTests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        private Mock<IDealerService> _dealerService;
        private Mock<IDialogService> _dialogService;

        private MainWindowViewModel _viewModel;

        Card card;
        Deck deck;

        [TestInitialize]
        public void Initialise()
        {
            card = new Card { Suit = EnumSuit.Hearts, Value = EnumValue.King };
            deck = new Deck() { Cards = new List<Card>() { card } };
            
            _dealerService = new Mock<IDealerService>();
            _dialogService = new Mock<IDialogService>();

            _dealerService.Setup(d => d.NewDeck()).Returns(deck);
            _dialogService.Setup(s => s.ShowDialog(It.IsAny<string>(), It.IsAny<string>())).Returns(System.Windows.MessageBoxResult.OK);

            _viewModel = new MainWindowViewModel(_dealerService.Object, _dialogService.Object);
        }

        [TestMethod]
        public void DrawCommand_GetsCorrectCard()
        {
            _viewModel.CommandDraw.Execute();
            _viewModel.CurrentCard.Should().Be(card);
        }

        [TestMethod]
        public void DrawCommand_DrawFromEmptyDeckClearsCurrentCard()
        {
            _viewModel.CommandDraw.Execute();
            _viewModel.CurrentCard.Should().Be(card, "First card must be drawn correctly");

            _viewModel.CommandDraw.Execute();
            _viewModel.CurrentCard.Should().Be(null);
        }

        [TestMethod]
        public void ResetCommand_ReturnsDeckToOriginalState()
        {
            _viewModel.CommandDraw.Execute();
            _viewModel.CommandReset.Execute();

            deck.Cards.Should().Contain(card);
        }
    }
}
