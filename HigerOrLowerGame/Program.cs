using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigerOrLowerGame
{
    class Program
    {
        //create a deck that consists of 52 unique cards of 4 suits
        //suit can be Heart, Diamond, Club or Spade.
        //each suit has 13 unique cards
        //card values can be 2,3,4,5,6,7,8,9,10,J/11,Q/12,K/13,A/14.
        //each card has a value and a suit and an ID
        //ids will be 0-51. 
        public class Card
        {
            public CardFace Face;
            public CardSuit Suit;
            public override string ToString()
            {
                return Face + " " + Suit;
            }

        }  
        
        public enum CardFace
        {
            //will need to +2 to the values
            Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace
        }     
    
        public enum CardSuit
        {
            Hearts, Diamond, Clubs, Spades
        }

        static void OldMain() {
            Card cardOne = new Card
            {
                Face = CardFace.Ace, Suit = CardSuit.Clubs                
            };
            Card cardTwo = new Card
            {
                Face = CardFace.Two,
                Suit = CardSuit.Clubs
            };

            if(cardOne.Face > cardTwo.Face)
            {
                Console.WriteLine("Logic should work");
            }
            else
            {
                Console.WriteLine("broken");
            }
            


        }

       static void Main()
        {           
            Random random = new Random();
            var faceValues = Enum.GetValues(typeof(CardFace));
            var suitValues = Enum.GetValues(typeof(CardSuit));
            var deck = new List<Card>();

            foreach(var face in faceValues)
            {
                
                foreach(var suit in suitValues)
                {
                    var card = new Card();
                    card.Suit = (CardSuit)suit;
                    card.Face = (CardFace)face;
                    deck.Add(card);
                } 
            }           
            Console.WriteLine("Press ESC to stop at any time!");

            Stack<Card> shuffledDeck = new Stack<Card>(deck.OrderBy(c => random.Next()));
            var currentCard = shuffledDeck.Pop();             
            var nextCard = shuffledDeck.Pop();
            int streak = 0;
            Console.WriteLine("Decide if you think the next card will be higher or lower than the one below!");
            Console.WriteLine("Press 1 for higher");
            Console.WriteLine("or");
            Console.WriteLine("Press 2 for lower");
            Console.WriteLine("The current card is: " + currentCard);
            do
            {
                bool playerChoice = Console.ReadKey(true).Key == ConsoleKey.D1;
                if ((playerChoice == true && nextCard.Face > currentCard.Face) || (playerChoice == false && nextCard.Face < currentCard.Face))
                {
                    streak++;
                    Console.WriteLine("Correct!");
                    Console.WriteLine("Your streak is " + streak);
                    currentCard = nextCard;
                    nextCard = shuffledDeck.Pop();
                    Console.WriteLine("The current card is: " + currentCard);
                }
                else
                {
                    Console.WriteLine("The next card was " + nextCard);
                    Console.WriteLine("You were wrong! Better luck next time!");
                    Environment.Exit(0);
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);   
        }
    }
}
