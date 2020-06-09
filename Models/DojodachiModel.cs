using System;

namespace Dojodachi
{
    public class Dojodachi
    {
        public int Fullness {get;set;}
        public int Happiness {get;set;}
        public int Meals {get;set;}
        public int Energy {get;set;}
        public bool IsAlive {get;set;}
        public string LastAction {get;set;}
        public string PictureLocation {get;set;}
        public Dojodachi()
        {
            Fullness = 20;
            Happiness = 20;
            Meals = 3;
            Energy = 50;
            IsAlive = true;
            LastAction = null;
            PictureLocation = "ChickenScream.gif";
        }

        public void Eat()
        {
            if(this.Meals>0)
            {
                Random random = new Random();
                int ChanceToEat = random.Next(1,5);
                this.Meals -= 1;
                if(ChanceToEat==1)
                {
                    int EatFailPic = random.Next(1,3);
                    if(EatFailPic == 1)
                    {
                        this.PictureLocation = "eatfail.gif";
                    }
                    else
                    {
                        this.PictureLocation = "eatfail2.gif";
                    }
                    this.LastAction = "Your pet did not want to eat that!";
                }
                else
                {
                    int AmountFed = random.Next(5,11);
                    this.Fullness += AmountFed;
                    this.PictureLocation = "eatsuccess.webp";
                    this.LastAction = $"Your pet enjoys eating that meal! They gain {AmountFed} points of hunger!";
                }
                if(this.Happiness >100 && this.Energy > 100 && this.Fullness > 100)
                {
                    this.PictureLocation = "victory.gif";
                    this.LastAction = "You've won! Your Dojodachi is the happiest pet in the world!";
                }
            }
            else
            {
                this.PictureLocation = "notenough.gif";
                this.LastAction = "You don't have enough food to feed your pet.";
            }
        }

        public void Play()
        {
            if(this.Energy > 0)
            {
                Random random = new Random();
                int ChanceToPlay = random.Next(1,5);
                this.Energy -=5;
                if(ChanceToPlay==1)
                {
                    this.PictureLocation = "playfail.gif";
                    this.LastAction = "Your pet did not enjoy playing!";
                }
                else
                {
                    int HappinessGained = random.Next(5,11);
                    this.Happiness += HappinessGained;
                    this.PictureLocation = "playsuccess.gif";
                    this.LastAction = $"Your pet enjoys playing with you! They gain {HappinessGained} points of happiness!";
                }
                if(this.Happiness >100 && this.Energy > 100 && this.Fullness > 100)
                {
                    this.PictureLocation = "victory.gif";
                    this.LastAction = "You've won! Your Dojodachi is the happiest pet in the world!";
                }
            }
            else
            {
                this.PictureLocation = "notenough.gif";
                this.LastAction = "Your pet is too tired to play.";
            }
        }

        public void Work()
        {
            Random random = new Random();
            if(this.Energy > 5)
            {
                this.Energy -= 5;
                int MealsGained = random.Next(1,4);
                this.Meals += MealsGained;
                this.PictureLocation = "work.webp";
                this.LastAction = $"Your pet works hard! They gain {MealsGained} meals and lost 5 energy";
            }
            else
            {
                this.PictureLocation = "notenough.gif";
                this.LastAction = "Your pet is too tired to work";
            }
        }

        public void Sleep()
        {
            this.Energy += 15;
            this.Fullness -= 5;
            this.Happiness -= 5;
            this.PictureLocation = "sleep.gif";
            if(this.Fullness <= 0 || this.Happiness <= 0)
            {
                this.IsAlive = false;
                this.PictureLocation = "gameover.webp";
                this.LastAction = "Oh no! Your Dojodachi is no more! It has ceased to be! It's expired and gone to meet it's maker! It's a stiff! Bereft of life, it rests in peace! If it weren't nailed to a perch, it'd be pushing up daisies! It's metabolic processes are now history! It's off the twig! It's kicked the bucket! It's shuffled off this mortal coil, run down the curtain, and joined the bleedin' choir invisible! It's snuffed it! THIS IS AN EX-DOJODACHI!";
            }
            else if(this.Happiness >100 && this.Energy > 100 && this.Fullness > 100)
            {
                this.PictureLocation = "victory.gif";
                this.LastAction = "You've won! Your Dojodachi is the happiest pet in the world!";
            }
        }
    }
}