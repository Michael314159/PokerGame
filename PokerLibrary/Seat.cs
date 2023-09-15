using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PokerLibrary
{
    public class Seat
    {
       

        public int Number { get; set; }
        public string Name { get; set; }



        public Player? Player { get; set; }


        //the game model will need to know where vatious buttons are, and, move them

        public bool IsPlaying { get; set; }
        public bool IsDealer { get; set; }
        public bool IsBigBlind { get; set; }
        public bool IsSmallBlind { get; set; }

        public Seat(int number)
        {

            this.Number = number;
            this.Name = $"Seat {Number}";

        }

        public void AddPlayer(Player player)
        {
            this.Player = player;
        }

        public void RemovePlayer()
        {
            this.Player = null;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(Name.ToString() + " ");
            sb.Append($"isPlaying: {IsPlaying.ToString()} ");
            sb.Append($"isDealer: {IsDealer.ToString()} ");
            sb.Append($"isSmallBlind: {IsSmallBlind.ToString()} ");
            sb.Append($"isBigBlind: {IsBigBlind.ToString()} ");
            sb.AppendLine();

            return sb.ToString();

        }

        public static List<Seat> MoveDealerButton(List<Seat> seats)
        {

            //if this is the first

            //No Dealer button
            if (seats.Where(x => x.IsDealer).Count() == 0)
            {
                //Not enoiugh active Seats
                if (seats.Where( x => x.IsPlaying).Count() < 2)
                {
                    return seats;
                } else
                {
                    //just pick one
                    foreach (Seat s in seats)
                    {
                        if (s.IsPlaying == true)
                        {
                            s.IsDealer = true;
                            return seats;
                        }
                    }
                }

            }
            //What we want: the next clockwise Seat that is eligible to play

            //What we have: the list of seats.

            //in what sequence do we interview potental new buttons?
            //If the current DB is seat 4, then 5,6,7,8,9,1,2,3,4 .....

            Seat currentDealerButtonSeat = new Seat(0);
            currentDealerButtonSeat = seats.First(x => x.IsDealer == true);
            int currentDealerButtonSeatNumber = currentDealerButtonSeat.Number;

            List<int> interviewSequence; 

            switch (currentDealerButtonSeatNumber)
            {
                case 1: interviewSequence = new List<int>() { 2, 3, 4, 5, 6, 7, 8, 9, 1 }; break;
                case 2: interviewSequence = new List<int>() { 3, 4, 5, 6, 7, 8, 9, 1, 2 }; break;
                case 3: interviewSequence = new List<int>() { 4, 5, 6, 7, 8, 9, 1, 2, 3 }; break;
                case 4: interviewSequence = new List<int>() { 5, 6, 7, 8, 9, 1, 2, 3, 4 }; break;
                case 5: interviewSequence = new List<int>() { 6, 7, 8, 9, 1, 2, 3, 4, 5 }; break;
                case 6: interviewSequence = new List<int>() { 7, 8, 9, 1, 2, 3, 4, 5, 6 }; break;
                case 7: interviewSequence = new List<int>() { 8, 9, 1, 2, 3, 4, 5, 6, 7 }; break;
                case 8: interviewSequence = new List<int>() { 9, 1, 2, 3, 4, 5, 6, 7, 8 }; break;
                case 9: interviewSequence = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 }; break;

                default:
                    interviewSequence = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 }; break; ;
            }

            foreach (int s in interviewSequence)
            {
                Console.WriteLine(s.ToString());
                //this is the seat number order we need to check to find the next DB
                //if the current DbSeatNumber is 5 for instance, this sequence will be 6,7,8,9,1,2,3,4,5

                int idx = s - 1;  //the seat index is 1 less than the seat number

                if (seats[idx].IsPlaying == true)
                {
                    //bingo
                    seats[idx].IsDealer = true;
                    seats[Seat.CurrentSeatIndex(currentDealerButtonSeatNumber)].IsDealer = false;
                    return seats;
                }

            }
           
           
            return seats;
            
          
        }

        public static List<Seat> MoveBigBlindButton(List<Seat> seats)
        {
            //if this is the first

            //No big blind button
            if (seats.Where(x => x.IsBigBlind).Count() == 0)
            {
                //Not enoiugh active Seats
                if (seats.Where(x => x.IsPlaying).Count() < 2)
                {

                    return seats;
                }
                else
                {
                    //just pick one
                    foreach (Seat s in seats)
                    {
                        if (s.IsSmallBlind == false && s.IsDealer == false)
                        {
                            s.IsBigBlind = true;
                            return seats;
                        }
                    }
                }

            }
            //What we want: the next clockwise Seat that is eligible to play

            //What we have: the list of seats.

            //in what sequence do we interview potental new buttons?
            //If the current DB is seat 4, then 5,6,7,8,9,1,2,3,4 .....

            Seat currentBigBlindButtonSeat = new Seat(0);
            currentBigBlindButtonSeat = seats.First(x => x.IsDealer == true);
            int currentBigBlindButtonSeatNumber = currentBigBlindButtonSeat.Number;

            List<int> interviewSequence;

            switch (currentBigBlindButtonSeatNumber)
            {
                case 1: interviewSequence = new List<int>() { 2, 3, 4, 5, 6, 7, 8, 9, 1 }; break;
                case 2: interviewSequence = new List<int>() { 3, 4, 5, 6, 7, 8, 9, 1, 2 }; break;
                case 3: interviewSequence = new List<int>() { 4, 5, 6, 7, 8, 9, 1, 2, 3 }; break;
                case 4: interviewSequence = new List<int>() { 5, 6, 7, 8, 9, 1, 2, 3, 4 }; break;
                case 5: interviewSequence = new List<int>() { 6, 7, 8, 9, 1, 2, 3, 4, 5 }; break;
                case 6: interviewSequence = new List<int>() { 7, 8, 9, 1, 2, 3, 4, 5, 6 }; break;
                case 7: interviewSequence = new List<int>() { 8, 9, 1, 2, 3, 4, 5, 6, 7 }; break;
                case 8: interviewSequence = new List<int>() { 9, 1, 2, 3, 4, 5, 6, 7, 8 }; break;
                case 9: interviewSequence = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 }; break;

                default:
                    interviewSequence = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 }; break; ;
            }

            foreach (int s in interviewSequence)
            {
                Console.WriteLine(s.ToString());
                //this is the seat number order we need to check to find the next DB
                //if the current DbSeatNumber is 5 for instance, this sequence will be 6,7,8,9,1,2,3,4,5

                int idx = s - 1;  //the seat index is 1 less than the seat number

                if (seats[idx].IsPlaying == true)
                {
                    //bingo
                    seats[idx].IsBigBlind = true;
                    seats[Seat.CurrentSeatIndex(currentBigBlindButtonSeatNumber)].IsBigBlind = false;
                    return seats;
                }

            }


            return seats;


        }

        public static List<Seat> MoveSmallBlindButton(List<Seat> seats)
        {

            //if this is the first

            //No small blind button
            if (seats.Where(x => x.IsSmallBlind).Count() == 0)
            {
                //Not enoiugh active Seats
                if (seats.Where(x => x.IsPlaying).Count() < 2)
                {
                    return seats;
                }
                else
                {
                    //just pick one
                    foreach (Seat s in seats)
                    {
                        if (s.IsBigBlind == false && s.IsDealer == false)
                        {
                            s.IsSmallBlind = true;
                            return seats;
                        }
                    }
                }

            }
            //What we want: the next clockwise Seat that is eligible to play

            //What we have: the list of seats.

            //in what sequence do we interview potental new buttons?
            //If the current DB is seat 4, then 5,6,7,8,9,1,2,3,4 .....

            Seat currentSmallBlindButtonSeat = new Seat(0);
            currentSmallBlindButtonSeat = seats.First(x => x.IsSmallBlind == true);
            int currentSmallBlindButtonSeatNumber = currentSmallBlindButtonSeat.Number;

            List<int> interviewSequence;

            switch (currentSmallBlindButtonSeatNumber)
            {
                case 1: interviewSequence = new List<int>() { 2, 3, 4, 5, 6, 7, 8, 9, 1 }; break;
                case 2: interviewSequence = new List<int>() { 3, 4, 5, 6, 7, 8, 9, 1, 2 }; break;
                case 3: interviewSequence = new List<int>() { 4, 5, 6, 7, 8, 9, 1, 2, 3 }; break;
                case 4: interviewSequence = new List<int>() { 5, 6, 7, 8, 9, 1, 2, 3, 4 }; break;
                case 5: interviewSequence = new List<int>() { 6, 7, 8, 9, 1, 2, 3, 4, 5 }; break;
                case 6: interviewSequence = new List<int>() { 7, 8, 9, 1, 2, 3, 4, 5, 6 }; break;
                case 7: interviewSequence = new List<int>() { 8, 9, 1, 2, 3, 4, 5, 6, 7 }; break;
                case 8: interviewSequence = new List<int>() { 9, 1, 2, 3, 4, 5, 6, 7, 8 }; break;
                case 9: interviewSequence = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 }; break;

                default:
                    interviewSequence = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 }; break; ;
            }

            foreach (int s in interviewSequence)
            {
                Console.WriteLine(s.ToString());
                //this is the seat number order we need to check to find the next DB
                //if the current DbSeatNumber is 5 for instance, this sequence will be 6,7,8,9,1,2,3,4,5

                int idx = s - 1;  //the seat index is 1 less than the seat number

                if (seats[idx].IsPlaying == true)
                {
                    //bingo
                    seats[idx].IsDealer = true;
                    seats[Seat.CurrentSeatIndex(currentSmallBlindButtonSeatNumber)].IsSmallBlind = false;
                    return seats;
                }

            }


            return seats;


        }

        private static int CurrentSeatNumberIndex(int currentSeatNumber)
        {
            //The next seat index is more useful than the actual seat number.
            //Cannot simple decrement as the sests are in a ring of 1,2,3,4,5,6,7,8,9,1,2,3,4 etc...
            int nextSeatIndex = 0;

            switch (currentSeatNumber)
            {
                case 1: nextSeatIndex = 0; break;   //This is the only tricky one
                case 2: nextSeatIndex = 1; break;
                case 3: nextSeatIndex = 2; break;
                case 4: nextSeatIndex = 3; break;
                case 5: nextSeatIndex = 4; break;
                case 6: nextSeatIndex = 5; break;
                case 7: nextSeatIndex = 6; break;
                case 8: nextSeatIndex = 7; break;
                case 9: nextSeatIndex = 8; break;   

                default: break;
            }



            return nextSeatIndex;
        }


        private static int CurrentSeatIndex(int currentSeatNumber)
        {
            //We could just decrement, but this keeps the logic for the using function clearer.
            int currentSeatIndex = 0;

            switch (currentSeatNumber)
            {
                case 1: currentSeatIndex = 0; break;
                case 2: currentSeatIndex = 1; break;
                case 3: currentSeatIndex = 2; break;
                case 4: currentSeatIndex = 3; break;
                case 5: currentSeatIndex = 4; break;
                case 6: currentSeatIndex = 5; break;
                case 7: currentSeatIndex = 6; break;
                case 8: currentSeatIndex = 7; break;
                case 9: currentSeatIndex = 8; break;   

                default: break;
            }

            return currentSeatIndex;
        }
    }
}
